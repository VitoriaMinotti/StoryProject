import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Story } from '../../models/story';
import { MatDialog } from '@angular/material/dialog';
import { DialogUpdateComponent } from '../dialog-update/dialog-update.component';
import { StoryUpdate } from '../../models/story-update';
import { VotesService } from '../../services/vote/votes.service';
import { Votes } from '../../models/votes';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.css'
})
export class CardsComponent {
  stories: Story[] = [];
  story: Story[] = [];
  votes: Votes[] = [];
  @Input() storyTitle: string = ''
  @Input() storyDescription: string = ''
  @Input() storyDepartment: string = ''
  @Input() storyId: number = 0
  @Input() userId: number = 0
  @Output() storyToDelete: EventEmitter<number> = new EventEmitter<number>()
  @Output() storyToUpdate: EventEmitter<StoryUpdate> = new EventEmitter<StoryUpdate>()

  constructor(public dialog: MatDialog, private voteService: VotesService){
  }

  delete(id: number){
    this.storyToDelete.emit(id)
  }

  showUpdateDialog(){
    let dialogRef = this.dialog.open(DialogUpdateComponent, {
      width: "450px", 
      data: {
        id: this.storyId        
      }}
    )    
    dialogRef.afterClosed().subscribe((result) => {
      this.storyToUpdate.emit(result)
    })
  }

  addVote(Like: boolean){
    this.voteService.addVote(Like, this.userId, this.storyId).subscribe(() => {
    });
  }

}
