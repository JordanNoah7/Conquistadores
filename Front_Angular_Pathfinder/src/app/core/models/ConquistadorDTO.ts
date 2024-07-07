import { ClaseDTO } from "./ClaseDTO";
import { EspecialidadDTO } from "./EspecialidadDTO";
import { SesionDTO } from "./SesionDTO";
import { UnidadDTO } from "./UnidadDTO";
import { UsuarioDTO } from "./UsuarioDTO";

export interface ConquistadorDTO {
    ConqId: number;
    ConqDni: string;
    ConqNombres: string;
    ConqApellidoPaterno: string;
    ConqApellidoMaterno: string;
    ConqFechaNacimiento: Date;
    ConqFechaInvestidura: Date;
    ConqCorreoPersonal: string;
    ConqCorreoCorporativo: string;
    ConqCelular: string;
    ConqTelefono: string;
    ConqAvance: string;
    ConqSexo: string;

    Usuario: UsuarioDTO;
    Sesion: SesionDTO;
    ConqClase: ClaseDTO;
    ConqUnidad: UnidadDTO;
    ConqEspecialidades: EspecialidadDTO[];
}