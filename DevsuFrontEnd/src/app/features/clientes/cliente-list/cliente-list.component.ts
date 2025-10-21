import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from '../../../core/services/cliente.service';
import { ClienteDto } from '../../../core/models/cliente';
import {ReactiveFormsModule, FormBuilder, Validators, FormsModule} from '@angular/forms';
import { ClienteModalComponent} from "../cliente-modal/cliente-modal.component";
import {BaseListComponent} from "../../../shared/base/base-list.component";

@Component({
  selector: 'app-cliente-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ClienteModalComponent, FormsModule],
  templateUrl: './cliente-list.component.html',
  styleUrls: ['../../../shared/styles/shared-table.css'],
})
export class ClienteListComponent extends BaseListComponent<ClienteDto> {

  constructor(private clienteService: ClienteService, private fb: FormBuilder) {
    super();
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      genero: [false],
      edad: [null],
      identificacion: ['', Validators.required],
      direccion: [''],
      telefono: [''],
      contrasena: ['', Validators.required]
    });
  }

  loadItems(search?: string) {
    this.clienteService.getAll(search).subscribe({
      next: (data) => this.items = data,
      error: (err) => console.error('Error al cargar clientes', err)
    });
  }

  protected setModalData(item?: ClienteDto) {
    if (item) {
      this.currentId = item.clienteId;
      this.form.patchValue(item);
      if (this.mode === 'ver') this.form.disable();
      else this.form.enable();
    } else {
      this.currentId = undefined;
      this.form.reset();
      this.form.enable();
    }
  }

  save() {
    const data = this.form.value as ClienteDto;

    if (this.mode === 'editar' && this.currentId) {
      this.clienteService.update(this.currentId, data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    } else {
      this.clienteService.create(data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    }
  }

  delete(clienteId: number) {
    if (confirm('¿Eliminar este cliente?')) {
      this.clienteService.delete(clienteId).subscribe(() => this.loadItems());
    }
  }
}
