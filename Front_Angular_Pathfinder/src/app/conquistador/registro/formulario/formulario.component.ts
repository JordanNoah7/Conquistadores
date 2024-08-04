import { Component, OnInit } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Params, Route, Router } from "@angular/router";
import { TipoDialogComponent } from "./tipo-dialog/tipo-dialog.component";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ClaseService, ConquistadorService, TiposService, TutorService, UnidadService } from "src/app/core/repositories";
import { Filter } from "angular-feather/icons";
import { Filters } from "src/app/core/models/filters";
import { TutoresDialogComponent } from "./tutores-dialog/tutores-dialog.component";
import Swal from "sweetalert2";
import { Conquistador, Tutor } from "src/app/core/models";
import { Usuario } from "src/app/core/models/Usuario";
import { FichaMedica } from "src/app/core/models/FichaMedica";
import { ClaseDialogComponent } from "./clase-dialog/clase-dialog.component";
import { UnidadDialogComponent } from "./unidad-dialog/unidad-dialog.component";
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
    isSaving = false;

    constructor(
        private fb: UntypedFormBuilder,
        private route: ActivatedRoute,
        public dialog: MatDialog,
        public tipoService: TiposService,
        private conquistadorService: ConquistadorService,
        private tutorService: TutorService,
        private claseService: ClaseService,
        private unidadService: UnidadService,
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
                this.conquistadorForm.get('FimeSangreRH').setValue(value.ConqFichaMedica.FimeSangreRH);
                this.conquistadorForm.get('FimeObservaciones').setValue(value.ConqFichaMedica.FimeObservaciones);
                this.alergias = value.ConqFichaMedica.FimeAlergias;
                this.enfermedades = value.ConqFichaMedica.FimeEnfermedades;
                this.vacunas = value.ConqFichaMedica.FimeVacunas;
                if (value.ConqTutores.length > 0) {
                    value.ConqTutores.map(t => {
                        if (t.PersSexo === 'M') {
                            this.conquistadorForm.get('ConqPadreId').setValue(t.PersId);
                            this.conquistadorForm.get('ConqPadre').setValue(t.PersNombres + ' ' + t.PersApellidoPaterno + ' ' + t.PersApellidoMaterno);
                        } else if (t.PersSexo === 'F') {
                            this.conquistadorForm.get('ConqMadreId').setValue(t.PersId);
                            this.conquistadorForm.get('ConqMadre').setValue(t.PersNombres + ' ' + t.PersApellidoPaterno + ' ' + t.PersApellidoMaterno);
                        }
                    })
                }
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
        this.conquistadorForm.valid;
        if (this.isSaving) {
            return;
        }
        this.isSaving = true;
        const c = this.conquistadorForm.get('UsuaContrasenia').value;
        const rc = this.conquistadorForm.get('UsuaReContrasenia').value;
        if (c != rc) {
            Swal.fire({
                title: 'Error!',
                text: "Las contraseñas no son iguales, verifique e intente nuevamente.",
                icon: 'error',
                confirmButtonText: 'Ok'
            });
            this.isSaving = false;
            return;
        }
        let t: Tutor;
        let conquistador: Conquistador = new Conquistador();
        conquistador.Usuario = new Usuario();
        conquistador.ConqFichaMedica = new FichaMedica();
        conquistador.ConqTutores = [];
        conquistador.PersId = this.conquistadorForm.get('PersId').value;
        conquistador.PersDni = this.conquistadorForm.get('PersDni').value;
        conquistador.PersNombres = this.conquistadorForm.get('PersNombres').value;
        conquistador.PersApellidoPaterno = this.conquistadorForm.get('PersApellidoPaterno').value;
        conquistador.PersApellidoMaterno = this.conquistadorForm.get('PersApellidoMaterno').value;
        conquistador.PersFechaNacimiento = this.conquistadorForm.get('PersFechaNacimiento').value;
        conquistador.PersSexo = this.conquistadorForm.get('PersSexo').value;
        conquistador.PersNacionalidad = this.conquistadorForm.get('PersNacionalidad').value;
        conquistador.PersDireccionCasa = this.conquistadorForm.get('PersDireccionCasa').value;
        conquistador.PersCiudad = this.conquistadorForm.get('PersCiudad').value;
        conquistador.PersRegion = this.conquistadorForm.get('PersRegion').value;
        conquistador.PersCelular = this.conquistadorForm.get('PersCelular').value.toString();
        conquistador.PersTelefono = this.conquistadorForm.get('PersTelefono').value.toString();
        conquistador.PersCorreoPersonal = this.conquistadorForm.get('PersCorreoPersonal').value;
        conquistador.PersCorreoCorporativo = this.conquistadorForm.get('PersCorreoCorporativo').value;
        conquistador.ConqEscuela = this.conquistadorForm.get('ConqEscuela').value;
        conquistador.ConqCurso = this.conquistadorForm.get('ConqCurso').value;
        conquistador.ConqTurno = this.conquistadorForm.get('ConqTurno').value;
        conquistador.ConqFechaInvestidura = this.conquistadorForm.get('ConqFechaInvestidura').value;
        conquistador.Usuario.UsuaId = this.conquistadorForm.get('UsuaId').value;
        conquistador.Usuario.UsuaUsuario = this.conquistadorForm.get('UsuaUsuario').value;
        conquistador.Usuario.UsuaContrasenia = this.conquistadorForm.get('UsuaContrasenia').value;
        conquistador.ConqFichaMedica.ConqId = this.conquistadorForm.get('PersId').value;
        conquistador.ConqFichaMedica.FimeSangreRH = this.conquistadorForm.get('FimeSangreRH').value;
        conquistador.ConqFichaMedica.FimeObservaciones = this.conquistadorForm.get('FimeObservaciones').value;
        conquistador.ConqFichaMedica.FimeVacunas = this.vacunas;
        conquistador.ConqFichaMedica.FimeEnfermedades = this.enfermedades;
        conquistador.ConqFichaMedica.FimeAlergias = this.alergias;
        console.log(conquistador);
        if (this.conquistadorForm.get('ConqPadreId').value > 0) {
            t = new Tutor();
            t.PersId = this.conquistadorForm.get('ConqPadreId').value;
            t.PersSexo = 'M';
            conquistador.ConqTutores.push(t);
        }
        if (this.conquistadorForm.get('ConqMadreId').value > 0) {
            t = new Tutor();
            t.PersId = this.conquistadorForm.get('ConqMadreId').value;
            t.PersSexo = 'F';
            conquistador.ConqTutores.push(t);
        }
        this.conquistadorService.saveConquistador(conquistador).subscribe({
            next: (value: any) => {
                Swal.fire({
                    icon: "success",
                    title: value,
                    showConfirmButton: true,
                });
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
                this.isSaving = false;
            },
            complete: () => {
                this.isSaving = false;
                this.GoToRegistro();
            }
        });
    }

    createConquistadorForm(): UntypedFormGroup {
        return this.fb.group({
            PersId: [0],
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
            ConqFechaInvestidura: [null],
            UsuaId: [0],
            UsuaUsuario: ['', [Validators.required]],
            UsuaContrasenia: [''],
            UsuaReContrasenia: [''],
            FimeSangreRH: [''],
            FimeObservaciones: [''],
            ConqPadreId: [0],
            ConqMadreId: [0],
            ConqPadre: [''],
            ConqMadre: [''],
            ConqClaseId: [0],
            ConqClase: [''],
            ConqUnidadId: [0],
            ConqUnidad: [''],
        });
    }

    SearchPadres(sexo: string) {
        const dialogRef = this.dialog.open(TutoresDialogComponent, {
            data: {
                sexo
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.tutorService.getDialogData()) {
                    let tutor = this.tutorService.getDialogData();
                    if (sexo === 'M') {
                        this.conquistadorForm.get('ConqPadreId').setValue(tutor.PersId);
                        this.conquistadorForm.get('ConqPadre').setValue(tutor.PersNombres + ' ' + tutor.PersApellidoPaterno + ' ' + tutor.PersApellidoMaterno);
                    } else if (sexo === 'F') {
                        this.conquistadorForm.get('ConqMadreId').setValue(tutor.PersId);
                        this.conquistadorForm.get('ConqMadre').setValue(tutor.PersNombres + ' ' + tutor.PersApellidoPaterno + ' ' + tutor.PersApellidoMaterno);
                    }
                    else {
                        return;
                    }
                }
            }
        })
    }

    SearchClases() {
        const dialogRef = this.dialog.open(ClaseDialogComponent, {});
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.claseService.getDialogData()) {
                    let clase = this.claseService.getDialogData();
                    this.conquistadorForm.get('ConqClaseId').setValue(clase.ClasId);
                    this.conquistadorForm.get('ConqClase').setValue(clase.ClasNombre);
                }
            }
        })
    }

    SearchUnidades() {
        const dialogRef = this.dialog.open(UnidadDialogComponent, {});
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                if (this.unidadService.getDialogData()) {
                    let unidad = this.unidadService.getDialogData();
                    this.conquistadorForm.get('ConqUnidadId').setValue(unidad.UnidId);
                    this.conquistadorForm.get('ConqUnidad').setValue(unidad.UnidNombre);
                }
            }
        })
    }

    GoToRegistro() {
        this.router.navigate(['/conquistador/registro']);
    }

    onChangeVacuna(event: any, id: number) {
        if (event.target.checked) {
            if (this.vacunas != '') {
                this.vacunas += '|' + id;
            } else {
                this.vacunas = id.toString();
            }
        } else {
            let v = this.vacunas.split('|');
            v = v.filter(v => v != id.toString());
            this.vacunas = '';
            v.map(v => {
                if (v != '') {
                    this.vacunas += v + '|';
                }
            })
        }
        console.log(this.vacunas);
        // this.vacunas = this.vacunas.replace('||', '');
    }

    onChangeEnfermedad(event: any, id: number) {
        if (event.target.checked) {
            if (this.enfermedades != '') {
                this.enfermedades += '|' + id;
            } else {
                this.enfermedades = id.toString();
            }
        } else {
            let v = this.enfermedades.split('|');
            v = v.filter(v => v != id.toString());
            this.enfermedades = '';
            v.map(v => {
                if (v != '') {
                    this.enfermedades += v + '|';
                }
            })
        }
        console.log(this.enfermedades);
        // this.enfermedades = this.enfermedades.replace('||', '');
    }

    onChangeAlergia(event: any, id: number) {
        if (event.target.checked) {
            if (this.alergias != '') {
                this.alergias += '|' + id;
            } else {
                this.alergias = id.toString();
            }
        } else {
            let v = this.alergias.split('|');
            v = v.filter(v => v != id.toString());
            this.alergias = '';
            v.map(v => {
                if (v != '') {
                    this.alergias += v + '|';
                }
            })
        }
        console.log(this.alergias);
        // this.alergias = this.alergias.replace('||', '');
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
}
