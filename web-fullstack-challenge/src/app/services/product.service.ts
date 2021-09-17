import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string = 'https://api-fullstack-challenge-2021.herokuapp.com';

  // URL DEV
  //baseUrl: string = 'https://localhost:44373';

  constructor(private http: HttpClient, private api: ApiService) { }

  recuperarProductInfo(): Observable<any> {
    return this.http.get(`${this.baseUrl}/products/retrieve`)
      .pipe(
        take(1),
        map(result => result)
      );
  }

  getProductByFiltro(obj: any): Observable<any> {
    return this.http.get(this.api.request('/products', 'filtro', obj, true))
      .pipe(
        take(1),
        map(result => result)
      );
  }

  createProduct(obj: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/product`, obj)
      .pipe(
        take(1),
        map(result => result)
      );
  }

  updateOneProduct(obj: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/product/update/${obj.code}`, obj)
      .pipe(
        take(1),
        map(result => result)
      );
  }

  deleteProduct(id: any): Observable<any> {
    return this.http.delete(`${this.baseUrl}/product/delete/${id}`)
      .pipe(
        take(1),
        map(result => result)
      );
  }

  deleteAllProducts(): Observable<any> {
    return this.http.delete(`${this.baseUrl}/product/deleteall`)
      .pipe(
        take(1),
        map(result => result)
      );
  }
}
