import { Component } from '@angular/core';
import {FormBuilder, FormsModule, Validators} from '@angular/forms';
import { CuentaDto } from '../../../core/models/cuenta';
import { CuentaService } from '../../../core/services/cuenta.service';
import { BaseListComponent } from '../../../shared/base/base-list.component';
import {CurrencyPipe} from "@angular/common";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cuenta-list',
  standalone: true,
  imports: [
    CurrencyPipe,
    FormsModule,
    CommonModule
  ],
  templateUrl: './cuenta-list.component.html',
  styleUrls: ['../../../shared/styles/shared-table.css'],
})
export class CuentaListComponent extends BaseListComponent<CuentaDto> {

  constructor(private cuentaService: CuentaService, private fb: FormBuilder) {
    super();
    this.form = this.fb.group({
      numeroCuenta: ['', Validators.required],
      tipoCuentaId: [null, Validators.required],
      saldoInicial: [0, Validators.required],
      estado: [true]
    });
  }

  loadItems(search?: string): void {
    this.cuentaService.getAll(search).subscribe({
      next: (data) => this.items = data,
      error: (err) => console.error('Error al cargar cuentas', err)
    });
  }

  protected setModalData(item?: CuentaDto): void {
    if (item) {
      this.currentId = item.cuentaId;
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
    const data = this.form.value as CuentaDto;
    if (this.mode === 'editar' && this.currentId) {
      this.cuentaService.update(this.currentId, data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    } else {
      this.cuentaService.create(data).subscribe(() => {
        this.loadItems();
        this.closeModal();
      });
    }
  }

  delete(cuentaId: number) {
    if (confirm('¿Eliminar esta cuenta?')) {
      this.cuentaService.delete(cuentaId).subscribe(() => this.loadItems());
    }
  }
}
