import { ClaseDTO } from "./ClaseDTO";
import { ConquistadorDTO } from "./ConquistadorDTO";
import { CronogramaDTO } from "./CronogramaDTO";

export interface ItemCuadernilloDTO{
    ItcuId: number;
    ItcuDescripcion: string;
    ItcuClase: ClaseDTO;
    ItcuCronogramas: CronogramaDTO;
    ItcuConquistadores: ConquistadorDTO;
}