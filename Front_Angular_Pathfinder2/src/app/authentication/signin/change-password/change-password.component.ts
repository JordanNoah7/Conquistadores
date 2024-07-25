import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
@Component({
    selector: "app-dialogform",
    templateUrl: "./change-password.component.html",
    styleUrls: ["./change-password.component.sass"],
})
export class ChangePasswordComponent implements OnInit {
    hide = false;
    hideN = false;
    public addCusForm: UntypedFormGroup;
    constructor(private fb: UntypedFormBuilder, public dialog: MatDialog) { }
    public ngOnInit(): void {
        this.addCusForm = this.fb.group({
            firstname: [
                null,
                [Validators.required, Validators.pattern("[a-zA-Z]+([a-zA-Z ]+)*")],
            ],
            lastname: [
                null,
                [Validators.required, Validators.pattern("[a-zA-Z]+([a-zA-Z ]+)*")],
            ],
        });
    }
    closeDialog(): void {
        this.dialog.closeAll();
    }
    onSubmitClick() {
        console.log("Form Value", this.addCusForm.value);
    }
}
