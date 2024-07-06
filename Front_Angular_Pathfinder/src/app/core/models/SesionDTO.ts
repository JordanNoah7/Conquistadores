import { UsuarioDTO } from "./UsuarioDTO";

export interface SesionDTO {
    SesiId: number;
    SesiUsuario: UsuarioDTO;
    SesiFecha: Date;
    SesiTiempo: number;
}