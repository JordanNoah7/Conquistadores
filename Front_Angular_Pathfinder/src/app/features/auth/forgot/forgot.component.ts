import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styles: []
})
export class ForgotComponent implements OnInit {

  public form: FormGroup | null = null;
  public loading = false;

  validatorOptions = {
    fields: {
      username: {
        group: 'section',
        validators: {
          notEmpty: {
            message: 'El nombre de usuario es obligatorio'
          }
        }
      }
    }
  };

  constructor(
    private builder: FormBuilder,
    private userService: UserService) { }

  ngOnInit() {
    this.form = this.builder.group({
      username: [null, Validators.compose([Validators.required, Validators.maxLength(10)])],
    });
  }

  get username() { return this.form?.get('username'); }

  public onSubmit(): void {
    if (this.form?.valid) {
      this.loading = true;
      const isLogin = this.userService.ObtenerCorreo(this.username?.value);
      isLogin.then(res => {
        this.loading = false;
      });
    }
  }
}
