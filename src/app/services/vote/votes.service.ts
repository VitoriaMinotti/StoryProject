import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Votes } from '../../models/votes';

@Injectable({
  providedIn: 'root'
})
export class VotesService {

  url = 'https://localhost:7004/api/Votes';
 
  constructor(private http: HttpClient) {}
 
  getVotes(): Observable<Votes[]> {
    return this.http.get<Votes[]>(this.url)
  }

  addVote(like: boolean, storyId: number, userID: string): Observable<any> {
    const url = `${this.url}`;
    const body = {
      like,
      storyId,
      userID
    };
 
    return this.http.post(url, body);
  }
}
