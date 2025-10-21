import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuentaModalComponent } from './cuenta-modal.component';

describe('CuentaModalComponent', () => {
  let component: CuentaModalComponent;
  let fixture: ComponentFixture<CuentaModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuentaModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuentaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
