import { inject } from '@angular/core';
import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { NotificationService} from "../services/notification.service";

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const notificationService = inject(NotificationService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      let message = 'Error desconocido, intenta más tarde.';

      if (error.error instanceof ErrorEvent) {
        message = `Error: ${error.error.message}`;
      } else {
        switch (error.status) {
          case 0:
            message = 'No se pudo conectar con el servidor.';
            break;
          case 400:
            message = 'Petición incorrecta (400).';
            break;
          case 404:
            message = 'Recurso no encontrado (404).';
            break;
          case 500:
            message = 'Error interno del servidor (500).';
            break;
        }
      }

      notificationService.showError(message);
      return throwError(() => error);
    })
  );
};
