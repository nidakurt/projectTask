import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent {
  @Input() category? : Category;
  @Output() categoriesUpdated = new EventEmitter<Category[]>();

  constructor(private categoryService: CategoryService) {}
  ngOnInit(): void {
    
  }

  updateCategory(category:Category){
    this.categoryService.updateCategory(category).subscribe((categories: Category[]) => this.categoriesUpdated.emit(categories))
  }

  deleteCategory(category:Category){
    this.categoryService.deleteCategory(category).subscribe((categories: Category[]) => this.categoriesUpdated.emit(categories))
  }

  createCategory(category:Category){
    this.categoryService.createCategory(category).subscribe((categories: Category[]) => this.categoriesUpdated.emit(categories))
  }
}
