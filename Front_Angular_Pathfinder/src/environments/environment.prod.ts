import * as settings from '../assets/conf/appsettings.json';

export const environment = {
  production: true,

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


