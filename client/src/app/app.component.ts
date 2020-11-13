import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
//3.23{
  users:any;
//}3.23
//3.23{
  constructor(private http: HttpClient){

  }

  ngOnInit() {
    this.getUsers();
  
  }

  getUsers() {
  this.http.get('https://localhost:5001/api/users').subscribe(response => {
this.users=response;
},
  error =>{
  
  console.log(error);

    })
  }
  //}3.23
}
