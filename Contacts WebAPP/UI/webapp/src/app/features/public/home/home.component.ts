import { Component, OnDestroy, OnInit } from '@angular/core';
import { ContactService } from '../../contact/services/contact.service';
import { Observable, Subscription } from 'rxjs';
import { Contact } from '../../contact/models/contact.model';
import { AuthService } from '../../auth/services/auth.service';
import { User } from '../../auth/models/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy{
  contacts$?: Observable<Contact[]>;
  userSubscfription?: Subscription;
  user?: User;

  constructor(private contactService: ContactService,
    private authService: AuthService){

  }

  ngOnInit(): void {
    this.contacts$ = this.contactService.getAllContacts();

        //get user
        this.userSubscfription= this.authService.user().subscribe({
          next: (response) =>{
            this.user = response;
          }
        });
        this.user = this.authService.getUser();
  }
  
  ngOnDestroy(): void {
    this.userSubscfription?.unsubscribe();
  }
}
