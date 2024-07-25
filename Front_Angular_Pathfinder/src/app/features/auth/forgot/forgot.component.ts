import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UserService } from 'src/app/core/services';

@Component({
    selector: 'app-forgot',
    templateUrl: './forgot.component.html',
    styles: []
})
export class ForgotComponent implements OnInit {
    public form: FormGroup = new FormGroup({
        username: new FormControl('', [
            Validators.required,
            Validators.maxLength(50),
        ]),
    });
    public loading = false;

    constructor(
        private builder: FormBuilder,
        private userService: UserService) {
    }

    ngOnInit() {
    }

    get username() {
        return this.form?.get('username');
    }

    public async onSubmit() {
        if (this.form?.valid) {
            this.loading = true;
            const isLogin = await this.userService.RecoverPassword(this.username?.value);
            if (isLogin)
                this.loading = false;
        }
    }
}
