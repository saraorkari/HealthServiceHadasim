import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';
import { CustomerService } from './customer.service';
import { Customer } from '../classes/customer';

@Injectable({
  providedIn: 'root'
})
export class ImgService {
  img:File|undefined
  image: string ="";
  customer:Customer|undefined;
  constructor() { }
  addImg(image: File) {
    // this.imgData?.append("image", image, 'newImgTitle');
    this.img=image;
    // console.log(this.imgData);

  }
  getImg(){
    return this.img?.name;
  }
}
