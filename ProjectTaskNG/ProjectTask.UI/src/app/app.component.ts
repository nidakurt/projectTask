import { Component } from '@angular/core';
import { Category } from './models/category';
import { Product } from './models/product';
import { CategoryService } from './services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjectTask.UI';
  categories: Category[] = [];
  categoryToEdit?: Category
  products: Product[] = [];
  productToEdit?: Product

  constructor (private categoryService: CategoryService){}

  ngOnInit() : void {
    this.categoryService.getCategory().subscribe((result: Category[]) => (this.categories = result));
  }

  updateCategoryList(categories: Category[]){
    this.categories = categories;
  }

  initNewCategory(){
    this.categoryToEdit = new Category();
  }

  editCategory(category:Category){
    this.categoryToEdit = category;
  }

  updateProductList(products: Product[]){
    this.products = products;
  }

  initNewProduct(){
    this.productToEdit = new Product();
  }

  editProduct(product:Product){
    this.productToEdit = product;
  }
}
