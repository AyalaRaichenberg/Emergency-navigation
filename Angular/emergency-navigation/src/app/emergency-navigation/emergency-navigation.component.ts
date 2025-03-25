import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emergency-navigation',
  imports: [],
  templateUrl: './emergency-navigation.component.html',
  styleUrl: './emergency-navigation.component.css'
})
export class EmergencyNavigationComponent {
  constructor(private router: Router) { }
  display(eventType: string) {
    this.router.navigate(['/EmergencyMap'], { queryParams: { eventType: eventType } });
  }
}
