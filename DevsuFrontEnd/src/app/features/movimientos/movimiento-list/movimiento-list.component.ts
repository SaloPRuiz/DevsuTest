import { Component } from '@angular/core';
import {FormBuilder, FormsModule, Validators} from '@angular/forms';
import { CuentaDto } from '../../../core/models/cuenta';
import {CommonModule} from "@angular/common";
import {BaseListComponent} from "../../../shared/base/base-list.component";
import {MovimientoDto} from "../../../core/models/movimiento";
import {CuentaService} from "../../../core/services/cuenta.service";
import {MovimientoService} from "../../../core/services/movimiento.service";
import {TipoMovimientoDto} from "../../../core/models/tipo-movimiento";
import {MovimientoModalComponent} from "../movimiento-modal/movimiento-modal.component";
import {MovimientoDescripcionPipe} from "../../../core/pipes/movimiento-descripcion.pipe";

@Component({
  selector: 'app-movimiento-list',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    MovimientoModalComponent,
    MovimientoDescripcionPipe
  ],
  templateUrl: './movimiento-list.component.html',
  styleUrls: ['../../../shared/styles/shared-table.css'],
})
export class MovimientoListComponent extends BaseListComponent<MovimientoDto>{
  cuentas: CuentaDto[] = [];
  tiposMovimiento: TipoMovimientoDto[] = [];

  constructor(
    private movimientoService: MovimientoService,
    private cuentaService: CuentaService,
    private fb: FormBuilder,
  ) {
    super();
    this.form = this.fb.group({
      fechaMovimiento: ['', Validators.required],
      tipoMovimientoId: [null, Validators.required],
      valor: [null, [Validators.required, Validators.min(0.01)]],
      cuentaId: [null, Validators.required]
    });
  }

  loadItems(search?: string): void {
    this.movimientoService.getAll(search).subscribe({
      next: (data) => this.items = data,
      error: (err) => console.error('Error al cargar cuentas', err)
    });
  }

  loadTiposMovimiento(): void {
    this.movimientoService.getTiposMovimiento().subscribe({
      next: data => this.tiposMovimiento = data,
      error: err => console.error('Error al cargar tipos de cuenta', err)
    });
  }

  loadCuentas(): void {
    this.cuentaService.getAll().subscribe({
      next: data => this.cuentas = data,
      error: err => console.error('Error al cargar clientes', err)
    });
  }

  override openModal(mode: 'crear' | 'editar' | 'ver', item?: MovimientoDto): void {
    this.mode = mode;
    this.loadTiposMovimiento();
    this.loadCuentas();

    this.setModalData(item);
    this.modalVisible = true;
  }

  protected setModalData(item?: MovimientoDto): void {
    if (item) {
      this.currentId = item.movimientoId;
      const formValue = { ...item };

      if (item.fechaMovimiento) {
        formValue.fechaMovimiento = item.fechaMovimiento.split('T')[0];
      }

      this.form.patchValue(formValue);
      if (this.mode === 'ver') this.form.disable();
      else this.form.enable();
    } else {
      this.currentId = undefined;
      this.form.reset();
      this.form.enable();
    }
  }

  save() {
    const data = this.form.value as MovimientoDto;

    if (this.mode === 'editar' && this.currentId) {
      this.movimientoService.update(this.currentId, data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    } else {
      this.movimientoService.create(data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    }
  }
}
