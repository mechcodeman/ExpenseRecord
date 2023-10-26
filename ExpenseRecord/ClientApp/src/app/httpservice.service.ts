import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { catchError, map, tap } from 'rxjs/operators';
 
export interface Item{
  id: string,
  description: string,
  type: string,
  amount: string,
  createdTime: string
}

@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  url='https://localhost:7081/api/v1/expenserecord'

  constructor(private http:HttpClient) { }

  getAll(): Observable<Item[]> {
    return this.http.get<Item[]>(this.url);
  }

  updateItem(item:Item):Observable<any>{ 
    const new_url = `${this.url}/${item.id}`
    return this.http.put(new_url, item, this.httpOptions)
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  addItem(item: Item): Observable<Item> {
    return this.http.post<Item>(this.url, item, this.httpOptions)
  }

  deleteItem(id: string): Observable<Item> {
    const new_url = `${this.url}/${id}`;
    return this.http.delete<Item>(new_url, this.httpOptions)
  }
}