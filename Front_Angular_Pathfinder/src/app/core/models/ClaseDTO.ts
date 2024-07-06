import { ConquistadorDTO } from "./ConquistadorDTO";

export interface ClaseDTO{
    ClasId: number;
    ClasNombre: string;
    ClasDescripcion: string;

    ClasConquistadores: ConquistadorDTO[];
}