import {Injectable} from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class EncryptService {
   CryptoJS = require("crypto-js");
   private key = this.CryptoJS.enc.Utf8.parse(environment.appsettings.params['key']);
   private iv = this.CryptoJS.enc.Utf8.parse(environment.appsettings.params['iv']);

   encrypt(text: string): string {
      const encrypted = this.CryptoJS.AES.encrypt(this.CryptoJS.enc.Utf8.parse(text), this.key, {
         keySize: 128 / 8,
         iv: this.iv,
         mode: this.CryptoJS.mode.CBC,
         padding: this.CryptoJS.pad.Pkcs7
      });
      return encrypted.toString();
   }

   decrypt(text: string): string {
      const decrypted = this.CryptoJS.AES.decrypt(text, this.key, {
         keySize: 128 / 8,
         iv: this.iv,
         mode: this.CryptoJS.mode.CBC,
         padding: this.CryptoJS.pad.Pkcs7
      });
      return this.CryptoJS.enc.Utf8.stringify(decrypted);
   }
}
