import { Component, OnInit, TemplateRef } from '@angular/core';
import { HomeService } from './home.service';
import { Cliente } from 'src/app/Models/Cliente';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  public clientes: Array<Cliente>;
  public cliente = new Cliente();
  public modalRef: BsModalRef;

  constructor(private homeService: HomeService, private modalService: BsModalService) { }

  ngOnInit() {
    this.getClientes();
  }

  private getClientes(): void {
    this.homeService.getClientList().subscribe(clientes => this.clientes = clientes);
  }

  public insertModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  public detailModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  public detail(item: Cliente): void {
    this.cliente = item;
  }

  public editModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  public edit(item: Cliente): void {
    this.modalRef.content = item;
    console.log('after', this.modalRef.content);
    // this.cliente = item;
  }

  public editClientePut() {
    this.modalRef.hide();
    this.homeService.putCliente(this.cliente.Id, this.cliente).subscribe();
  }

  public deleteModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  public inserirClientePost(): void {
    this.modalRef.hide();
    this.homeService.postCliente(this.cliente).subscribe();
  }
}
