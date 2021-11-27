import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  
  isSubmitted=false;

  contactForm!: FormGroup;

  countries: any = ['India', 'Pakistan', 'Afganinstan', 'Nepal']

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.contactForm = this.formBuilder.group({
      //controls
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required]],
      gender: [''],
      isMarried: [],
      country:['', [Validators.required]],
      address: this.formBuilder.group({
        city: ['',[Validators.required]],
        street: ['',[Validators.required]],
        zip: ['',[Validators.required]]
      }),
    });
   


  }

  

  get formControls() {
    return this.contactForm.controls;
  }




  public handleError = (controlName: string, errorName: string) => {
    return this.contactForm.controls[controlName].hasError(errorName);
  }
  changeCountry(e) {
    this.contactForm.get('country').setValue(e.target.value, {
       onlySelf: true
    })
  }
  onSubmit() {
    this.isSubmitted=true;
    
    console.log(this.contactForm.value);
    //alert(JSON.stringify(this.contactForm.value))

  }
}
