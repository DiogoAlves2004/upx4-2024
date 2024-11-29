import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RatingModule } from 'primeng/rating';

@Component({
  selector: 'app-popup-template',
  template: `
    <div style="width: 200px;">
      <h4>{{ nome }}</h4>
      <p><strong>Endereço:</strong> {{ endereco }}</p>
      <p>{{ descricao }}</p>
      <img *ngIf="icone" [src]="icone" alt="Ícone" style="width: 24px; height: 24px;" />
      <p>Avaliação:{{ 5 }} pontos</p>
      <p-rating 
        [stars]="5" 
        [(ngModel)]="rating" 
        [readonly]="false" 
        [cancel]="false"
        (onRate)="onRatingChanged($event)">
      </p-rating>
    </div>
  `,
  standalone: true,
  imports:[RatingModule, FormsModule]
})
export class PopupTemplateComponent {
  @Input() nome!: string;
  @Input() endereco!: string;
  @Input() descricao!: string;
  @Input() icone!: string;
  @Input() rating: number = 0;

  @Output() ratingChanged = new EventEmitter<number>();

  onRatingChanged(event: any): void {
    this.ratingChanged.emit(this.rating);
  }
}
