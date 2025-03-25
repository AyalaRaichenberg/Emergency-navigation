import { Component } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';
import { User } from '../models/user.model';
import { FormsModule } from '@angular/forms';
import { UserService } from '../service/user.service';
import { BuildingService } from '../service/building.service';
import { CommonModule } from '@angular/common';
import { VertexService } from '../service/vertex.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {
  buildings: any[] = [];
  verties: any[] = [];
  part: number = 1;
  buildingId: number = 0;
  numberOfFloor: number = 0;
  floorNumber: number = 0;
  user: User = { id: 0, name: '', email: '', password: '', usualLocalId: 0, isParamedic: false };
  errorMessage: string = '';

  constructor(
    private userService: UserService,
    private buildingService: BuildingService,
    private vertexService: VertexService,
    private router:Router

  ) { }

  ngOnInit(): void {
    this.buildingService.getBuildingsServer().subscribe((data) => {
      console.log('builings: ', data.$values);

      this.buildings = data.$values;
    });
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    console.log(this.user);
    this.userService.addUserServer(this.user).subscribe((data) => {
      console.log('Response:', data);
      this.router.navigate(['/Login'])
    });
  }

  send() {
    this.errorMessage = '';
    if (this.part === 1) {
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!emailPattern.test(this.user.email)) {
        this.errorMessage = 'כתובת אימייל אינה תקינה';
        return;
      }
      if (this.user.name.length < 2) {
        this.errorMessage = 'השם חייב להיות לפחות 2 תווים';
        return;
      }
      if (this.user.password.length < 4) {
        this.errorMessage = 'הסיסמה חייבת להיות לפחות 4 תווים';
        return;
      }
    }
    this.part += 1;
    if (this.part === 3) {
      const building = this.buildings.find(b => b.id === this.buildingId);
      if (building) {
        this.numberOfFloor = building.numberOfFloor;
      }
    }

    if (this.part === 4) {
      this.vertexService.getVertesListByFloorAndBuilding(this.buildingId, this.floorNumber)
        .subscribe((data) => {
          this.verties = data.$values;
        });
    }
  }
}