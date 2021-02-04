import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  Employees: Employee[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<Employee[]>('http://localhost:58849/api/Employees').subscribe(result => {
      this.Employees = result;
    }, error => console.error(error));
  }

}

interface Employee {
  name: string;
  surname: string;
  position: string;
  salary: Float32Array;
}  
