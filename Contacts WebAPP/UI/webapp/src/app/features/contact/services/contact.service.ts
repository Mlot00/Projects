import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddContact } from '../models/add-contact.model';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { environment } from 'src/environments/environment.development';
import { UpdateContact } from '../models/update-contact.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient,
    private cookieService: CookieService) {

   }

   createContact(data: AddContact) :Observable<Contact>{
    return this.http.post<Contact>(`${environment.apiBaseUrl}/api/contacts?addAuth=true`, data, {
      headers: {
        'Authorization' : this.cookieService.get('Authorization')
      }
    });
   }

   getAllContacts() :Observable<Contact[]>{
    return this.http.get<Contact[]>(`${environment.apiBaseUrl}/api/contacts`);
   }

    getContactById(id: string) :Observable<Contact>{
      return this.http.get<Contact>(`${environment.apiBaseUrl}/api/contacts/${id}`);
    }

    updateCoontact(id: string, updateContact: UpdateContact) :Observable<Contact>{
      return  this.http.put<Contact>(`${environment.apiBaseUrl}/api/contacts/${id}?addAuth=true`, updateContact, {
        headers: {
          'Authorization' : this.cookieService.get('Authorization')
        }
      });
    }

    deleteContact(id: string) :Observable<Contact>{
      return this.http.delete<Contact>(`${environment.apiBaseUrl}/api/contacts/${id}`, {
        headers: {
          'Authorization' : this.cookieService.get('Authorization')
        }
      });
    }

    
}
