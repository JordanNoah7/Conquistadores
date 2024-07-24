import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as CryptoJS from 'crypto-js'

@Injectable()
export class EncryptService {
    // CryptoJS = require("crypto-js");
    private key = CryptoJS.enc.Utf8.parse(environment.appsettings.params['key']);
    private iv = CryptoJS.enc.Utf8.parse(environment.appsettings.params['iv']);

    encryptAuth(text: string): string {
        const encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(text), this.key, {
            keySize: 128 / 8,
            iv: this.iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        });
        return encrypted.toString();
    }

    decryptAuth(text: string | null): string {
        if (text) {
            const decrypted = CryptoJS.AES.decrypt(text, this.key, {
                keySize: 128 / 8,
                iv: this.iv,
                mode: CryptoJS.mode.CBC,
                padding: CryptoJS.pad.Pkcs7
            });
            return CryptoJS.enc.Utf8.stringify(decrypted);
        }
        return '';
    }

    encryptBase64(text: string): string {
        const ciphertext = CryptoJS.AES.encrypt(text, this.key).toString();
        return CryptoJS.enc.Base64.stringify(CryptoJS.enc.Utf8.parse(ciphertext));
    }

    decryptBase64(textBase64: string): string {
        const ciphertext = CryptoJS.enc.Base64.parse(textBase64).toString(CryptoJS.enc.Utf8);
        const bytes = CryptoJS.AES.decrypt(ciphertext, this.key);
        return bytes.toString(CryptoJS.enc.Utf8);
    }

    encrytHexadecimal(text: string): string {
        const ciphertext = CryptoJS.AES.encrypt(text, this.key).toString();
        return CryptoJS.enc.Hex.stringify(CryptoJS.enc.Utf8.parse(ciphertext));
    }

    decryptHexadecimal(textHexadecimal: string): string {
        const ciphertext = CryptoJS.enc.Hex.parse(textHexadecimal).toString(CryptoJS.enc.Utf8);
        const bytes = CryptoJS.AES.decrypt(ciphertext, this.key);
        return bytes.toString(CryptoJS.enc.Utf8);
    }
}
