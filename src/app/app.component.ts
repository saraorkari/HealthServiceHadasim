import { Component, Directive, HostListener } from '@angular/core';
import { NavigationService } from './services/navigation.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
})
export class AppComponent 
{
  constructor(private navigation: NavigationService) {}
  back(){
    this.navigation.back();
    
  }  
}
 