import { Component } from '@angular/core';
import { StoryService } from './services/story/story.service';
import { Story } from './models/story';
import { MatDialog } from '@angular/material/dialog';
import { DialogCreateComponent } from './components/dialog-create/dialog-create.component';
import { BehaviorSubject } from 'rxjs';
import { StoryUpdate } from './models/story-update';
import { StoryCreate } from './models/story-create';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  stories: Story[] = []
  userId: number = 0
  storiesSubject: BehaviorSubject<Story[]> = new BehaviorSubject<Story[]>([])

  constructor(private storyService: StoryService, public dialog: MatDialog){
    this.getAllStories();
  }

  getAllStories(){
    this.storyService.getAll().subscribe((result) => {
      this.stories = result;
      this.storiesSubject.next(result)
    })
  }

  showCreateDialog(){
    let dialogRef = this.dialog.open(DialogCreateComponent, {
      width: "450px"
    })

    dialogRef.afterClosed().subscribe((data) => {
      this.add(data)
    })
  }

  delete(id: number){
    this.storyService.delete(id).subscribe(() => {
      this.getAllStories()
    })
  }
  
  update(storyUpdate: StoryUpdate){
    this.storyService.update(storyUpdate.id, storyUpdate.title, storyUpdate.description, storyUpdate.department).subscribe(()=>{
      this.getAllStories()
    })
  }

  add(storyCreat: StoryCreate){
    this.storyService.addStory(storyCreat).subscribe(() =>{
      this.getAllStories()
    })
  }

  getUserId(userId: number){
    this.userId = userId
  }
}
