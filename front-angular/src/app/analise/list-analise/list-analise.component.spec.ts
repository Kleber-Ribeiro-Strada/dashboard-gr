import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAnaliseComponent } from './list-analise.component';

describe('ListAnaliseComponent', () => {
  let component: ListAnaliseComponent;
  let fixture: ComponentFixture<ListAnaliseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListAnaliseComponent]
    });
    fixture = TestBed.createComponent(ListAnaliseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
