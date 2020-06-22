import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { SigninComponent } from './signin/signin.component';
import { CategoryComponent } from './category/category.component';
import { ClassComponent } from './class/class.component';
import { WeekdayComponent } from './weekday/weekday.component';
import { StudentComponent } from './student/student.component';
import { CourseComponent } from './course/course.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CourseComponent,
    SigninComponent,
    CategoryComponent,
    ClassComponent,
    WeekdayComponent,
    StudentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'course', component: CourseComponent },
      { path: 'category', component: CategoryComponent },      
      { path: 'signin', component: SigninComponent },
      { path: 'class', component: ClassComponent },
      { path: 'weekday', component: WeekdayComponent },
      { path: 'student', component: StudentComponent },
 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
