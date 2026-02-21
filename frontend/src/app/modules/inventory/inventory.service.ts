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

export interface PagedResult {
  totalRecords: number;
  page: number;
  pageSize: number;
  data: InventoryItem[];
}

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private apiUrl = `${environment.apiBaseUrl}/api/inventory`;

  constructor(private http: HttpClient) {}

  getInventory(page: number = 1, pageSize: number = 5): Observable<PagedResult> {
    return this.http.get<PagedResult>(
      `${this.apiUrl}?page=${page}&pageSize=${pageSize}`
    );
  }
}