import { Injectable } from "@angular/core";
import { FileSaverService } from "ngx-filesaver";

@Injectable({ providedIn: "root" })
export class FilesService {
   constructor(private fileSaverService: FileSaverService) { }

   async convertFileToBase64(file: File): Promise<string> {
      return new Promise<string>((resolve, reject) => {
         const reader = new FileReader();

         reader.onload = (e: any) => {
            const base64String = e.target.result;

            if (base64String) {
               resolve(base64String);
            } else {
               reject(new Error('Error al convertir el archivo a base64.'));
            }
         };

         reader.onerror = (e) => {
            reject(new Error('Error al leer el archivo.'));
         };

         reader.readAsDataURL(file);
      });
   }

   async convertBase64ToFile(base64String: string, filename: string): Promise<File> {
      return new Promise<File>((resolve, reject) => {
          const byteCharacters = base64String;
          const byteNumbers = new Array(byteCharacters.length);

          for (let i = 0; i < byteCharacters.length; i++) {
              byteNumbers[i] = byteCharacters.charCodeAt(i);
          }

          const byteArray = new Uint8Array(byteNumbers);
          const blob = new Blob([byteArray], { type: 'application/octet-stream' });

          const file = new File([blob], filename);
          resolve(file);
      });
  }

   downloadFile(base64: string, nameFile: string) {
      const contentType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
      const sliceSize = 512;
      const byteCharacters = atob(base64);
      const byteArrays = [];

      for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
         const slice = byteCharacters.slice(offset, offset + sliceSize);

         const byteNumbers = new Array(slice.length);
         for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
         }

         const byteArray = new Uint8Array(byteNumbers);
         byteArrays.push(byteArray);
      }

      const blob = new Blob(byteArrays, { type: contentType });
      this.fileSaverService.save(blob, nameFile);
   }
}
