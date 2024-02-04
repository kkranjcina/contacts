import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

export interface ContactsI{
  id?: number;
  name: string;
  telephoneNumber?: number;
  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class ContactsService {
  apiUrl = 'https://localhost:44372/api/contacts/';

  constructor(private http: HttpClient) { }

  getAllContacts(): Observable<ContactsI[]>{
    return this.http.get<ContactsI[]>(this.apiUrl);
  }

  getContact(id: number): Observable<ContactsI>{
    return this.http.get<ContactsI>(this.apiUrl + id);
  }

  createContact(contact: ContactsI){
    const headers = new HttpHeaders({
      'Content-Type' : 'application/json'
    });

    this.http.post<ContactsI>(this.apiUrl, contact, { headers }).subscribe();
  }

  updateContact(contact: ContactsI) {
    this.http.put<void>(this.apiUrl + contact.id, contact).subscribe();
  }

  deleteContact(id: number | undefined){
    this.http.delete(this.apiUrl + id).subscribe();
  }
}
