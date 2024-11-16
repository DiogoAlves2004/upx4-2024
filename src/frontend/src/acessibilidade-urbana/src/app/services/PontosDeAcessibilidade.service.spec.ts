/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PontosDeAcessibilidadeService } from './PontosDeAcessibilidade.service';

describe('Service: PontosDeAcessibilidade', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PontosDeAcessibilidadeService]
    });
  });

  it('should ...', inject([PontosDeAcessibilidadeService], (service: PontosDeAcessibilidadeService) => {
    expect(service).toBeTruthy();
  }));
});
