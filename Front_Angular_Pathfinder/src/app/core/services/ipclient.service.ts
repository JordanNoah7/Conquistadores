import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";

@Injectable()
export class IpClientService {

   constructor(private restService: HttpClient) {
   }

   //REQUIRE TOKEN ACCESS
   private getIpAddress = () => new Promise<any>((resolve) => this.restService.get('https://ipinfo.io/json').subscribe(data => {
      resolve(data);
   }, err => resolve(null)));

   public myBrowser() {
      if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
         return 'Opera';
      } else if (navigator.userAgent.indexOf("Chrome") != -1) {
         return 'Chrome';
      } else if (navigator.userAgent.indexOf("Safari") != -1) {
         return 'Safari';
      } else if (navigator.userAgent.indexOf("Firefox") != -1) {
         return 'Firefox';
      } else if (navigator.userAgent.indexOf("MSIE") != -1) {
         return 'IE';
      } else {
         return 'unknown';
      }
   }

   public async getHostName() {
      const res = await this.getIpAddress();
      let client: string = '';
      if (res) {
         client = res.ip + ' / ' + res.country + ' - ' + res.city;
      } else {
         client = this.myBrowser();
      }
      return client;
   }

   public async GetIp() {
      let ip: string = '';
      await this.restService.get('http://api.ipify.org/?format=json').subscribe((res: any) => {
         ip = res.ip;
      });
      return ip;
   }
}
