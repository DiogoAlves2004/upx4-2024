import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpxInputTextComponent } from './upx-input-text.component';

describe('UpxInputTextComponent', () => {
  let component: UpxInputTextComponent;
  let fixture: ComponentFixture<UpxInputTextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpxInputTextComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpxInputTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
