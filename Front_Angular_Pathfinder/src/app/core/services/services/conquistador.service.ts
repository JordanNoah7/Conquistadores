import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class ConquistadorService{
    private ListadoConquistadores: any[] = [];
    ListadoConquistadores$: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
}