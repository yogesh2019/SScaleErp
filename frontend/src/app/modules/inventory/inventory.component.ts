import { Component, OnInit } from '@angular/core';
import { InventoryService, InventoryItem } from './inventory.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html'
})
export class InventoryComponent implements OnInit {

  items: InventoryItem[] = [];
  loading = true;

  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.inventoryService.getInventory().subscribe({
      next: (data) => {
        this.items = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error fetching inventory', err);
        this.loading = false;
      }
    });
  }
}
