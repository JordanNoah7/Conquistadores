import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService, SessionService } from 'src/app/core/services';
import { PasswordCheckService } from './password-check.service';

@Component({
  selector: 'app-change',
  templateUrl: './change.component.html'
})
export class ChangeComponent implements OnInit {

  constructor(){
    
  }

  ngOnInit(): void {
  }


} 
