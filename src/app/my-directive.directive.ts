import { Directive, ElementRef, HostListener, Input } from '@angular/core';


@Directive({
  selector: '[appMyDirective]'
})
export class MyDirectiveDirective {

  @Input()
  mycolor:string;
  
  constructor(private el:ElementRef) { 
    this.el.nativeElement.style.backgroundColor='yellow';
   }

@HostListener('mouseover')
OnMouseOver(){
  this.el.nativeElement.style.backgroundColor=this.mycolor;
}
@HostListener('mouseleave')
OnMouseLeave(){
  this.el.nativeElement.style.fontSize='30px';
}


}
