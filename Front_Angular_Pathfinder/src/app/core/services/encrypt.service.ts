import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class EncryptService {
    CryptoJS = require("crypto-js");
    private key = this.CryptoJS.enc.Utf8.parse(environment.appsettings.params['key']);
    private iv = this.CryptoJS.enc.Utf8.parse(environment.appsettings.params['iv']);

    encryptAuth(text: string): string {
        const encrypted = this.CryptoJS.AES.encrypt(this.CryptoJS.enc.Utf8.parse(text), this.key, {
            keySize: 128 / 8,
            iv: this.iv,
            mode: this.CryptoJS.mode.CBC,
            padding: this.CryptoJS.pad.Pkcs7
        });
        return encrypted.toString();
    }

    decryptAuth(text: string | null): string {
        if (text) {
            const decrypted = this.CryptoJS.AES.decrypt(text, this.key, {
                keySize: 128 / 8,
                iv: this.iv,
                mode: this.CryptoJS.mode.CBC,
                padding: this.CryptoJS.pad.Pkcs7
            });
            return this.CryptoJS.enc.Utf8.stringify(decrypted);
        }
        return '';
    }

    encryptBase64(text: string): string {
        const ciphertext = this.CryptoJS.AES.encrypt(text, this.key).toString();
        return this.CryptoJS.enc.Base64.stringify(this.CryptoJS.enc.Utf8.parse(ciphertext));
    }

    decryptBase64(textBase64: string): string {
        const ciphertext = this.CryptoJS.enc.Base64.parse(textBase64).toString(this.CryptoJS.enc.Utf8);
        const bytes = this.CryptoJS.AES.decrypt(ciphertext, this.key);
        return bytes.toString(this.CryptoJS.enc.Utf8);
    }

    encrytHexadecimal(text: string): string {
        const ciphertext = this.CryptoJS.AES.encrypt(text, this.key).toString();
        return this.CryptoJS.enc.Hex.stringify(this.CryptoJS.enc.Utf8.parse(ciphertext));
    }

    decryptHexadecimal(textHexadecimal: string): string {
        const ciphertext = this.CryptoJS.enc.Hex.parse(textHexadecimal).toString(this.CryptoJS.enc.Utf8);
        const bytes = this.CryptoJS.AES.decrypt(ciphertext, this.key);
        return bytes.toString(this.CryptoJS.enc.Utf8);
    }
}
