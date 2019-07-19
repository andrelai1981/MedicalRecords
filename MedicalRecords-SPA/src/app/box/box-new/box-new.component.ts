import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-box-new',
  templateUrl: './box-new.component.html',
  styleUrls: ['./box-new.component.css']
})
export class BoxNewComponent implements OnInit {
  @Output() cancelNewBox = new EventEmitter();
  counties: any;
  departments: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCounties();
    this.getDepartments();
  }
  getCounties() {
    this.http.get('http://localhost:5000/api/counties').subscribe(response => {
      this.counties = response;
    }, error => {
      console.log(error);
    });
  }

  getDepartments() {
    this.http.get('http://localhost:5000/api/departments').subscribe(response => {
      this.departments = response;
    }, error => {
      console.log(error);
    });
  }

  // addBox() {
  //   this.authService
  // }

  cancel() {
    this.cancelNewBox.emit(false);
    console.log('cancelled');
  }
}
