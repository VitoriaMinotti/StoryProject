import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Story } from '../../models/story';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  post: any;
  getUsers() {
    throw new Error('Method not implemented.');
  }

  url = 'https://localhost:7004/api/Users'

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getUser(): Observable<any[]> {
    return this.httpClient.get<any[]>(this.url)
  }
}
