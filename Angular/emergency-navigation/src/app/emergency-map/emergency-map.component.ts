import { Component, OnInit } from '@angular/core';
import { Vertex } from '../models/vertex.model';
import { NavigationService } from '../service/navigation.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../service/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-emergency-map',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './emergency-map.component.html',
  styleUrls: ['./emergency-map.component.css']
})
export class EmergencyMapComponent implements OnInit {
  path: any;
  userVertex!: Vertex;
  eventType: string = '';
  currentFloorIndex: number = 0;
  floorsSteps: { floorId: number, steps: any[] }[] = [];

  constructor(
    private route: ActivatedRoute,
    private _navigationService: NavigationService,
    private _userService: UserService
  ) { }

  ngOnInit(): void {
    const session = localStorage.getItem('appSession');
    if (session) {
      const userSession = JSON.parse(session);
      this.userVertex = userSession.user.usualLocal;
      console.log("User vertex from session:", this.userVertex);
    } else {
      console.log('לא נמצא משתמש מחובר');
      return;
    }

    this.route.queryParams.subscribe(params => {
      this.eventType = params['eventType'];
      this.fetchPath(this.userVertex, this.eventType);
    });
  }

  fetchPath(vertex: Vertex, eventType: string): void {
    let fetchObservable;

    switch (eventType) {
      case 'fire':
        fetchObservable = this._navigationService.getNavigionFierServer(vertex.id);
        break;
      case 'terroristInfiltration':
        fetchObservable = this._navigationService.getNavigionTerroristInfiltrationServer(vertex.id);
        break;
      case 'flood':
        fetchObservable = this._navigationService.getNavigionFloodServer(vertex.id);
        break;
      case 'sick':
        fetchObservable = this._navigationService.getNavigationSickServer(vertex.id);
        break;
      case 'alarms':
        fetchObservable = this._navigationService.getNavigionAlarmsServer(vertex.id);
        break;
      case 'poison':
        fetchObservable = this._navigationService.getNavigionTerroristInfiltrationServer(vertex.id);
        break;
      case 'earthquake':
        fetchObservable = this._navigationService.getNavigionFierServer(vertex.id);
        break;
      default:
        console.log('Unknown event type');
        return;
    }

    fetchObservable.subscribe(
      (data) => {
        this.path = data;
        console.log("Path received:", data);// אחרי שמתקבל נתיב - מחלקים לפי קומות
      },
      (error) => {
        console.error('Error fetching path:', error);
      }
    );
  }

  // splitPathByFloor(): void {
  //   const grouped: { [key: number]: any[] } = {};

  //   this.path.navigation.forEach((step:any) => {
  //     if (!grouped[step.floorId]) {
  //       grouped[step.floorId] = [];
  //     }
  //     grouped[step.floorId].push(step);
  //   });

  //   this.floorsSteps = Object.keys(grouped).map(key => ({
  //     floorId: +key,
  //     steps: grouped[+key]
  //   }));
  // }
}

