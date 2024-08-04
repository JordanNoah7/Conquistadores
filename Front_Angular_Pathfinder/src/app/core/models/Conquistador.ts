import { Especialidad } from "./Especialidad";
import { FichaMedica } from "./FichaMedica";
import { Tutor } from "./Tutor";
import { Usuario } from "./Usuario";

export class Conquistador{
    PersId: string;
    ConqFechaInvestidura: string;
    ConqEscuela: string;
    ConqCurso: string;
    ConqTurno: string;
    PersDni: string;
    PersNombres: string;
    PersApellidoPaterno: string;
    PersApellidoMaterno: string;
    PersFechaNacimiento: string;
    PersCorreoPersonal: string;
    PersCorreoCorporativo: string;
    PersCelular: string;
    PersTelefono: string;
    PersSexo: string;
    PersDireccionCasa: string;
    PersNacionalidad: string;
    PersRegion: string;
    PersCiudad: string;
    ConqAvance: string;
    ConqAhorros: string;
    ConqPuntos: string;
    Usuario: Usuario;
    ConqFichaMedica: FichaMedica;
    ConqEspecialidades: Especialidad[];
    ConqTutores: Tutor[];
}