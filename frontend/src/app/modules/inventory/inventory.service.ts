import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export interface InventoryItem {
  id: number;
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

  private apiUrl = `${environment.apiBaseUrl}/api/inventory`;

  constructor(private http: HttpClient) {}

  getInventory(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}