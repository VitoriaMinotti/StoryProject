import { Component } from '@angular/core';
import { StoryService } from './services/story/story.service';
import { Story } from './models/story';
import { MatDialog } from '@angular/material/dialog';
import { DialogCreateComponent } from './components/dialog-create/dialog-create.component';
import { BehaviorSubject } from 'rxjs';
import { StoryUpdate } from './models/story-update';
import { StoryCreate } from './models/story-create';
import { Votes } from './models/votes';
import { VotesService } from './services/vote/votes.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  stories: Story[] = []
  votes!: Votes[];
  storiesSubject: BehaviorSubject<Story[]> = new BehaviorSubject<Story[]>([])

  constructor(private storyService: StoryService, public dialog: MatDialog, private voteService: VotesService){
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

  getVotes() {
    this.voteService.getVotes().subscribe((data: Votes[]) => {
      this.votes = data;
    });
  }
 
  addVote(like: boolean, storyId : number, userID: string) {
    this.voteService.addVote(like, storyId, userID).subscribe(response => {
      this.getAllStories();
    });
  }
}
