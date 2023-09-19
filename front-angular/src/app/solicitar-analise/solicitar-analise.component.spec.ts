import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitarAnaliseComponent } from './solicitar-analise.component';

describe('SolicitarAnaliseComponent', () => {
  let component: SolicitarAnaliseComponent;
  let fixture: ComponentFixture<SolicitarAnaliseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SolicitarAnaliseComponent]
    });
    fixture = TestBed.createComponent(SolicitarAnaliseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
