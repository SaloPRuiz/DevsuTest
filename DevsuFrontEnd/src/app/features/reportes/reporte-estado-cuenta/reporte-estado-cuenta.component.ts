import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {ReporteService} from "../../../core/services/reporte.service";
import {ClienteService} from "../../../core/services/cliente.service";
import {CommonModule, CurrencyPipe, DatePipe} from "@angular/common";
import {ClienteDto} from "../../../core/models/cliente";
import {ReporteEstadoCuentaDto} from "../../../core/models/reporte-estado-cuenta.model";
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-reporte-estado-cuenta',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, CurrencyPipe, DatePipe],
  templateUrl: './reporte-estado-cuenta.component.html',
  styleUrls: ['../../../shared/styles/shared-table.css', '../../../shared/styles/shared-modal.css'],
})
export class ReporteEstadoCuentaComponent implements OnInit {
  form!: FormGroup;
  clientes: ClienteDto[] = [];
  reporte: ReporteEstadoCuentaDto[] = [];

  constructor(
    private reporteService: ReporteService,
    private clienteService: ClienteService,
    private fb: FormBuilder,
  ) {

  }
  ngOnInit(): void {
    this.form = this.fb.group({
      clienteId: [null, Validators.required],
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required],
    });

    this.loadClientes();
  }

  loadClientes(): void {
    this.clienteService.getAll().subscribe({
      next: (data) => this.clientes = data,
      error: (err) => console.error('Error al cargar clientes', err)
    });
  }

  buscar(): void {
    if (this.form.invalid) return;
    const { clienteId, fechaInicio, fechaFin } = this.form.value;
    this.reporteService.getReporteEstadoCuenta(clienteId, fechaInicio, fechaFin).subscribe({
      next: (data) => {
        this.reporte = data;
      },
      error: (err) => {
        console.error('Error al obtener reporte', err);;
      }
    });
  }

  descargarPdf(): void {
    const { clienteId, fechaInicio, fechaFin } = this.form.value;

    this.reporteService.getReporteEstadoCuentaPdf(clienteId, fechaInicio, fechaFin).subscribe({
      next: (base64) => {
        console.log("gagaga")
        console.log(JSON.parse(JSON.stringify(base64)));

        const byteCharacters = atob(base64);
        const byteNumbers = new Array(byteCharacters.length).fill(0).map((_, i) => byteCharacters.charCodeAt(i));
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: 'application/pdf' });
        saveAs(blob, `ReporteEstadoCuenta_${clienteId}.pdf`);
      },
      error: (err) => console.error('Error al descargar PDF', err)
    });
  }
}
