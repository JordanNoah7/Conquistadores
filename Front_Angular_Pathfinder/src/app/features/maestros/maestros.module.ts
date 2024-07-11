import { NgModule } from '@angular/core';
import { MaestrosRoutingModule } from "./maestros-routing.module";
import { SharedModule } from 'src/app/shared/shared.module';
import { FeatureModule } from '../features.module';
import { ConquistadoresComponent } from './conquistadores/conquistadores.component';
import { RepositoryService } from 'src/app/core/services/repository.service';

@NgModule({
    imports: [
        MaestrosRoutingModule,
        SharedModule,
        FeatureModule,
    ],
    declarations: [
        ConquistadoresComponent
    ],
    providers: [
        RepositoryService
    ],
    entryComponents: []
})
export class MaestrosModule { }
