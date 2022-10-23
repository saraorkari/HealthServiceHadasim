import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ImgService } from 'src/app/services/img.service';
import { mimeType } from '../../mime-type.validator';
@Component({
  selector: 'app-img-uploader',
  templateUrl: './img-uploader.component.html',
  styleUrls: ['./img-uploader.component.scss']
})
export class ImgUploaderComponent implements OnInit {
  form: FormGroup = {} as FormGroup;
  imagePreview: string | ArrayBuffer = '';

  constructor(public imgService: ImgService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      'image': new FormControl(null, { validators: [Validators.required], asyncValidators: [mimeType] }),
    });
  }
  onImagePicked(event: any) {
    const file = event.target!.files[0];
    this.form.patchValue({ image: file });
    this.form.get('image')!.updateValueAndValidity();
    const reader = new FileReader();
    reader.onload = () => {
      this.imagePreview = reader.result!;
    };
    reader.readAsDataURL(file);
  }
  onSavePost() {
    if (this.form.invalid) {
      return;
    }    
    this.imgService.addImg(this.form.value.image);
    this.form.reset();
  }
}
