import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-base-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `<ng-content></ng-content>`
})
export class BaseModalComponent {
  @Input() visible = false;
  @Input() form!: FormGroup;
  @Input() mode: 'crear' | 'editar' | 'ver' = 'crear';

  @Output() onSave = new EventEmitter<any>();
  @Output() onClose = new EventEmitter<void>();

  get isViewMode(): boolean {
    return this.mode === 'ver';
  }

  save() {
    if (this.isViewMode) return;

    this.form.markAllAsTouched();

    if (this.form.valid) {
      this.onSave.emit();
    }
  }

  close() {
    this.onClose.emit();
  }
}
