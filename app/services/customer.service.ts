import { EventEmitter, Injectable } from '@angular/core';
import { Customer } from '../classes/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customer: Customer|any;
  public emitCustomer=new EventEmitter<Customer>();

  constructor() {
    this.emitCustomer.subscribe(x=>{this.customer=x
      console.log("customer");
    })
   }
   getCustomer(){
    return this.customer;
  }
}
