import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { UserService } from '../service/user.service';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(UserService)
  const isRequestAuthorized = authService.isAuthenticeted && req.url.startsWith('https://localhost:7103')
  let token: string | null = null
  if (typeof window !== 'undefined' && window.localStorage) {
    try {
      const storedSession = localStorage.getItem('appSession');
      token = storedSession ? JSON.parse(storedSession)?.token : null;
    } catch (error) {
      console.error('Error parsing token from localStorage:', error);
    }
  }
  if (isRequestAuthorized && token) {
    const cloneRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
    return next(cloneRequest);
  }

  return next(req);
};
