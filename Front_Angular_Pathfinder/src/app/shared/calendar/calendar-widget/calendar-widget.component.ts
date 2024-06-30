import {
  Component,
  OnInit,
  ElementRef,
  OnDestroy,
  Input,
  Output,
  EventEmitter,
  AfterContentInit
} from "@angular/core";




@Component({
  selector: "calendar-widget",
  templateUrl: "./calendar-widget.component.html"
})
export class CalendarWidgetComponent implements OnDestroy, AfterContentInit {
  @Input() public events: any;
  @Input() public period = "Showing";
  @Output() addEvent = new EventEmitter();

  private $calendarRef: any;
  private fullcalendar: any;

  constructor(private el: ElementRef) {

  }

  ngAfterContentInit() {
    /*require("script-loader!smartadmin-plugins/bower_components/fullcalendar/dist/fullcalendar.min.js")
    .then(()=>{
      this.render()
    })*/
  }

  render() {
    //this.$calendarRef = $(document.getElementById("calendar"));

    this.fullcalendar = this.$calendarRef.fullCalendar({
      lang: "en",
      editable: true,
      draggable: true,
      selectable: false,
      selectHelper: true,
      unselectAuto: false,
      disableResizing: false,
      droppable: true,

      header: {
        left: "title", //,today
        center: "prev, next, today",
        right: "month, agendaWeek, agendaDay" //month, agendaDay,
      },

      drop: (date: any, event: any, ui: { helper: { data: (arg0: string) => any; }; }) => {
        // this function is called when something is dropped

        // retrieve the dropped element's stored Event Object
        let originalEventObject = ui.helper.data("eventObject");

        // we need to copy it, so that multiple events don't have a reference to the same object
        let copiedEventObject = $.extend({}, originalEventObject);

        // assign it the date that was reported
        copiedEventObject.start = date;

        // render the event on the calendar
        // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
        this.$calendarRef.fullCalendar("renderEvent", copiedEventObject, true);

        this.addEvent.emit(copiedEventObject);
      },

      select: (start: any, end: any, allDay: any) => {
        var title = prompt("Event Title:");
        if (title) {
          this.fullcalendar.fullCalendar(
            "renderEvent",
            {
              title: title,
              start: start,
              end: end,
              allDay: allDay
            },
            true // make the event "stick"
          );
        }
        this.fullcalendar.fullCalendar("unselect");
      },

      events: (start: any, end: any, timezone: any, callback: (arg0: any) => void) => {
        callback(this.events);
      },

      eventRender: (event: { description: string; icon: string; }, element: { find: (arg0: string) => { (): any; new(): any; append: { (arg0: string): void; new(): any; }; }; }, icon: any) => {
        if (event.description !== "") {
          element
            .find(".fc-event-title")
            .append(
              "<br/><span class='ultra-light'>" + event.description + "</span>"
            );
        }
        if (event.icon !== "") {
          element
            .find(".fc-event-title")
            .append("<i class='air air-top-right fa " + event.icon + " '></i>");
        }
      }
    });

    $(".fc-header-right, .fc-header-center", this.$calendarRef).hide();

    $(".fc-left", this.$calendarRef).addClass("fc-header-title");
  }

  ngOnDestroy() {
    this.fullcalendar.fullCalendar("destroy");
  }

  changeView(period: string) {
    this.fullcalendar.fullCalendar("changeView", period);
    this.period = period;
  }

  next() {
    $(".fc-next-button", this.el.nativeElement).click();
  }

  prev() {
    $(".fc-prev-button", this.el.nativeElement).click();
  }

  today() {
    $(".fc-today-button", this.el.nativeElement).click();
  }
}
