import { ConquistadorDTO } from "./ConquistadorDTO";

export interface UnidadDTO {
    UnidId: number;
    UnidNombre: string;
    UnidLema: string;
    UnidGritoGuerra: string;
    UnidDescripcion: string;

    UnidConquistadores: ConquistadorDTO[];
}