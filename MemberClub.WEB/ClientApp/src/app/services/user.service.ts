import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { User } from '../models/user'

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = 'user';

    constructor(
        private httpService: HttpService
    ) { }

    getUsers() {
        return this.httpService.getRequest<User[]>(this.apiPrefix);
    }

    createUser(user: User) {
        return this.httpService.postRequest<User>(this.apiPrefix, user);
    }

}