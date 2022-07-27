import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ItemModel } from '../models/item.model';

@Injectable({
  providedIn: 'root'
})
export class RetailerService {

  private url: string;

  private _retailers: Promise<ItemModel[]>;

  get retailers(): Promise<ItemModel[]> {
    if (!this._retailers) {
      this._retailers = this.getAll();
    }
    return this._retailers;
  }

  constructor(private httpClient: HttpClient) {
    this.url = `${environment.apiUrl}/retailer`;
  }

  public getAll(): Promise<ItemModel[]> {
    return this.httpClient.get<ItemModel[]>(this.url).toPromise();
  }
}
