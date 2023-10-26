import { Component, OnInit } from '@angular/core';
import { HttpserviceService, Item } from '../httpservice.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  items?: Item[];
  helper?: Item;
  id?: string;
  getSub?:Subscription;
  reloadSub?:Subscription;
  delChildSub?:Subscription;
  constructor(private itemService: HttpserviceService) { }
  
  ngOnInit(): void {
    this.getSub = this.itemService.getAll().subscribe((data) => {
      this.items = [...data];
    }) 
  }
  updateItem(index: number) {
    if(this.items) {
      this.helper = this.items[index];
    }
  }
  onDelete(index: any ) {
    this.id = index;
    if (this.items && this.id) {
      this.delChildSub = this.itemService.deleteItem(this.id).subscribe();
    }
  }
  saveItem() {
    
  }
}
