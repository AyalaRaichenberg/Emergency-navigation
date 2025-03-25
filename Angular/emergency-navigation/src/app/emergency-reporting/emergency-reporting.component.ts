import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Building } from '../models/building.model';
import { VertexService } from '../service/vertex.service';
import { CommonModule } from '@angular/common';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';  // הוספת הייבוא של SignalR
import { FloorService } from '../service/floor.service';

@Component({
  selector: 'app-emergency-reporting',
  imports: [FormsModule, CommonModule],
  templateUrl: './emergency-reporting.component.html',
  styleUrls: ['./emergency-reporting.component.css']
})
export class EmergencyReportingComponent implements OnInit {
  part: number = 1;    
  myfloorId:number=0
  vertices:any[]=[]
  floorId:number=0;
  floors: any[] = [];
  emergencyModel: any = { "type": "", "locationId": 0 };
  private hubConnection: HubConnection | undefined;

  constructor(private _vertexService: VertexService,private _floorService:FloorService
  ) { }

  ngOnInit(): void {
    this.startSignalRConnection();  

    if (typeof window !== 'undefined' && window.localStorage) {
      try {
        const storedSession = localStorage.getItem('appSession');
       this.myfloorId = storedSession ? JSON.parse(storedSession)?.user.usualLocal.floorId : 0;  
      } catch (error) {
        console.error('Error parsing user from localStorage:', error);
      }
    }
    
    this._floorService.getFloorByIdServer(this.myfloorId).subscribe((data)=>{this.floors=data.$values
      console.log(this.floors);
      
    })

  }

  startSignalRConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7103/alertHub')  
      .build();

    this.hubConnection.start()
      .then(() => console.log('Connected to SignalR Hub!'))
      .catch(err => console.error('Error while starting connection: ' + err));
  }

  onRoomSelect(vertexId: number) {
    this.emergencyModel.locationId = vertexId;
    console.log("🔹 Room Selected:", this.emergencyModel.locationId.roomNumber);
  }
  send() {
    this.part += 1;
    if(this.part===3){
      this._floorService.getFloorById(this.floorId).subscribe((data)=>{this.vertices=data.vertices.$values
        console.log(data);
        
      })
    }
  }

  sendAlert() {
    if (!this.emergencyModel.type) {
      alert("יש לבחור סוג חירום!");
      return;
    }

    const alertData = {
      alertType: this.emergencyModel.type,
      dangerLocation: {
        id: this.emergencyModel.locationId.id,
        roomNumber:this.emergencyModel.locationId.roomNumber,
        floorId: this.floorId,
        buildingId: this.floors[0].buildingId
      }
    };

    console.log("🚀 Sending alert request to API:", alertData);

    this._vertexService.sendAlert(alertData).subscribe(
      response => {
        console.log("✅ Alert sent successfully!", response);
      },
      error => {
        console.error("❌ Error sending alert:", error);
      }
    );
  }

  onSubmit(event: Event) {
    event.preventDefault();
    console.log(this.emergencyModel);
    this.sendAlert();

    if (this.hubConnection) {
      const alertData = {
        alertType: this.emergencyModel.type,
        dangerLocation: {
          id: this.emergencyModel.locationId.id,
          roomNumber:this.emergencyModel.locationId.roomNumber,
          floorId: this.floorId,
          buildingId: this.floors[0].buildingId
        }
      };

      this.hubConnection.send('SendAlertToManager', 1, this.floors[0].buildingId, alertData.alertType, alertData.dangerLocation)
        .then(() => console.log('📡 Alert sent to manager via SignalR!'))
        .catch(err => console.error('❌ Error sending alert via SignalR:', err));
    }
  }
}
