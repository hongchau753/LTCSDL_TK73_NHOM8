import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { stringify } from 'querystring';
declare var $:any;

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {

  class:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }

  cls:any={
    id:0,
    name:"",
    startDate:"2020-06-21T03:04:54.464Z",
    price:250,
    teacherId:1,
    courseId:1
  }

  isEdit: boolean = true;

  constructor(
     private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchClass(1);
  }

  searchClass(cPage){
    let x = {
      page:cPage,
      size:5,
      keyword:""
    }

    this.http.post("https://localhost:44355/api/Class/Search-Class",x).subscribe(result => {
      this.class = result;
      this.class = this.class.data;
    }, error => console.error(error));
  }

  searchNext(){
    if(this.class.page < this.class.totalPages){
      let nextPage = this.class.page + 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Class/Search-Class",x).subscribe(result => {
        this.class = result;
        this.class = this.class.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang cuối cùng!")
    }
  }

  searchPrevious(){
    if(this.class.page > 1){
      let nextPage = this.class.page - 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Class/Search-Class",x).subscribe(result => {
        this.class = result;
        this.class = this.class.data;
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
        this.cls ={
          id:0,
          name:"",
          startDate:"",
          price:0,
          teacherId:1,
          courseId:1
      }
    }
    else
    {
      this.isEdit = true;
      this.cls  = index;
    }

    $('#exampleModal').modal("show");
  }

  addClass(name, day, price)
  {
    var x = {
      name: name,
      startDate: day,
      price: Number(price),
      teacherId: 1,
      courseId: 1
    };
    console.log(x )
    this.http.post("https://localhost:44355/api/Class/Create-Class", x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.isEdit = false;
          window.location.reload(); 
          alert("New Class have been added successfully!");
        }
      }, error => console.log(error));
  }

  updateClass()
  {
    var x = this.cls ;
    this.http.post("https://localhost:44355/api/Class/Update-Class",x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.cls = res.data;
          this.isEdit = true;
          alert("New student have been saved successfully!");
        }
      }, error => console.error(error));
  }
  deleteClass(index){
    var r = confirm("Are u sure?");
    if (r==true)
    {
      this.cls = this.class.data[index];
      var x = this.cls;
      this.http.post('https://localhost:44355/' + 'api/Class/Delete-Class/', x)
      .subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.searchClass(1);
          alert("Đã xóa thành công!");
        }
        else {
          alert(res.message);
        }
    }, error => {
      console.error(error);
      alert(error);
    });
    }
  }
}