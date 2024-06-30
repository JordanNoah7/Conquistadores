import { NgModule } from '@angular/core';
import { MaestrosRoutingModule } from "./maestros-routing.module";
import { SharedModule } from 'src/app/shared/shared.module';
import { FeatureModule } from '../features.module';
import { ConquistadoresComponent } from './conquistadores/conquistadores.component';

@NgModule({
    imports: [
        MaestrosRoutingModule,
        SharedModule,
        FeatureModule,
    ],
    declarations: [ConquistadoresComponent],
    providers: [],
    entryComponents: []
})
export class MaestrosModule { }
