//import { NgModel } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Routes,RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomePageComponent } from './componnets/home-page/home-page.component';
import { ListComponent } from './componnets/list/list.component';
import { EditComponent } from './componnets/edit/edit.component';
import { DetailsComponent } from './componnets/details/details.component';

const routes: Routes = [
  {path:"" ,component:HomePageComponent},
  {path:"list" ,component:ListComponent},
  {path:"edit" ,component:EditComponent},
  {path:"details/:num/:name" ,component:DetailsComponent},
  {path:"edit/:customer" ,component:EditComponent},

  
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
    // RouterModule.forChild(routes)

  ],
  declarations: []
})
export class AppRoutingModule { }
