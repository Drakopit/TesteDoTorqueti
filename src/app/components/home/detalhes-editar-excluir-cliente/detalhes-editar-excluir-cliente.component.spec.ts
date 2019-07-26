import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesEditarExcluirClienteComponent } from './detalhes-editar-excluir-cliente.component';

describe('DetalhesEditarExcluirClienteComponent', () => {
  let component: DetalhesEditarExcluirClienteComponent;
  let fixture: ComponentFixture<DetalhesEditarExcluirClienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhesEditarExcluirClienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesEditarExcluirClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
