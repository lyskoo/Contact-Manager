import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Contact } from "../models/contact.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
  })
  export class ContactService {
  
    
    apiUrl = 'https://localhost:7201/api/';
  
    constructor(private http: HttpClient) { }
  
    getContacts(): Observable<Contact[]> {
      return this.http.get<Contact[]>(this.apiUrl + 'Contacts');
    }

    uploadCsvFile(file: File) {
      const formData: FormData = new FormData();
      formData.append('file', file, file.name);
      return this.http.post<any>(this.apiUrl + 'Contacts/upload', formData);
    }
}