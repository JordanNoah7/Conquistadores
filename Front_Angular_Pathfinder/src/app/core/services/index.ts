import { StorageService } from './storage.service';
import { AuthService } from './auth.service';
import { UserService } from './user.service';
import { NotificationService } from './notification.service';
import { BodyService } from './body.service';
import { LayoutService } from './layout.service';
import { SoundService } from './sound.service';
import { CoreService } from './core.service';
import * as fromApi from './api';
import { RequestService } from './request.service';
import { RouterService } from './router.service';
import { SessionService } from './session.service';
import { IpClientService } from './ipclient.service';
import { ContextService } from './context.service';
import { FilesService } from './files.service';
import { EncryptService } from "./encrypt.service";

export const services = [
    AuthService,
    BodyService,
    CoreService,
    LayoutService,
    NotificationService,

    FilesService,
    RequestService,
    RouterService,
    SessionService,
    SoundService,
    StorageService,
    UserService,
    IpClientService,
    ContextService,
    EncryptService,

    fromApi.GeneralService,
    fromApi.GeneralUserService,
];

export * from './auth.service';
export * from './body.service';
export * from './core.service';
export * from './layout.service';
export * from './notification.service';
export * from './request.service';
export * from './router.service';
export * from './session.service';
export * from './sound.service';
export * from './storage.service';
export * from './user.service';
export * from './ipclient.service';
export * from './context.service';
export * from './api';
