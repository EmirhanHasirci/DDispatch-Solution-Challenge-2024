import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserServicesService } from 'src/app/Services/user-services.service';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { AppUser } from 'src/app/Models/app-user';
import { AppUserDto } from 'src/app/Models/DTOS/User/app-user-dto';
import { Cities } from 'src/app/Common/cities';

@Component({
  selector: 'app-valid-user',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './valid-user.component.html',
  styleUrls: ['./valid-user.component.scss']
})
export class ValidUserComponent {
  constructor(private userService: UserServicesService) { }
  inputTc: string = "";
  uTc: string="";
  uName: string;
  uSurname: string;
  uUsername: string;
  uPicture: string="";
  uMail: string;
  uCity:string;
  uPhone:string
  uBirthdate:string;
  cities:Cities=new Cities();
  
  search() {
    let usera: any = this.userService.getUserByTc(this.inputTc).subscribe(user=>{
      this.uTc = user.tc;
      this.uName = user.name;
      this.uSurname = user.surname;
      this.uUsername = user.userName;
      this.uPicture = user.picture;
      this.uMail = user.email;
      this.uPhone=user.phoneNumber;
      this.uCity=user.city;
      this.uBirthdate=user.birthDate;               
    });
       
  }


}
