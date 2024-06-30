import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css'],
})
export class ErrorComponent implements OnInit {
  public form: FormGroup = new FormGroup({
    ruc: new FormControl('', [Validators.required, Validators.maxLength(50)]),
  });

  public loading = false;
  public tokenCaptcha: any;

  constructor(
    private router: Router,
  ) {}

  ngOnInit() {}

  redirect() {
    let session,decode,sescode;
    for (let index in localStorage) {
      session = JSON.stringify(localStorage[index]);
      if (session !== undefined) {
        if (JSON.parse(session) !== 1) {
          decode = JSON.parse(session);
         }
      }
    }
    sescode = JSON.parse(decode);
   this.router.navigate(['/auth/login/',sescode.code]);
  }
}
