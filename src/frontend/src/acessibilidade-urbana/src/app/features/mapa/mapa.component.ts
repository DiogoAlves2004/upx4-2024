import { Component, AfterViewInit } from '@angular/core';
import * as maplibregl from 'maplibre-gl';

@Component({
  selector: 'app-mapa',
  standalone: true,
  imports: [],
  templateUrl: './mapa.component.html',
  styleUrl: './mapa.component.scss'
})
export class MapaComponent implements AfterViewInit {

  private map!: maplibregl.Map;

  private markers: maplibregl.Marker[] = []; // Array para armazenar marcadores


  constructor() { }

  ngAfterViewInit(): void {
    // Inicializar o mapa
    const myAPIKey = '250c9bd646e44aedbe157827ae3caac4';
    const mapStyle = 'https://maps.geoapify.com/v1/styles/positron/style.json';
    const style = `${mapStyle}?apiKey=${myAPIKey}`

    this.map = new maplibregl.Map({
      container: 'map', // ID do elemento HTML
      style: style, // Estilo do mapa (OpenStreetMap de exemplo)
      center: [-46.625290, -23.533773], // Coordenadas iniciais [long, lat]
      zoom: 12 // Nível de zoom inicial
    });

    // Adicionar controles ao mapa
    this.map.addControl(new maplibregl.NavigationControl(), 'top-right');

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
    this.markers.forEach(marker => marker.remove());
    this.markers = [];

    // Buscar novos pontos do backend
    this.accessibilityService.getPoints(north, south, east, west).subscribe(points => {
      points.forEach(point => {
        const marker = new maplibregl.Marker()
          .setLngLat([point.longitude, point.latitude])
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
}
