import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'ns-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {

  @Input() textLoading: string = "Cargando...";
  
  constructor() { }

  ngOnInit(): void {
  }

}
