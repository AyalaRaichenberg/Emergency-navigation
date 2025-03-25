import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
@Component({
  selector: 'app-manager-component',
  imports: [],
  templateUrl: './manager-component.component.html',
  styleUrl: './manager-component.component.css'
})
export class ManagerComponent implements OnInit {
  private hubConnection: HubConnection | undefined;
  alertMessage: string | null = null;

  ngOnInit() {
    this.startSignalRConnection();
  }

  startSignalRConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7103/alertHub')  // כתובת ה-API שלך ל-Hub
      .build();

    this.hubConnection.start()
      .then(() => console.log('Connected to SignalR Hub!'))
      .catch(err => console.error('Error while starting connection: ' + err));

    // האזנה להתראה
    this.hubConnection.on('ReceiveAlert', (alertData) => {
      this.alertMessage = `🚨 Alert! Type: ${alertData.alertType}, Location: Room ${alertData.dangerLocation.roomNumber}, Floor: ${alertData.dangerLocation.floorId}`;
      console.log(this.alertMessage);
    });
  }
}