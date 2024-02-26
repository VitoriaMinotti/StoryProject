import { Component, EventEmitter, Input, Output } from '@angular/core';
import { StoryService } from '../../services/story/story.service';
import { Story } from '../../models/story';
import { BehaviorSubject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { DialogUpdateComponent } from '../dialog-update/dialog-update.component';
import { DialogRef } from '@angular/cdk/dialog';
import { StoryUpdate } from '../../models/story-update';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.css'
})
export class CardsComponent {
  stories: Story[] = [];
  story: Story[] = [];
  @Input() storyTitle: string = ''
  @Input() storyDescription: string = ''
  @Input() storyDepartment: string = ''
  @Input() storyId: number = 0
  @Output() storyToDelete: EventEmitter<number> = new EventEmitter<number>()
  @Output() storyToUpdate: EventEmitter<StoryUpdate> = new EventEmitter<StoryUpdate>() 
  constructor(public dialog: MatDialog){
  }

  delete(id: number){
    this.storyToDelete.emit(id)
  }

  showUpdateDialog(){
    let dialogRef = this.dialog.open(DialogUpdateComponent, {
      width: "450px", 
      data: {
        id: this.storyId        
      }
    }
    )    

    dialogRef.afterClosed().subscribe((result) => {
      this.storyToUpdate.emit(result)
    })
  }
}
