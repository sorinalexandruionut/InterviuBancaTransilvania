import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ItemModel } from '../models/item.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private url: string;

  private _products: Promise<ItemModel[]>;

  get products(): Promise<ItemModel[]> {
    if (!this._products) {
      this._products = this.getAll();
    }
    return this._products;
  }

  constructor(private httpClient: HttpClient) {
    this.url = `${environment.apiUrl}/product`;
  }

  public getAll(): Promise<ItemModel[]> {
    return this.httpClient.get<ItemModel[]>(this.url).toPromise();
  }

}
