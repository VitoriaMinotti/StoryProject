import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { StoryCreate } from '../../models/story-create';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dialog-create',
  templateUrl: './dialog-create.component.html',
  styleUrl: './dialog-create.component.css'
})
export class DialogCreateComponent {
  title = new FormControl ('', [Validators.required])
  description = new FormControl('', [Validators.required])
  department = new FormControl('', [Validators.required])

  constructor(public dialogRef: MatDialogRef<DialogCreateComponent>){}

  closeDialog(){
    this.dialogRef.close('Closed')
  }

  creatStory(){
    const story: StoryCreate = new StoryCreate(this.title.value!, this.description.value!, this.department.value!)
    this.dialogRef.close(story)
  }
}
