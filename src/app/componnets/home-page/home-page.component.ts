import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
count:number|undefined;
  constructor(private httpClient:HttpClient) { }
Count(){
  this.httpClient.get<number>(`https://localhost:44358/api/Customer?flag=${true}`).subscribe(x=>
  {
    this.count=x;
 },x=>{
  console.log("error");
  
 },()=>{});
}
  ngOnInit(): void {
  }

}
