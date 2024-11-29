import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { ChipsModule } from 'primeng/chips';
import { DropdownModule } from 'primeng/dropdown';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { PrimeIcons } from 'primeng/api';

@Component({
  selector: 'app-icon-picker',
  standalone: true,
  imports: [
    OverlayPanelModule,
    InputGroupModule,
    InputGroupAddonModule,
    ButtonModule,
    InputTextModule,
    ChipsModule,
    CommonModule,
  ],
  templateUrl: './icon-picker.component.html',
  styleUrl: './icon-picker.component.scss'
})
export class IconPickerComponent implements OnInit {
  iconOptions: { icon: string; id: string }[] = []; // Define your icon options here
  selectedIcon: string = 'pi-expand'; // Define the selected icon variable here
  value: string = '';

  @Output() onIconChange = new EventEmitter<string>();

  ngOnInit(): void {
    const icones:PrimeIcons =  PrimeIcons

    for (const icone in icones) {
      if (Object.prototype.hasOwnProperty.call(icones, icone)) {
        const element:any = icones[icone as keyof PrimeIcons];
        this.iconOptions.push({icon: element, id: icone});
      }
    }
  }

  selectIcon(icon: string): void {
    this.selectedIcon = icon;
    this.value = icon;  // Atualiza o valor do controle de formulário
    this.onIconChange.emit(icon);
  }

}
