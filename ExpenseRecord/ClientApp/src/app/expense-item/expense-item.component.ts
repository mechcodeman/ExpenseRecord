import { Component, OnInit } from '@angular/core';
import { HttpserviceService, Item } from '../httpservice.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-expense-item',
  templateUrl: './expense-item.component.html',
  styleUrls: ['./expense-item.component.css']
})
export class ExpenseItemComponent implements OnInit {
  items?: Item[];
  helper?: Item;
  getSub?:Subscription
  reloadSub?:Subscription
  constructor(private itemService: HttpserviceService) { }

  ngOnInit(): void {
    this.getSub = this.itemService.getAll().subscribe((data) => {
      this.items = [...data];
    }) 
  }

  onDelete() {

  }
  saveItem() {
    
  }
}
