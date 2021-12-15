import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public users: User[] = [];
  public userForm: FormGroup;
  private baseUrl: string;
  private http: HttpClient;
  public formError: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
      this.http = http;
      this.formError = '';

      this.LoadUsers();
    }

      ngOnInit() {
        this.userForm = new FormGroup({
          name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
          email: new FormControl('', [Validators.required, Validators.maxLength(100)])
        });
      }

        get getName(){
      	return this.userForm.get('name')
        }

          get getEmail(){
        	return this.userForm.get('email')
          }

    LoadUsers(){
          this.http.get<User[]>(this.baseUrl + 'user').subscribe(result => {
            this.users = result;
          }, error => console.error(error));
    }

    SaveUser(user: User) {
      this.http.post<any>(this.baseUrl + 'user', user).subscribe(result => {
        this.LoadUsers();
      }, error => console.log(error.error))
    }
}

interface User {
  id: number;
  name: string;
  email: string;
  registrationDate: string;
}
