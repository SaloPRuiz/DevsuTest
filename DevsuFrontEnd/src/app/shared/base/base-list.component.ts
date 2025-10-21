import { OnInit, Directive } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Directive()
export abstract class BaseListComponent<T> implements OnInit {
  items: T[] = [];
  modalVisible = false;
  mode: 'crear' | 'editar' | 'ver' = 'crear';
  currentId?: number;

  searchValue: string = '';
  private searchSubject = new Subject<string>();

  form!: FormGroup;

  ngOnInit(): void {
    this.loadItems();
    this.searchSubject.pipe(debounceTime(500)).subscribe(value => {
      this.loadItems(value.trim());
    });
  }

  abstract loadItems(search?: string): void;

  onSearchChange(value: string) {
    this.searchSubject.next(value);
  }

  clearSearch() {
    this.searchValue = '';
    this.loadItems();
  }

  openModal(mode: 'crear' | 'editar' | 'ver', item?: T) {
    this.mode = mode;
    this.modalVisible = true;
    this.setModalData(item);
  }

  closeModal() {
    this.modalVisible = false;
    if (this.form) this.form.reset();
  }

  protected abstract setModalData(item?: T): void;
}
