import { Component, Input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClienteDto } from '../../../core/models/cliente';
import { TipoCuentaDto } from '../../../core/models/tipo-cuenta';
import {BaseModalComponent} from "../../../shared/base/base-modal.component";
import {CuentaDto} from "../../../core/models/cuenta";

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
  @Input() cuenta?: CuentaDto;
}
