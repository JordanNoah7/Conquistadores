import { Component, OnInit } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Params, Route, Router } from "@angular/router";
import { TipoDialogComponent } from "./tipo-dialog/tipo-dialog.component";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorService, TiposService } from "src/app/core/repositories";
import { Filter } from "angular-feather/icons";
import { Filters } from "src/app/core/models/filters";
import { TutoresDialogComponent } from "./tutores-dialog/tutores-dialog.component";
import Swal from "sweetalert2";
@Component({
    selector: "app-formulario",
    templateUrl: "./formulario.component.html",
    styleUrls: [],
})
export class FormularioComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    conquistadorForm: UntypedFormGroup;
    hide3 = true;
    agree3 = false;
    title = '';
    id = 0;
    vacunasList = [];
    vacunas = "";
    enfermedadesList = [];
    enfermedades = "";
    alergiasList = [];
    alergias = "";

    constructor(
        private fb: UntypedFormBuilder,
        private route: ActivatedRoute,
        public dialog: MatDialog,
        public tipoService: TiposService,
        private conquistadorService: ConquistadorService,
        private router: Router,
    ) {
        super();
    }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => (
            (this.id = Number(params['C']))
        ));
        this.title = this.id > 0 ? 'Actualizar' : 'Nuevo';
        this.conquistadorForm = this.createConquistadorForm();
        this.LoadTipos();
        if (this.id > 0) {
            this.GetConquistador();
        }
    }

    async GetConquistador() {
        await this.conquistadorService.getConquistadorById(this.id).subscribe({
            next: (value: any) => {
                console.log(value);
                this.conquistadorForm.patchValue(value);
                this.conquistadorForm.get('UsuaId').setValue(value.Usuario.UsuaId);
                this.conquistadorForm.get('UsuaUsuario').setValue(value.Usuario.UsuaUsuario);
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            }
        })
    }

    async LoadTipos() {
        let filtros = new Filters();
        filtros.Tipo = "VAC";
        await this.tipoService.GetTipos(filtros).subscribe({
            next: (value: any) => {
                this.vacunasList = value;
            },
        });
        filtros.Tipo = "ENF";
        await this.tipoService.GetTipos(filtros).subscribe({
            next: (value: any) => {
                this.enfermedadesList = value;
            },
        });
        filtros.Tipo = "ALE";
        await this.tipoService.GetTipos(filtros).subscribe({
            next: (value: any) => {
                this.alergiasList = value;
            },
        });
    }

    onSubmit() {
    }

    createConquistadorForm(): UntypedFormGroup {
        return this.fb.group({
            PersId: [''],
            PersDni: ['', [Validators.required]],
            PersNombres: ['', [Validators.required]],
            PersApellidoPaterno: ['', [Validators.required]],
            PersApellidoMaterno: ['', [Validators.required]],
            PersFechaNacimiento: ['', [Validators.required]],
            PersSexo: ['', [Validators.required]],
            PersNacionalidad: ['', [Validators.required]],
            PersDireccionCasa: ['', [Validators.required]],
            PersCiudad: ['', [Validators.required]],
            PersRegion: ['', [Validators.required]],
            PersCelular: ['', [Validators.required]],
            PersTelefono: [''],
            PersCorreoPersonal: ['', [Validators.required, Validators.email]],
            PersCorreoCorporativo: ['', [Validators.email]],
            ConqEscuela: ['', [Validators.required]],
            ConqCurso: ['', [Validators.required]],
            ConqTurno: ['', [Validators.required]],
            ConqFechaInvestidura: ['', [Validators.required]],
            ConqUsuario: ['', [Validators.required]],
            ConqContrasenia: ['', [Validators.required]],
            ConqReContrasenia: ['', [Validators.required]],
            FimeSangreRH: [''],
            FimeObservaciones: [''],
            ConqPadre: [''],
            ConqMadre: ['']
        });
    }

    onChangeVacuna(event: any, id: number) {
        if (event.target.checked) {
            if (this.vacunas) {
                this.vacunas += '|' + id;
            } else {
                this.vacunas = id.toString();
            }
        } else {
            let v = this.vacunas.split('|');
            v = v.filter(v => v != id.toString());
            this.vacunas = '';
            v.map(v => {
                this.vacunas += v + '|';
            })
        }
        this.vacunas = this.vacunas.replace('||', '');
    }

    onChangeEnfermedad(event: any, id: number) {
        if (event.target.checked) {
            if (this.enfermedades) {
                this.enfermedades += '|' + id;
            } else {
                this.enfermedades = id.toString();
            }
        } else {
            let v = this.enfermedades.split('|');
            v = v.filter(v => v != id.toString());
            this.enfermedades = '';
            v.map(v => {
                this.enfermedades += v + '|';
            })
        }
        this.enfermedades = this.enfermedades.replace('||', '');
    }

    onChangeAlergia(event: any, id: number) {
        if (event.target.checked) {
            if (this.alergias) {
                this.alergias += '|' + id;
            } else {
                this.alergias = id.toString();
            }
        } else {
            let v = this.alergias.split('|');
            v = v.filter(v => v != id.toString());
            this.alergias = '';
            v.map(v => {
                this.alergias += v + '|';
            })
        }
        this.alergias = this.alergias.replace('||', '');
    }

    addVacuna() {
        const id = this.vacunasList.length > 0 ? (Math.max(...this.vacunasList.map(x => x.TipoId))) : 0;
        const dialogRef = this.dialog.open(TipoDialogComponent, {
            data: {
                dialogTitle: 'Nueva vacuna',
                tabla: 'VAC',
                id: id + 1
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.tipoService.getDialogData()) {
                    this.vacunasList.push(this.tipoService.getDialogData());
                }
            }
        })
    }

    addEnfermedad() {
        const id = this.enfermedadesList.length > 0 ? (Math.max(...this.enfermedadesList.map(x => x.TipoId))) : 0;
        const dialogRef = this.dialog.open(TipoDialogComponent, {
            data: {
                dialogTitle: 'Nueva enfermedad',
                tabla: 'ENF',
                id: id + 1
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.tipoService.getDialogData()) {
                    this.enfermedadesList.push(this.tipoService.getDialogData());
                }
            }
        })
    }

    addAlergia() {
        const id = this.alergiasList.length > 0 ? (Math.max(...this.alergiasList.map(x => x.TipoId))) : 0;
        const dialogRef = this.dialog.open(TipoDialogComponent, {
            data: {
                dialogTitle: 'Nueva alergia',
                tabla: 'ALE',
                id: id + 1
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.tipoService.getDialogData()) {
                    this.alergiasList.push(this.tipoService.getDialogData());
                }
            }
        })
    }

    SearchPadres(sexo: string) {
        const dialogRef = this.dialog.open(TutoresDialogComponent, {
            data: {
                paterno1: this.conquistadorForm.get('PersApellidoPaterno').value,
                paterna2: this.conquistadorForm.get('PersApellidoMaterno').value,
                sexo
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.tipoService.getDialogData()) {

                }
            }
        })
    }

    GoToRegistro() {
        this.router.navigate(['/conquistador/registro']);
    }
}
