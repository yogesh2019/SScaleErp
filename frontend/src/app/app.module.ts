import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InventoryComponent } from './modules/inventory/inventory.component';
import { OrderComponent } from './modules/order/order.component';
import { ReportsComponent } from './modules/reports/reports.component';

@NgModule({
  declarations: [
    AppComponent,
    InventoryComponent,
    OrderComponent,
    ReportsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
