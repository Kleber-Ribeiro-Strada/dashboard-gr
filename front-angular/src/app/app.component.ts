import { Component } from '@angular/core';
import { WebSocketService } from './services/WebSocketService';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'front-angular';
  
  notifications: any[] = [];

  constructor(private webSocketService: WebSocketService) {}

  ngOnInit() {
    this.webSocketService.getMessages().subscribe((message) => {
      this.notifications = [];
      this.notifications.push(message);
      console.log(message);
    });
  }
}