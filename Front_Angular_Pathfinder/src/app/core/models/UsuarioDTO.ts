import { RolDTO } from "./RolDTO";

export interface UsuarioDTO {
    UsuaId: number;
    UsuaUsuario: string;
    UsuaContrasenia: string;
    UsuaCambiarContrasenia: boolean;
    UsuaRoles: RolDTO[];
}