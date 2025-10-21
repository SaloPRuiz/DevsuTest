import { Component, Input } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClienteDto } from '../../../core/models/cliente';
import { TipoCuentaDto } from '../../../core/models/tipo-cuenta';
import {BaseModalComponent} from "../../../shared/base/base-modal.component";

@Component({
  selector: 'app-cuenta-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cuenta-modal.component.html',
  styleUrls: ['../../../shared/styles/shared-modal.css']
})
export class CuentaModalComponent extends BaseModalComponent {
  @Input() clientes: ClienteDto[] = [];
  @Input() tiposCuenta: TipoCuentaDto[] = [];

  constructor(private fb: FormBuilder) {
    super();
    this.form = this.fb.group({
      clienteId: [null, Validators.required],
      tipoCuentaId: [null, Validators.required],
      numeroCuenta: ['', Validators.required],
      saldoInicial: [0, Validators.required],
      estado: [true]
    });
  }
}
