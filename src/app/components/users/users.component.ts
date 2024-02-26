import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UsersService } from '../../services/user/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {
  user = {} as User;
  users!: User[];
  visible: boolean = false;

  constructor(private usersService: UsersService) {
    this.getUser()
  }

  getUser() {
    this.usersService.getUser().subscribe(users => {
      this.users = users
    })
  }

}