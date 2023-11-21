import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../contact/services/contact.service';
import { Observable, Subscription } from 'rxjs';
import { Contact } from '../../contact/models/contact.model';
import { AuthService } from '../../auth/services/auth.service';
import { User } from '../../auth/models/user.model';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit, OnDestroy{

  id: string | null =null;
  contact$?: Observable<Contact>;
  deleteSubscription?: Subscription;
  routeSubscription?: Subscription;
  userSubscfription?: Subscription;
  user?: User;

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router,
    private authService: AuthService){

  }


  ngOnInit(): void {
    //add real contacts id to my variable id
    this.routeSubscription = this.route.paramMap.subscribe({
      next: (params) =>{
        this.id = params.get("id");
      }
    });
    //fetch contact by id
    if(this.id){
      this.contact$ = this.contactService.getContactById(this.id);
    }

    //get user
    this.userSubscfription= this.authService.user().subscribe({
      next: (response) =>{
        this.user = response;
      }
    });
    this.user = this.authService.getUser();
  }

  onClick(concact: string): void {
    this.id = concact;
    if (this.id) {
      this.deleteSubscription = this.contactService.deleteContact(this.id).subscribe({
        next: (resposne) => {
          if(this.user?.roles.includes('Writer')){
            this.router.navigateByUrl("/admin/contacts");
          } else{
            this.router.navigateByUrl("/");
          }
        }
      })
    }
  }

  ngOnDestroy(): void {
    this.deleteSubscription?.unsubscribe();
    this.routeSubscription?.unsubscribe();
    this.userSubscfription?.unsubscribe();
  }
}
