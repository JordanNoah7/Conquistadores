import { ItemCuadernilloDTO } from "./ItemCuadernilloDTO";

export interface CronogramaDTO {
    CronId: number;
    CronEstaHecho: boolean;
    CronFechaInicio: Date;
    CronFechaFin: Date;
    CronItem: ItemCuadernilloDTO;
}