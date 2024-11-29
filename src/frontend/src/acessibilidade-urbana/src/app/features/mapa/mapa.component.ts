import { Component, AfterViewInit, ApplicationRef, ComponentFactoryResolver, Injector, ComponentRef } from '@angular/core';
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
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { InputTextareaModule } from 'primeng/inputtextarea';
import { IconPickerComponent } from '../../features-components/icon-picker/icon-picker.component';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { CommonModule } from '@angular/common';
import { RatingModule } from 'primeng/rating';
import { firstValueFrom } from 'rxjs';
import { PopupTemplateComponent } from './popup-template/popup-template.component';
@Component({
  selector: 'app-mapa',
  standalone: true,
  imports: [
    CommonModule,
    ToolbarModule,
    FloatLabelModule,
    AvatarModule,
    InputTextModule,
    InputTextareaModule,
    SidebarModule,
    ButtonModule,
    ContextMenuModule,
    ToastModule,
    IconPickerComponent,
    ToolbarComponent,
    ReactiveFormsModule,
    RatingModule
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
    icone: new FormControl(),
  });

  sidebarVisible: boolean = false;

  items = [
    { label: 'Copy', icon: 'pi pi-copy' },
    { label: 'Rename', icon: 'pi pi-file-edit' },
  ];

  constructor(
    private readonly service: PontosDeAcessibilidadeService,
    private readonly notificationservice: MessageService,
    private componentFactoryResolver: ComponentFactoryResolver,
    private appRef: ApplicationRef,
    private injector: Injector
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

  private async atualizarMarcadores() {
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
    const points = await firstValueFrom(this.service.getPoints(north, south, east, west));
  
    for (const point of points) {
      // Simulação de avaliação
      point.avaliacao = Math.floor(Math.random() * 5) + 1;
  
      // Obter endereço usando reverse geocode
      let enderecoCompleto = '';
      try {
        const responseAddres = await firstValueFrom(this.service.reverseGeocode(point.cordx, point.cordy));
        if (responseAddres && responseAddres.address) {
          const endereco = responseAddres.address;
          // Montando o endereço completo
          if (endereco.road) enderecoCompleto += endereco.road;
          if (endereco.house_number) enderecoCompleto += `, ${endereco.house_number}`;
          if (endereco.city) enderecoCompleto += `, ${endereco.city}`;
          if (endereco.state) enderecoCompleto += `, ${endereco.state}`;
          if (endereco.country) enderecoCompleto += `, ${endereco.country}`;
        }
      } catch (error) {
        console.error('Erro ao buscar endereço:', error);
      }
  
      point.endereco = enderecoCompleto || 'Endereço não encontrado';
  
      // Criar marcador
      const marker = new maplibregl.Marker({
        element: this.createCustomIcon(point?.icone),
      })
        .setLngLat([point.cordx, point.cordy])
        .setPopup(
          new maplibregl.Popup().setDOMContent(this.createPopupContent(point)) // Adiciona conteúdo dinâmico com componente Angular
        )
        .addTo(this.map);
  
      this.markers.push(marker);
    }
  }
  value: number = 5;

  // Função para criar o conteúdo HTML do popup
  private createPopupContent(point: any): HTMLElement {
    // Cria o componente dinamicamente
    const factory = this.componentFactoryResolver.resolveComponentFactory(PopupTemplateComponent);
    const componentRef: ComponentRef<PopupTemplateComponent> = factory.create(this.injector);
  
    // Passa os dados para o componente
    componentRef.instance.nome = point.nome;
    componentRef.instance.endereco = point.endereco;
    componentRef.instance.descricao = point.descricaopontodeacessibilidade;
    componentRef.instance.icone = point.icone;
    componentRef.instance.rating = point.avaliacao;
  
    // Captura eventos emitidos pelo componente
    componentRef.instance.ratingChanged.subscribe((newRating: number) => {
      // this.updateRating(point.id, newRating); // Envia o novo rating ao backend
    });
  
    // Adiciona o componente à árvore de visualização do Angular
    this.appRef.attachView(componentRef.hostView);
  
    // Obtém o elemento DOM do componente renderizado
    const domElem = (componentRef.hostView as any).rootNodes[0] as HTMLElement;
  
    return domElem;
  }

  createCustomIcon(iconClass: string): HTMLElement {
    // Criação de um div para o marcador
    const iconElement = document.createElement('div');

    // Estilização do marcador (como o marcador padrão)
    iconElement.style.width = '30px'; // Defina o tamanho do ícone
    iconElement.style.height = '30px';
    iconElement.style.padding = '20px';
    iconElement.style.borderRadius = '50%'; // Forma redonda (como o marcador padrão)
    iconElement.style.backgroundColor = '#007bff'; // Cor de fundo similar ao marcador padrão
    iconElement.style.display = 'flex';
    iconElement.style.alignItems = 'center';
    iconElement.style.justifyContent = 'center';
    iconElement.style.cursor = 'pointer';

    // Criar o ícone com a classe do PrimeNG (ou outro ícone de sua escolha)
    const icon = document.createElement('span');
    icon.className = `${iconClass}`; // Classe do ícone (por exemplo, pi pi-map-marker)
    icon.style.fontSize = '20px'; // Tamanho do ícone (ajuste conforme necessário)
    icon.style.color = 'white'; // Cor do ícone (geralmente branco para contrastar com o fundo)

    // Adicionar o ícone ao div
    iconElement.appendChild(icon);

    return iconElement;
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
    this.map.getCanvas().style.cursor = 'crosshair'; // Altera o cursor do mapa para cruz
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
      this.map.off('click', this.handleAddBound);
      this.map.getCanvas().style.cursor = 'grab';
      this.atualizarMarcadores();
    });
  }

  onCloseToast(e: any) {
    // Fecha a sidebar e remove o listener de clique
    this.sidebarVisible = false;
    if (this.handleAddBound) {
      this.map.off('click', this.handleAddBound);
      this.map.getCanvas().style.cursor = 'grab';
    }
  }
  setIcon(icon: string) {
    this.addPontoFormGroup.get('icone')?.setValue(icon);
  }
}
