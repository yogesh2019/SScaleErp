import { Component, OnInit } from '@angular/core';
import { InventoryService, InventoryItem, PagedResult } from './inventory.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html'
})
export class InventoryComponent implements OnInit {

  items: InventoryItem[] = [];
  totalRecords = 0;
  page = 1;
  pageSize = 5;
  loading = true;

  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.loading = true;

    this.inventoryService.getInventory(this.page, this.pageSize)
      .subscribe({
        next: (result: PagedResult) => {
          this.items = result.data;
          this.totalRecords = result.totalRecords;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error fetching inventory', err);
          this.loading = false;
        }
      });
  }

  nextPage(): void {
    if (this.page * this.pageSize < this.totalRecords) {
      this.page++;
      this.loadData();
    }
  }

  prevPage(): void {
    if (this.page > 1) {
      this.page--;
      this.loadData();
    }
  }
}