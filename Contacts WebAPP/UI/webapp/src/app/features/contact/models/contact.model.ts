import { Category } from "../../category/models/category.model";

export interface Contact{
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    dateOfBirth: Date;
    categoryOption: Category;
}