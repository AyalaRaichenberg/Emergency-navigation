import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  return next(req).pipe(
    catchError((error) => {
      let errorMessage = 'אירעה שגיאה בלתי צפויה';
      if (error.status === 401) {
        errorMessage = 'אינך מחובר, התחבר מחדש'
        alert(errorMessage)
        router.navigate(['/Login'])
      }
      else if (error.status === 403) {
        errorMessage = 'אין לך הרשאה לצפות במשאב זה'
        alert(errorMessage)
      }
      else if (error.status === 500) {
        errorMessage = 'אירעה שגיאה בלתי צפויה אנא נסה שנית מאוחר יותר'
        alert(errorMessage)
      }

      return throwError(() => new Error(errorMessage));
    })
  )
};

