import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sa-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  public currentAnio:number = new Date().getFullYear();

  constructor() {}

  ngOnInit() {}

}
