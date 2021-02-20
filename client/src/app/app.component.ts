import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';
  constructor(private http:HttpClient){}
  getUSerName(){
    this.http.get('https://localhost:5001/User').subscribe(res=>console.log(res));
  }
}
