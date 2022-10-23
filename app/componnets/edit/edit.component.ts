import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/classes/customer';
import { Vaccination } from 'src/app/classes/Vaccination';
import { CustomerService } from 'src/app/services/customer.service';
import { ImgService } from 'src/app/services/img.service';

let form=[];
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  form: FormGroup=new FormGroup({});
  formVaccination: FormGroup=new FormGroup({});
  formAddress: FormGroup=new FormGroup({});
  arr:Array<Vaccination>|any;
  customer:Customer|undefined;
  i:number=0;
  img:string|undefined;
  constructor(private route: ActivatedRoute,private httpClient: HttpClient, private customerService:CustomerService, private router:Router, private imgService:ImgService) { }
  
  
  ngOnInit(): void {
    this.arr=[new Vaccination()];
    this.customer=this.customerService.getCustomer();
    this.i=this.customer?.Count?this.customer?.Count:0;
    this.customerService.emitCustomer.emit();
    this.form = new FormGroup({
      FirstName: new FormControl('', [Validators.required]),
      LastName: new FormControl('', [Validators.required]),
      Id: new FormControl('', [Validators.required,Validators.maxLength(9), Validators.minLength(9)]),
      DateOfBirth: new FormControl('', [Validators.required]),
      Telephone: new FormControl('', [Validators.required,Validators.minLength(9)]),
      Mobile: new FormControl('', [Validators.required,Validators.minLength(10)]),
      Cuvid19Positive: new FormControl('', ),
      Recovery: new FormControl('', ),
    });
    this.formAddress=new FormGroup({
      City: new FormControl('', ),
      Street: new FormControl('', ),
      Number: new FormControl('', ),
    })
    this.formVaccination = new FormGroup({
      ReceivingTheVaccine: new FormControl('', [Validators.required]),
      Manufacturer: new FormControl('', [Validators.required]),     
    })
    this.form.controls["FirstName"].setValue(this.customer?.FirstName);
    this.form.controls["LastName"].setValue(this.customer?.LastName);
    this.form.controls["Id"].setValue(this.customer?.Id);
    this.formAddress.controls["City"].setValue(this.customer?.Address?.City);
    this.formAddress.controls["Street"].setValue(this.customer?.Address?.Street);
    this.formAddress.controls["Number"].setValue(this.customer?.Address?.Number);
    this.form.controls["DateOfBirth"].setValue(this.customer?.DateOfBirth);
    this.form.controls["Telephone"].setValue(this.customer?.Telephone);
    this.form.controls["Mobile"].setValue(this.customer?.Mobile);
    this.form.controls["Cuvid19Positive"].setValue(this.customer?.Cuvid19Positive);
    this.form.controls["Recovery"].setValue(this.customer?.Recovery);
    console.log(this.form);
  }
  addVaccination(){
    if(this.i<4){

      this.arr[this.i]=this.formVaccination.value;
      this.arr[this.i].NumCustomer=this.customer?.NumCustomer;
      this.i++;
      console.log(this.arr);
      this.formVaccination.controls["ReceivingTheVaccine"].setValue(null);
      this.formVaccination.controls["Manufacturer"].setValue(null);
    }

  }
  save(){
    form={...this.form.value }
    form["Img"]=this.imgService.getImg();
    form["Address"]=this.formAddress.value;
    form["Vaccination"]=this.arr;
    console.log(form);
    this.httpClient.post(`https://localhost:44358/api/Customer`,form).subscribe(x=>
    {
      console.log(x);
    },x=>{
      console.log(x);
    },()=>{});
    this.arr=null;  
    this.router.navigateByUrl("/list");
  }

  
}
