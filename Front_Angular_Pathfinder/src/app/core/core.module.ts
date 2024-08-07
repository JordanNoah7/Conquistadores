import { NgModule, Optional, SkipSelf } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AuthGuard } from "./guard/auth.guard";
import { AuthService } from "./service/auth.service";
import { DynamicScriptLoaderService } from "./service/dynamic-script-loader.service";
import { throwIfAlreadyLoaded } from "./guard/module-import.guard";
import { DirectionService } from "./service/direction.service";
import { SessionService } from "./service/session.service";
import { GeneralUserService } from "./service/api/general-user.service";
import { GeneralService } from "./service/api/general.service";
import { CoreService } from "./service/core.service";
import { EncryptService } from "./service/encrypt.service";
import { IpClientService } from "./service/ipclient.service";
import { RouterService } from "./service/router.service";
import { ContextService } from "./service/context.service";
import { RepositoryService } from "./service/repository.service";
import { ConquistadorService } from "./repositories/conquistador.service";
import { ClaseService, InscripcionService, TiposService, TutorService, UnidadService } from "./repositories";
import { Unidad } from "./models";
import { UsuarioService } from "./repositories/usuario.service";

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [
        AuthGuard,
        AuthService,
        DirectionService,
        DynamicScriptLoaderService,
        SessionService,
        GeneralUserService,
        GeneralService,
        CoreService,
        EncryptService,
        IpClientService,
        RouterService,
        ContextService,
        RepositoryService,
        ConquistadorService,
        TiposService,
        TutorService,
        ClaseService,
        UnidadService,
        InscripcionService,
        UsuarioService
    ],
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, "CoreModule");
    }
}
