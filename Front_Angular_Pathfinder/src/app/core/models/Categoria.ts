import { Especialidad } from "./Especialidad";

export interface Categoria {
    CateId: number;
    CateNombre: string;
    CateColor: string;
    CateDescripcion: string;
    CateEspecialidades: Especialidad[];
}
