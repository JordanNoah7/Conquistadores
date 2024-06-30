import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';
import { environment } from '../../../environments/environment';


@Injectable()
export class StorageService {

  constructor(
    private storage: Storage
  ) { }


  get(key: string | number){
    return this.load().then(db => db[key])
  }

  /**
   * @returns value
   * @param key
   * @param value
   */
  set(key: string | number, value: any){
    return this.load().then(db => {
       db[key] = value
       return db
    }).then(this.dump).then(_ => value)
  }

  remove(key: string | number){
    return this.load().then(db => {
       db[key] = null
       delete db[key]
       return db
    }).then(this.dump)
  }

  dump = (db: any) => {
    return this.storage.set(environment.smartadmin.db, JSON.stringify(db))
  }

  load(){
    return this.storage.get(environment.smartadmin.db).then( db => {
      return db ? JSON.parse(db) : {}
    })
  }

}
