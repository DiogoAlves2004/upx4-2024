import { Component, EventEmitter, Output } from '@angular/core';
import { AvatarModule } from 'primeng/avatar';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [ToolbarModule, AvatarModule, ButtonModule],
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss'
})
export class ToolbarComponent {

  @Output() onAddicionarPonto = new EventEmitter();

  adicionarPontoEmiter() {
    this.onAddicionarPonto.emit()
  }

}

