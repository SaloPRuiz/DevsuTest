import {Component, Input} from '@angular/core';
import {CommonModule} from "@angular/common";
import {ReactiveFormsModule} from "@angular/forms";
import {BaseModalComponent} from "../../../shared/base/base-modal.component";
import {MovimientoDto} from "../../../core/models/movimiento";
import {CuentaDto} from "../../../core/models/cuenta";
import {TipoMovimientoDto} from "../../../core/models/tipo-movimiento";

@Component({
  selector: 'app-movimiento-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './movimiento-modal.component.html',
  styleUrls: ['../../../shared/styles/shared-modal.css']
})
export class MovimientoModalComponent extends BaseModalComponent {
  @Input() cuentas: CuentaDto[] = [];
  @Input() tiposMovimiento: TipoMovimientoDto[] = [];
  @Input() movimiento?: MovimientoDto;
}
