import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InventoryComponent } from './modules/inventory/inventory.component';
import { OrderComponent } from './modules/order/order.component';
import { ReportsComponent } from './modules/reports/reports.component';

const routes: Routes = [
  { path: '', redirectTo: 'inventory', pathMatch: 'full' },
  { path: 'inventory', component: InventoryComponent },
  { path: 'orders', component: OrderComponent },
  { path: 'reports', component: ReportsComponent },
  { path: '**', redirectTo: 'inventory' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
