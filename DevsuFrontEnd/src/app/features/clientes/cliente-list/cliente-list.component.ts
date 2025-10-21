import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from '../../../core/services/cliente.service';
import { ClienteDto } from '../../../core/models/cliente';
import {ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormsModule} from '@angular/forms';
import { ClienteModalComponent} from "../cliente-modal/cliente-modal.component";
import {debounceTime, Subject} from "rxjs";

@Component({
  selector: 'app-cliente-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ClienteModalComponent, FormsModule],
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  clientes: ClienteDto[] = [];
  form: FormGroup;
  modalVisible = false;
  mode: 'crear' | 'editar' | 'ver' = 'crear';
  currentId?: number;
  searchValue: string = '';
  private searchSubject = new Subject<string>();

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

    this.searchSubject.pipe(debounceTime(500)).subscribe(value => {
      this.loadClientes(value.trim());
    });
  }

  loadClientes(search?: string) {
    this.clienteService.getAll(search).subscribe({
      next: (data) => this.clientes = data,
      error: (err) => console.error('Error al cargar clientes', err)
    });
  }

  onSearchChange(value: string) {
    this.searchSubject.next(value);
  }

  clearSearch() {
    this.searchValue = '';
    this.loadClientes();
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
