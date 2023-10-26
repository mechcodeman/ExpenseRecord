import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { ExpenseItemComponent } from './expense-item/expense-item.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: "homepage", component: HomePageComponent },
  { path: "expense-item", component: ExpenseItemComponent },
  { path: "", redirectTo: "/homepage", pathMatch: "full" },
  { path: "**", component: NotFoundComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
