import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weekday',
  templateUrl: './weekday.component.html',
  styleUrls: ['./weekday.component.css']
})
export class WeekdayComponent implements OnInit {

  weekday:any ={
    data:[],
    totalRecord:0,
    page:1,
    size:2,
    totalPages:0

  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchweekday(1);
  }
  searchweekday(cPage){
    let x={
      page:cPage,
      size:7,
      keyword:" "
    } 
  
  this.http.post('https://localhost:44355/api/Weekday/Search-Weekday',x).subscribe(result => {
      this.weekday = result;
      this.weekday = this.weekday.data;
      console.log(this.weekday);
    }, error => console.error(error));
  }

}
