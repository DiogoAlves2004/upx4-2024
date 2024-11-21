import { Component, AfterViewInit } from '@angular/core';
import * as maplibregl from 'maplibre-gl';
import { PontosDeAcessibilidadeService } from '../../core/services/PontosDeAcessibilidade.service';
import { ToolbarModule } from 'primeng/toolbar';
import { AvatarModule } from 'primeng/avatar';
import { ToolbarComponent } from '../toolbar/toolbar.component';
import { GeolocateControl } from 'maplibre-gl';
import { Button, ButtonModule } from 'primeng/button';
import { SidebarModule } from 'primeng/sidebar';
import { ContextMenuModule } from 'primeng/contextmenu';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { UpxInputTextComponent } from '../../features-components/upx-input-text/upx-input-text.component';
import { FormControl, FormGroup } from '@angular/forms';
import { InputTextareaModule } from 'primeng/inputtextarea';
@Component({
  selector: 'app-mapa',
  standalone: true,
  imports: [
    ToolbarModule,
    AvatarModule,
    ToolbarComponent,
    InputTextareaModule,
    SidebarModule,
    ButtonModule,
    ContextMenuModule,
    ToastModule,
    UpxInputTextComponent,
  ],
  templateUrl: './mapa.component.html',
  styleUrl: './mapa.component.scss',
})
export class MapaComponent implements AfterViewInit {
  private map!: maplibregl.Map;

  private markers: maplibregl.Marker[] = []; // Array para armazenar marcadores

  addPontoFormGroup: FormGroup = new FormGroup({
    cordx: new FormControl(),
    cordy: new FormControl(),
    descricaopontodeacessibilidade: new FormControl(),
    nome: new FormControl(),
    endereco: new FormControl(),
  });

  sidebarVisible: boolean = false;

  items = [
    { label: 'Copy', icon: 'pi pi-copy' },
    { label: 'Rename', icon: 'pi pi-file-edit' },
  ];

  constructor(
    private readonly service: PontosDeAcessibilidadeService,
    private readonly notificationservice: MessageService
  ) {}

  ngAfterViewInit(): void {
    // Inicializar o mapa
    const myAPIKey = '250c9bd646e44aedbe157827ae3caac4';
    const mapStyle = 'https://maps.geoapify.com/v1/styles/positron/style.json';
    const style = `${mapStyle}?apiKey=${myAPIKey}`;

    this.map = new maplibregl.Map({
      container: 'map', // ID do elemento HTML
      style: style, // Estilo do mapa (OpenStreetMap de exemplo)
      center: [-44.040192, -19.98848], // Coordenadas iniciais [long, lat]
      zoom: 12, // Nível de zoom inicial
    });

    // Adicionar controles ao mapa
    this.map.addControl(new maplibregl.NavigationControl(), 'bottom-left');

    let popup = new maplibregl.Popup();
    // Set an event listener that will fire
    // any time the popup is opened

    this.map.on('moveend', () => {
      this.atualizarMarcadores();
    });
    this.atualizarMarcadores(); // Carregar os marcadores inicialmente
  }

  private atualizarMarcadores(): void {
    // Obter os limites visíveis no mapa
    const bounds = this.map.getBounds();
    const north = bounds.getNorth();
    const south = bounds.getSouth();
    const east = bounds.getEast();
    const west = bounds.getWest();

    // Limpar marcadores antigos
    this.markers.forEach((marker) => marker.remove());
    this.markers = [];

    // Buscar novos pontos do backend
    this.service.getPoints(north, south, east, west).subscribe((points) => {
      points.forEach((point) => {
        const marker = new maplibregl.Marker()
          .setLngLat([point.cordx, point.cordy])
          .setPopup(new maplibregl.Popup().setText(point.description)) // Opcional: adicionar popup
          .addTo(this.map);

        this.markers.push(marker);
      });
    });
  }
  // Opcional: Método para destruição do mapa
  ngOnDestroy(): void {
    if (this.map) {
      this.map.remove();
    }
  }

  private handleAddBound!: (e: any) => void; // Variável para armazenar a função vinculada

  adicionarPontoHandle() {
    this.sidebarVisible = true;
    // Cria a função vinculada para manter o contexto
    this.handleAddBound = this.handleAdd.bind(this);

    // Adiciona o listener de clique no mapa (camada ou evento geral)
    this.map.on('click', this.handleAddBound);
  }

  handleAdd(e: any) {
    this.addPontoFormGroup.get('endereco')?.setValue('Carregando...');

    this.service
      .reverseGeocode(e.lngLat.lng, e.lngLat.lat)
      .subscribe((response) => {
        debugger;
        if (response && response.address) {
          const endereco = response.address;
          let enderecoCompleto = '';

          // Montando o endereço completo
          if (endereco.road) {
            enderecoCompleto += endereco.road;
          }
          if (endereco.city) {
            enderecoCompleto += `, ${endereco.city}`;
          }
          if (endereco.house_number) {
            enderecoCompleto += `${endereco.house_number} `;
          }
          if (endereco.state) {
            enderecoCompleto += `, ${endereco.state}`;
          }
          if (endereco.country) {
            enderecoCompleto += `, ${endereco.country}`;
          }

          this.addPontoFormGroup
            .get('endereco')
            ?.setValue(enderecoCompleto || 'Endereço não encontrado');
        } else {
          this.addPontoFormGroup
            .get('endereco')
            ?.setValue('Endereço não encontrado');
        }
      });

    this.addPontoFormGroup.get('cordx')?.setValue(e.lngLat.lng);
    this.addPontoFormGroup.get('cordy')?.setValue(e.lngLat.lat);
  }
  salvarPonto() {
    const model = this.addPontoFormGroup.getRawValue();
    this.service.criarPonto(model).subscribe(() => {
      this.notificationservice.add({
        severity: 'success',
        summary: 'Ponto salvo',
        detail: 'Ponto de acessibilidade salvo com sucesso',
      });
      this.sidebarVisible = false;
      this.atualizarMarcadores();
    });
  }

  onCloseToast(e: any) {
    // Fecha a sidebar e remove o listener de clique
    this.sidebarVisible = false;
    if (this.handleAddBound) {
      this.map.off('click', this.handleAddBound);
    }
  }
}
