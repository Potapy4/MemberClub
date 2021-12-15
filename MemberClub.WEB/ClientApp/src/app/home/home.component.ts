import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '../base/base.component';
import { UserService } from '../services/user.service';
import { User } from '../models/user'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit {
  public users: User[] = [];
  public userForm: FormGroup;
  public requestError: string;

  constructor(
    private userService: UserService
  ) {
    super();
  }

  ngOnInit(): void {
    this.loadUsers();

    this.userForm = new FormGroup({
      name: new FormControl(
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50)
          ]
        }
      ),
      email: new FormControl(
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ]
      )
    });
  }

  loadUsers() {
    this.userService
      .getUsers()
      .pipe(this.untilThis)
      .subscribe(users => {
        this.users = users;
      }, error => {
        console.log(error);
      });
  }

  saveUser(user: User) {
    this.requestError = '';
    this.userService.createUser(user)
      .subscribe(
        () => {
          this.loadUsers();
        },
        error => {
          this.requestError = error.error;
          console.log(error);
        }
      );
  }

  clearForm(){
    this.userForm.reset();
    this.requestError = '';
    Object.keys(this.userForm.controls).forEach(key => {
          this.userForm?.get(key)?.setErrors(null) ;
        });
  }

  get name() {
    return this.userForm.controls.name;
  }

  get email() {
    return this.userForm.controls.email;
  }
}
