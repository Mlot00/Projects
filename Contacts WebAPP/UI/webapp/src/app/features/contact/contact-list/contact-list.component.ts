import { Component, OnDestroy, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Subscription } from 'rxjs';
import { Contact } from '../models/contact.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit, OnDestroy {

  contactSubscription?: Subscription;
  deleteSubscription?: Subscription;
  updateTableSubscription?: Subscription;
  contacts?: Contact[]
  id?: string;

  constructor(private contactsService: ContactService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.contactSubscription = this.contactsService.getAllContacts().subscribe({
      next: (response) => {
        this.contacts = response
      }
    });
  }

  onClick(concact: string): void {
    this.id = concact;
    if (this.id) {
      this.deleteSubscription = this.contactsService.deleteContact(this.id).subscribe({
        next: (resposne) => {
          
          //update all contact list
          this.updateTableSubscription = this.contactsService.getAllContacts().subscribe({
            next: (response) => {
              this.contacts = response
            }
          })
        }
      })
    }

  }

  ngOnDestroy(): void {
    this.contactSubscription?.unsubscribe();
    this.deleteSubscription?.unsubscribe();
    this.updateTableSubscription?.unsubscribe();
  }



}
