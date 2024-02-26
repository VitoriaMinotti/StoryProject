import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { StoryService } from '../../services/story/story.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { StoryUpdate } from '../../models/story-update';

@Component({
  selector: 'app-dialog-update',
  templateUrl: './dialog-update.component.html',
  styleUrl: './dialog-update.component.css'
})
export class DialogUpdateComponent {
  storyId: number = 0
  title = new FormControl('', [Validators.required])
  description = new FormControl('', [Validators.required])
  department = new FormControl('', [Validators.required])

  constructor(public dialogRef: MatDialogRef<DialogUpdateComponent>, private storyService: StoryService, @Inject(MAT_DIALOG_DATA) public data: { id: number }) {
    this.storyId = data.id
    this.storyService.getById(data.id).subscribe((story) => {
      this.title.setValue(story.title)
      this.description.setValue(story.description)
      this.department.setValue(story.department)
    });
  }

  closeDialog() {
    this.dialogRef.close('Closed')
  }

  updateData(){
    const story: StoryUpdate = new StoryUpdate(this.storyId, this.title.value!, this.description.value!, this.department.value!)
    this.dialogRef.close(story)
  }
}
