import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddContact } from '../models/add-contact.model';
import { ContactService } from '../services/contact.service';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { AuthService } from '../../auth/services/auth.service';
import { User } from '../../auth/models/user.model';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnDestroy, OnInit {

  model: AddContact;
  contactSubscribtion?: Subscription;
  userSubscription?: Subscription;
  categories$?: Observable<Category[]>;
  user?: User;

  constructor(private contactsService: ContactService,
    private router: Router,
    private categoryService: CategoryService,
    private authService: AuthService) {
    this.model = {
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      dateOfBirth: new Date(),
      category: ''
    }
  }
  ngOnInit(): void {
    this.categories$= this.categoryService.getAllCategories();
                //get user
                this.userSubscription= this.authService.user().subscribe({
                  next: (response) =>{
                    this.user = response;
                  }
                });
                this.user = this.authService.getUser();
  }


  onFormSubmit():void {
    //with two way model bindingn - Create contact
    console.log(this.model);
    this.contactSubscribtion = this.contactsService.createContact(this.model).subscribe({
      next: (resposne) =>{
        if(this.user?.roles.includes("Writer")){
          this.router.navigateByUrl('/admin/contacts');
        } else{
          this.router.navigateByUrl('/');
        }

      }
    });
  }

  ngOnDestroy(): void {
    this.contactSubscribtion?.unsubscribe();
    this.userSubscription?.unsubscribe();
  }

}
