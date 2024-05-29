import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { SessionService } from 'src/app/core/services';

@Component({
  selector: 'app-recovery',
  templateUrl: './recovery.component.html',
  styles: []
})
export class RecoveryComponent implements OnInit {

  public logo:any;
  constructor(private router: Router,private sessionService: SessionService) { }

  ngOnInit() {
    let session= this.sessionService.getCurrentSession();
    this.logo = session.params.Logo;
  }

  submit(event: any){
    event.preventDefault();
    this.router.navigate(['/dashboard/+analytics'])
  }
}
