import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';
  baseUrl = environment.apiUrl;
  constructor(private http:HttpClient){}
  getUser(){
    this.http.get(this.baseUrl+'User').subscribe(res => console.log(res));
  }
}
