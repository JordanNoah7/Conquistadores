import { ConquistadorDTO } from "./ConquistadorDTO";

export interface EspecialidadDTO {
    EspeId: number;
    EspeNombre: string;
    EspeDescripcion: string;
    EspeCategoria: string;
    EspeConquistadores: ConquistadorDTO[];
}