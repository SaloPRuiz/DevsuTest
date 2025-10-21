import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from '../../../core/services/cliente.service';
import { ClienteDto } from '../../../core/models/cliente';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteModalComponent} from "../cliente-modal/cliente-modal.component";

@Component({
  selector: 'app-cliente-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ClienteModalComponent],
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  clientes: ClienteDto[] = [];
  form: FormGroup;
  modalVisible = false;
  mode: 'crear' | 'editar' | 'ver' = 'crear';
  currentId?: number;

  constructor(private clienteService: ClienteService, private fb: FormBuilder) {
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

  ngOnInit() {
    this.loadClientes();
  }

  loadClientes() {
    this.clienteService.getAll().subscribe(data => this.clientes = data);
  }

  openModal(mode: 'crear' | 'editar' | 'ver', cliente?: ClienteDto) {
    this.mode = mode;
    this.modalVisible = true;

    if (cliente) {
      this.currentId = cliente.clienteId;
      this.form.patchValue(cliente);
      if (mode === 'ver') this.form.disable();
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
        this.loadClientes();
        this.closeModal();
      });
    } else {
      this.clienteService.create(data).subscribe(() => {
        this.loadClientes();
        this.closeModal();
      });
    }
  }

  delete(clienteId: number) {
    if (confirm('¿Eliminar este cliente?')) {
      this.clienteService.delete(clienteId).subscribe(() => this.loadClientes());
    }
  }

  closeModal() {
    this.modalVisible = false;
    this.form.reset();
  }
}
