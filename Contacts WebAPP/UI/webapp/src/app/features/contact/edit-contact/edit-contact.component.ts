import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact.model';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { UpdateContact } from '../models/update-contact.model';
import { User } from '../../auth/models/user.model';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit, OnDestroy{
  id: string | null = null;
  routeSubscription?: Subscription;
  updateContactSubscription?: Subscription;
  getContactSubscription?: Subscription;
  deleteSubscription?: Subscription;

  model?: Contact;
  categories$?: Observable<Category[]>;
  selectedCategory?: string;
  user?: User;
  userSubscription?: Subscription;

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private categoryService: CategoryService,
    private router: Router,
    private authService: AuthService){}


  ngOnInit(): void {
     this.categories$ = this.categoryService.getAllCategories();
    this.routeSubscription=  this.route.paramMap.subscribe({
      next: (params) =>{
        this.id = params.get('id');

        //get contact from API
        if(this.id){
          this.getContactSubscription = this.contactService.getContactById(this.id).subscribe({
            next: (response) =>{
              this.model = response;
              this.selectedCategory = response.categoryOption.id
            }
          })
        }      

      }
    })
            //get user
            this.userSubscription= this.authService.user().subscribe({
              next: (response) =>{
                this.user = response;
              }
            });
            this.user = this.authService.getUser();
  }

  onFormSubmit(): void{
    //convert this model to update request object
    if(this.model && this.id){
      var updateContact: UpdateContact ={
        firstName: this.model.firstName,
        lastName: this.model.lastName,
        email: this.model.email,
        phone: this.model.phone,
        dateOfBirth: this.model.dateOfBirth,
        category: this.selectedCategory ?? '',
      };
      this.updateContactSubscription= this.contactService.updateCoontact(this.id, updateContact).subscribe({
        next: (resposne) =>{
          console.log(this.model?.categoryOption.id);
          if(this.user?.roles.includes('Writer'))
          {
            this.router.navigateByUrl('/admin/contacts');
          }else{
            this.router.navigateByUrl('/');
          }
          
        }
      });
    }
  }
  onClick():void{
    if(this.id){
      this.deleteSubscription= this.contactService.deleteContact(this.id).subscribe({
        next: (resposne) =>{
          if(this.user?.roles.includes('Writer')){
            this.router.navigateByUrl('/admin/contacts')
          } else {
            this.router.navigateByUrl('/')
          }

        }
      })
    }

  }

  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.updateContactSubscription?.unsubscribe();
    this.getContactSubscription?.unsubscribe();
    this.deleteSubscription?.unsubscribe();
    this.userSubscription?.unsubscribe();
  }

}
