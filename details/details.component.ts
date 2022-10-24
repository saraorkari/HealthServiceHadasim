import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/classes/customer';
import { ImgService } from 'src/app/services/img.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  numCustomer: number | undefined;
  Name: string | undefined;
  customer: Customer|undefined;
  // image:File|undefined;
  image:string|undefined;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private img:ImgService) { }

  ngOnInit(): void {
    this.image=this.img.getImg();
    this.route.paramMap.subscribe(x => {
      this.numCustomer = Number(x.get("num"));
      this.Name  = String(x.get("name"));
    })
    this.httpClient.get<Customer>(`https://localhost:44358/api/Customer?num=${this.numCustomer}`).subscribe(x=>
    {
      this.customer=x;
   },x=>{
    console.log("error");
    
   },()=>{});
  }

}
