import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { ContactListComponent } from './features/contact/contact-list/contact-list.component';
import { AddContactComponent } from './features/contact/add-contact/add-contact.component';
import { EditContactComponent } from './features/contact/edit-contact/edit-contact.component';
import { HomeComponent } from './features/public/home/home.component';
import { ContactDetailsComponent } from './features/public/contact-details/contact-details.component';
import { LoginComponent } from './features/auth/login/login.component';
import { authGuard } from './features/auth/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'contact/:id',
    component: ContactDetailsComponent
  },
  {
    path: 'admin/categories',
    component: CategoryListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/categories/:id',
    component: EditCategoryComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/contacts',
    component: ContactListComponent,
    canActivate: [authGuard]

  },
  {
    path: 'admin/contacts/add',
    component: AddContactComponent,
    canActivate: [authGuard]

  },
  {
    path: 'contacts/add',
    component: AddContactComponent

  },
  {
    path: 'admin/contacts/:id',
    component: EditContactComponent,
    canActivate: [authGuard]
  },
  {
    path: 'contacts/:id',
    component: EditContactComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
