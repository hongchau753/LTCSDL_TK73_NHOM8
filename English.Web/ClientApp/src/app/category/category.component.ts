import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  public res: any;
  public lstCategory: [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post('https://localhost:44355/' + 'api/Category/get-all',null).subscribe(result => {
      this.res = result;
      this.lstCategory = this.res.data;
      console.log(this.lstCategory);
    }, error => console.error(error));
  }
    
  ngOnInit() {
    
  }
}