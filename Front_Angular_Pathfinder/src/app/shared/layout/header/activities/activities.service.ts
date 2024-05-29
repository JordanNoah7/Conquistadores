import { Injectable } from '@angular/core';

@Injectable()
export class ActivitiesService {

  url: string;

  constructor() {
    this.url = '/activities/activities.json';
  }

  getActivities()  {
  }

}
