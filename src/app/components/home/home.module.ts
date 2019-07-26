import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule, DatepickerModule } from 'ngx-bootstrap/datepicker';
import { InserirClienteComponent } from './inserir-cliente/inserir-cliente.component';
import { DetalhesEditarExcluirClienteComponent } from './detalhes-editar-excluir-cliente/detalhes-editar-excluir-cliente.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [InserirClienteComponent, DetalhesEditarExcluirClienteComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot()
  ]
})
export class HomeModule { }
