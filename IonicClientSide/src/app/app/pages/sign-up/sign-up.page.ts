import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {  FormControl, FormGroup, NgModel, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/user';
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.page.html',
  styleUrls: ['./sign-up.page.scss'],
})
export class SignUpPage implements OnInit {
  user: User = new User();

constructor(private router: Router,private userService:UserService) { }

ngOnInit() {}

toHomePage(){
    this.router.navigate(['home']);
}

//לנתב להרשמה בסי שארפ
signUp(){
  this.userService.func(this.user);
}

toMyAccountPage(){
  this.router.navigate(['my-account']);
}

} 
