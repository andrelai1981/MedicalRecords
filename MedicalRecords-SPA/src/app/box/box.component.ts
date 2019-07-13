import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.css']
})
export class BoxComponent implements OnInit {

  boxes: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBoxes();
  }

  getBoxes() {
    this.http.get('http://localhost:5000/api/boxes').subscribe(response => {
      this.boxes = response;
    }, error => {
      console.log(error);
    });
  }
}
