import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  isSidebarOpen = false;

  constructor(private router: Router) {}

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  closeSidebar() {
    this.isSidebarOpen = false;
  }

  navigate() {
    this.router.navigate(['/EmergencyReporting']);
  }

  navigateInEmegrencySituation() {
    this.router.navigate(['/EmergencyNavigation']);
  }

  findDefibrillator() {
    this.router.navigate(['/EmergencyMap'], { queryParams: { eventType: 'sick' } })
  }

  signUp() {
    this.router.navigate(['/SignUp']);
  }

  login() {
    this.router.navigate(['/Login']);
  }
}