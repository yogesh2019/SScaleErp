import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface InventoryItem {
  productCode: string;
  productName: string;
  category: string;
  stockQty: number;
  warehouse: string;
}

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private apiUrl = '/api/inventory';

  constructor(private http: HttpClient) {}

  getInventory(): Observable<InventoryItem[]> {
    return this.http.get<InventoryItem[]>(this.apiUrl);
  }
}
