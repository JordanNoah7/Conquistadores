import {Component, OnInit, ElementRef, Renderer2, OnDestroy} from '@angular/core';
import {ActivitiesService} from "./activities.service";

declare var $: any;

@Component({
  selector: 'sa-activities',
  templateUrl: './activities.component.html',
  providers: [ActivitiesService],
})
export class ActivitiesComponent implements OnInit, OnDestroy {
  count:number;
  lastUpdate:any;
  active:boolean;
  activities:any;
  currentActivity: any;
  loading: boolean;

  constructor(
    private el:ElementRef,
    private renderer: Renderer2,
    private activitiesService:ActivitiesService,
    ) {
    this.active = false;
    this.loading = false;
    this.activities = [];
    this.count = 0;
    this.lastUpdate = new Date();
  }

  ngOnInit() {
  }

  setActivity(activity: any){
    this.currentActivity = activity;
  }

  private documentSub: any;
  onToggle() {
    let dropdown = $('.ajax-dropdown', this.el.nativeElement);
    this.active = !this.active;
    if (this.active) {
      dropdown.fadeIn()


      this.documentSub = (<any>this.renderer).listenGlobal('document', 'mouseup', (event: any) => {
        if (!this.el.nativeElement.contains(event.target)) {
          dropdown.fadeOut();
          this.active = false;
          this.documentUnsub()
        }
      });


    } else {
      dropdown.fadeOut()

      this.documentUnsub()
    }
  }



  update(){
    this.loading= true;
    setTimeout(()=>{
      this.lastUpdate = new Date()
      this.loading = false
    }, 1000)
  }


  ngOnDestroy(){
    this.documentUnsub()
  }

  documentUnsub(){
    this.documentSub && this.documentSub();
    this.documentSub = null
  }

}
