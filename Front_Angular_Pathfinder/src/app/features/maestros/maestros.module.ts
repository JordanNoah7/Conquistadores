import { NgModule } from '@angular/core';
import { MaestrosRoutingModule } from "./maestros-routing.module";
import { SharedModule } from 'src/app/shared/shared.module';
import { FeatureModule } from '../features.module';
import { ConquistadoresComponent } from './conquistadores/conquistadores.component';
import { RepositoryService } from 'src/app/core/services/repository.service';
import { ConquistadorService } from 'src/app/core/services/services';

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
        RepositoryService,
        ConquistadorService
    ],
    entryComponents: []
})
export class MaestrosModule { }
