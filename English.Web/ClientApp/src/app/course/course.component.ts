import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { stringify } from 'querystring';
declare var $:any;

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  [x: string]: any;

  course:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }

  crs: any ={
    id:0,
    lession:0,
    description:"",
    term:1,
  }

  isEdit: boolean = true;

  constructor(
     private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchCourse(1);
  }

  searchCourse(cPage){
    let x = {
      page:cPage,
      size:5,
      keyword:""
    }

    this.http.post("https://localhost:44355/api/Course/Search-Course",x).subscribe(result => {
      this.course = result;
      this.course = this.course.data;
    }, error => console.error(error));
  }

  searchNext(){
    if(this.course.page < this.course.totalPages){
      let nextPage = this.course.page + 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Course/Search-Course",x).subscribe(result => {
        this.course = result;
        this.course = this.course.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang cuối cùng!")
    }
  }

  searchPrevious(){
    if(this.course.page > 1){
      let nextPage = this.course.page - 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Course/Search-Course",x).subscribe(result => {
        this.course = result;
        this.course = this.course.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang đầu tiên!")
    }
  }
  
  openModal(isNew, index)
  {
    if(isNew)
    {
      this.isEdit=false;
        this.crs ={
          id:0,
          lession:0,
          description:"",
          term:"",
      }
    }
    else
    {
      this.isEdit = true;
      this.crs  = index;
    }

    $('#exampleModal').modal("show");
  }

  addCourse(lession, description, term)
  {
    var x = {
      les:lession,
      des:description,
      tr:term,
    };
   
    this.http.post("https://localhost:44355/api/Course/Create-Course", x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.isEdit = true;
          this.searchCourse(1);
          window.location.reload();      
          alert("New course have been added successfully!");
        }
      }, error => console.log(error));
  }

  updateCourse()
  {
    var x = this.course ;
    this.http.post("https://localhost:44355/api/Course/Update-Course",x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.course = res.data;
          this.isEdit = true;
          this.searchCourse(1);
          alert("New course have been saved successfully!");
        }
      }, error => console.error(error));
  }
  deleteCourse(Id)
  {
    this.http.delete('https://localhost:44355/api/Course/Delete-Course',Id).subscribe(
      result => {
       this.crs = result;
      },error => console.error(error));
    
  }
  
  }