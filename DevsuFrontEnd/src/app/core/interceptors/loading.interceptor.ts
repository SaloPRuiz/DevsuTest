import { inject } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';
import { finalize } from 'rxjs';
import { SpinnerService } from '../services/spinner.service';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const spinnerService = inject(SpinnerService);

  spinnerService.show();

  return next(req).pipe(
    finalize(() => spinnerService.hide())
  );
};
