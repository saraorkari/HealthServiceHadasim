import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http'

import { RouterModule } from '@angular/router';
import { arrPath } from './ArrPath';
import { AppRoutingModule } from './app-routing.module';

//material
import { MatSliderModule } from '@angular/material/slider';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatDatepickerModule} from '@angular/material/datepicker';

// import { MatTabGroup} from '@angular/material/tabs';
// import { MatTab} from '@angular/material/tabs';
// import {DataSource} from '@angular/cdk/collections';
import {MatBottomSheet, MatBottomSheetRef} from '@angular/material/bottom-sheet';
import {MatTableModule} from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSelect, MatSelectModule } from '@angular/material/select';
import { MatOption, MatOptionModule } from '@angular/material/core';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { HomePageComponent } from './componnets/home-page/home-page.component';
import { ListComponent } from './componnets/list/list.component';
import { DetailsComponent } from './componnets/details/details.component';
import { EditComponent } from './componnets/edit/edit.component';
import { ImgUploaderComponent } from './componnets/img-uploader/img-uploader.component';





@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ListComponent,
    DetailsComponent,
    EditComponent,
    ImgUploaderComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(arrPath),
    AppRoutingModule,
    MatSliderModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    // MatDialogRef,MatDialog,
    // MAT_DIALOG_DATA,
    BrowserAnimationsModule,
    MatSelectModule,MatOptionModule
    
    
  ],

  bootstrap: [AppComponent],
  // entryComponents: [,]
})
export class AppModule { }
