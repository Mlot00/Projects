import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { UpdateCategoryRequest } from '../models/update-category-request';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy{

  id: string | null =null
  paramsSubscribtion?: Subscription
  editCategorySubscription?: Subscription
  category?: Category

  constructor(private route: ActivatedRoute,
    private categoryService: CategoryService,
    private router: Router) {
  }


  ngOnInit(): void {
    this.paramsSubscribtion=  this.route.paramMap.subscribe({
      next:(params) =>
      {
        this.id = params.get('id');

        if(this.id)
        {
          this.categoryService.getCategoryById(this.id).subscribe({
            next: (response) =>{
              this.category = response;
            }
          })
        }
      }
    })
  }

  onFormSubmit(): void{
    const updateCategoryRequest: UpdateCategoryRequest = {
      name: this.category?.name ?? '',
    };

    if (this.id) {
      this.editCategorySubscription = this.categoryService.updateCategory(this.id, updateCategoryRequest).subscribe({
        next:(resposne) =>{
          this.router.navigateByUrl('/admin/categories');
        }
      })
    }
  }

  onDelete():void{
    if(this.id){
      this.categoryService.deleteCategory(this.id).subscribe({
        next: (resposne) =>{
          this.router.navigateByUrl('/admin/categories');
        }
      })
    }

  }

  ngOnDestroy(): void {
    this.paramsSubscribtion?.unsubscribe();
    this.editCategorySubscription?.unsubscribe();
  }
}
