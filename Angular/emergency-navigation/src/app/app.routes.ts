import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { NavComponent } from './nav/nav.component';
import { EmergencyReportingComponent } from './emergency-reporting/emergency-reporting.component';
import {EmergencyNavigationComponent}from './emergency-navigation/emergency-navigation.component'
import { EmergencyMapComponent } from './emergency-map/emergency-map.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    { path: '', component: NavComponent },
    { path: 'SignUp', component: SignUpComponent },
    { path: 'Login', component: LoginComponent },
    { path: 'EmergencyReporting', component: EmergencyReportingComponent },
    { path: 'EmergencyNavigation', component: EmergencyNavigationComponent },
    {path:'EmergencyMap',component:EmergencyMapComponent},
    {path:'Home',component:HomeComponent}
];