import { Injectable } from "@angular/core";
import { GeneralService } from "./api";
import { NotificationService } from "./notification.service";
import { SessionService } from "./session.service";
import { RequestRestCON, ApiResponse } from "../models";

@Injectable()
export class RequestService {
    constructor(
        private notificationService: NotificationService,
        private sessionService: SessionService,
        private generalRequestService: GeneralService) {
    }

    public async SendRequest(payload: any, method: string) {
        const methodResult = method + 'Result';
        let code = 0;
        let success = false;
        let message = null;
        let message2 = null;
        let return_result = { success, [methodResult]: null, message }
        const result = await this.generalRequestService.CallService(payload, method);
        if (result != null) {
            code = result.Codigo;
            message = result.Mensaje;
            message2 = result.Mensaje2;
            switch (code) {
                case 0:
                    return_result = result;
                    this.sessionService.setMinutosDisponibles(result.TiempoSesion)
                    if (message) {
                        this.notificationService.showSmallMessage(message, true);
                    }
                    if (message2) {
                        this.notificationService.showSmallMessage(message2, false);
                    }
                    break;
                case 1:
                    this.notificationService.showSmallMessage(message, success);
                    if (message2) {
                        this.notificationService.showSmallMessage(message2, false);
                    }
                    break;
                case 98:
                case 99:
                    this.CloseSesion();
                    return;
                default:
                    this.notificationService.showSmallMessage(`Error no controlado al invocar servicio:  ${method}`, false);
                    break;
            }
        } else {
            this.notificationService.showSmallMessage('El servidor ha enviado una respuesta inválida', false);
        }
        return return_result;
    }

    public async SendRequestOperaciones(payload: any, method: string) {
        const methodResult = method + 'Result';
        let code = 0;
        let success = false;
        let message = null;
        let data = null;
        let return_result = { success, [methodResult]: null, message, data }

        const result = await this.generalRequestService.CallService(payload, method);
        if (result != null) {
            code = result.Codigo;
            message = result.Mensaje;
            data = result;
            switch (code) {
                case 0:
                    return_result = result;
                    this.sessionService.setMinutosDisponibles(result.TiempoSesion)
                    if (message) {
                        this.notificationService.showSmallMessage(message, true);
                    }
                    break;
                case 1:
                    this.notificationService.showSmallMessage(message, success);
                    break;
                case 98:
                case 99:
                    this.CloseSesion();
                    return;
                default:
                    this.notificationService.showSmallMessage(`Error no controlado al invocar servicio:  ${method}`, false);
                    break;
            }
        } else {
            this.notificationService.showSmallMessage('El servidor ha enviado una respuesta inválida', false);
        }
        return return_result;
    }

    public async SendRequestConquistador(payload: any, method: string): Promise<any> {
        let code = 0;
        let success = false;
        let message = null;
        let data = null;
        let apiResponse;
        const result = await this.generalRequestService.CallService(payload, method);
        if (result != null) {
            code = result.Codigo;
            message = result.Mensaje;
            data = result;
            switch (code) {
                case 0:
                    apiResponse = result || ApiResponse;
                    this.sessionService.setMinutosDisponibles(result.TiempoSesion)
                    break;
                case 1:
                    this.notificationService.showSmallMessage(message, success);
                    break;
                case 98:
                case 99:
                    this.CloseSesion();
                    return new ApiResponse();
                default:
                    this.notificationService.showSmallMessage(`Error no controlado al invocar servicio:  ${method}`, false);
                    break;
            }
        } else {
            this.notificationService.showSmallMessage('El servicio no ha retornado una respuesta', false);
        }
        return apiResponse;
    }

    private CloseSesion() {
        this.notificationService.showSmallMessage('La sesión ha expirado, por favor vuelva a iniciar sesión', false);
        this.sessionService.logout();
    }
}
