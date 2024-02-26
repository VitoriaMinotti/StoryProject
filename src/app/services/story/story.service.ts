import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Story } from '../../models/story';
import { StoryCreate } from '../../models/story-create';

@Injectable({
  providedIn: 'root'
})
export class StoryService {

  Url = 'https://localhost:7004/api/Stories'

  constructor(private httpClient: HttpClient) { }

  getAll(){
    return this.httpClient.get<Story[]>(this.Url);
  }

  getById(storyId: number){
    return this.httpClient.get<Story>(`${this.Url}/${storyId}`)
  }

  addStory(storyCreate: StoryCreate){
    const newStory: StoryCreate = new StoryCreate(storyCreate.title, storyCreate.description, storyCreate.department)
    return this.httpClient.post(this.Url, newStory);
  }

  delete(storyId: number){
    return this.httpClient.delete<Story>(`${this.Url}/${storyId}`)
  }

  update(storyId: number, title: string, description: string, department: string ) {
    return this.httpClient.put(`${this.Url}/${storyId}`, {title, description, department})
  }
}
