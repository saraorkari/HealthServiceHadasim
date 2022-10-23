import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/classes/customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  arr:Customer[]=[];
  constructor(private httpClient:HttpClient,private customerService:CustomerService) { }

  delete(num?:number){
    this.httpClient.delete(`https://localhost:44358/api/Customer?num=${num}`).subscribe(x=>
    {
      this.ngOnInit();
   },x=>{
    console.log("error");
    
   },()=>{});

  }
  emit(item:Customer){
    this.customerService.emitCustomer.emit(item);
  }
  ngOnInit(): void {
    this.httpClient.get<Customer[]>(`https://localhost:44358/api/Customer`).subscribe(x=>
    {
      this.arr=x;
   },x=>{
    console.log("error");
    
   },()=>{});
  }

}
