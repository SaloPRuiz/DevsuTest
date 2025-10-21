import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup } from '@angular/forms';
import { ClienteDto } from '../../../core/models/cliente';

@Component({
  selector: 'app-cliente-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cliente-modal.component.html',
  styleUrls: ['./cliente-modal.component.css']
})
export class ClienteModalComponent {
  @Input() visible = false;
  @Input() form!: FormGroup;
  @Input() mode: 'crear' | 'editar' | 'ver' = 'crear';
  @Input() cliente?: ClienteDto;

  @Output() onSave = new EventEmitter<void>();
  @Output() onClose = new EventEmitter<void>();

  get isViewMode(): boolean {
    return this.mode === 'ver';
  }

  save() {
    if (!this.isViewMode) this.onSave.emit();
  }

  close() {
    this.onClose.emit();
  }
}
