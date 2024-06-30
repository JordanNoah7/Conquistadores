import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeatureModule } from '../features.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { RepositoryService } from 'src/app/core/services/repository.service';

@NgModule({
    imports: [
        DashboardRoutingModule,
        SharedModule,
        FeatureModule,
    ],
    declarations: [DashboardComponent],
    providers: [RepositoryService],
    entryComponents: []
})
export class DashboardModule { }
