import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { errorInterceptor } from './interceptor/error.interceptor';
import { tokenInterceptor } from './interceptor/token.interceptor';
import { CommonModule } from '@angular/common';

export const appConfig: ApplicationConfig = {
  providers: [
    importProvidersFrom(
      FormsModule ,CommonModule ,
    ),
    provideRouter(routes),
    provideClientHydration(),
    provideHttpClient(withInterceptors([tokenInterceptor, errorInterceptor]))
  ]}
 