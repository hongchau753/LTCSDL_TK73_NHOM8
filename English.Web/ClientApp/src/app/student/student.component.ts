import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  student:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }

  stu:any ={
    id:0,
    fullname:"Tran Xuan Truc",
    email:"xuantruc1099@gmail.com",
    phone:"0365848539"
  }

  isEdit: boolean = true;

  constructor(
     private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchStudent(1);
  }

  searchStudent(cPage){
    let x = {
      page:cPage,
      size:5,
      keyword:""
    }

    this.http.post("https://localhost:44355/api/Student/Search-Student",x).subscribe(result => {
      this.student = result;
      this.student = this.student.data;
    }, error => console.error(error));
  }

  searchNext(){
    if(this.student.page < this.student.totalPages){
      let nextPage = this.student.page + 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Student/Search-Student",x).subscribe(result => {
        this.student = result;
        this.student = this.student.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang cuối cùng!")
    }
  }

  searchPrevious(){
    if(this.student.page > 1){
      let nextPage = this.student.page - 1;
      let x = {
        page:nextPage,
        size:5,
        keyword:""
      }
  
      this.http.post("https://localhost:44355/api/Student/Search-Student",x).subscribe(result => {
        this.student = result;
        this.student = this.student.data;
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
        this.stu ={
        id:0,
        fullname:"",
        email:"",
        phone:""
      }
    }
    else
    {
      this.isEdit = true;
      this.stu = index;
    }

    $('#exampleModal').modal("show");
  }

  addStudent()
  {
    var x = this.stu;
    this.http.post("https://localhost:44355/api/Student/Create-Student",x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.stu = res.data;
          this.isEdit = true;
          this.searchStudent(1);
          alert("New student have been added successfully!");
        }
      }, error => console.error(error));
  }

  updateStudent()
  {
    var x = this.stu;
    this.http.post("https://localhost:44355/api/Student/Update-Student",x).subscribe(result => 
      {
        var res:any = result;
        if(res.success)
        {
          this.stu = res.data;
          this.isEdit = true;
          this.searchStudent(1);
          alert("New student have been saved successfully!");
        }
      }, error => console.error(error));
  }

  
}