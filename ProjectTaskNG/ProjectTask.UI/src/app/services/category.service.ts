import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environments';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private url ="Category";
  constructor(private http: HttpClient) { }

  public getCategory(): Observable<Category[]>{
    return this.http.get<Category[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateCategory(category: Category): Observable<Category[]>{
    return this.http.put<Category[]>(`${environment.apiUrl}/${this.url}`, category);
  }

  public createCategory(category: Category): Observable<Category[]>{
    return this.http.post<Category[]>(`${environment.apiUrl}/${this.url}`, category);
  }

  public deleteCategory(category: Category): Observable<Category[]>{
    return this.http.delete<Category[]>(`${environment.apiUrl}/${this.url}/${category.id}`);
  }
}
