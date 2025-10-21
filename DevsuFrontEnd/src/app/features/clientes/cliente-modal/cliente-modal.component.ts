import { Component, Input} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ClienteDto } from '../../../core/models/cliente';
import {BaseModalComponent} from "../../../shared/base/base-modal.component";

@Component({
  selector: 'app-cliente-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cliente-modal.component.html',
  styleUrls: ['../../../shared/styles/shared-modal.css']
})
export class ClienteModalComponent extends BaseModalComponent {
  @Input() cliente?: ClienteDto;
}
