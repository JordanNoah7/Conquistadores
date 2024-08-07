import { Rol } from "./Rol";

export class Usuario {
    UsuaId: number;
    UsuaUsuario: string;
    UsuaContrasenia: string;
    UsuaCambiarContrasenia: boolean;
    AudiFechCrea: Date;
    AudiUserCrea: string;
    PersNombres: string;
    UsuaRoles: Rol[];
}