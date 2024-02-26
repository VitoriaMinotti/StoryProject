import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Votes } from '../../models/votes';

@Injectable({
  providedIn: 'root'
})
export class VotesService {

  url = 'https://localhost:7004/api/Votes';

  constructor(private http: HttpClient) { }

  getVotes(): Observable<Votes[]> {
    return this.http.get<Votes[]>(this.url)
  }

  addVote(like: boolean, UserID: number, StoryID: number): Observable<any> {
    const params: HttpParams = new HttpParams().set('Like', like.toString()).set('UserID', UserID.toString()).set('StoryID', StoryID.toString());
    return this.http.post(this.url, null, {params: params})
    
  }
}
