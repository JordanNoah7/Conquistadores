import * as settings from '../assets/conf/appsettings.json';

export const environment = {
  production: false,

  firebase: {},


  debug: true,
  log: {
    auth: false,
    store: false,
  },

  smartadmin: {
    api: null,
    db: 'smartadmin-angular'
  },

  appsettings: settings
};


