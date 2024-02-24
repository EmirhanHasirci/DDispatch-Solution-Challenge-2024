import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserStatus } from 'src/app/Common/userStatus';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { Gender } from 'src/app/Common/gender';
import { AppUserEditDto } from 'src/app/Models/DTOS/User/app-user-edit-dto';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { Cities } from 'src/app/Common/cities';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent {
  Username: string
  userId: string
  userst: UserStatus = new UserStatus();
  appUser: AppUserEditDto
  cities: Cities = new Cities();
  genders: Gender = new Gender();
  constructor(private userService: UserServicesService, private router: Router) {
    this.Username = localStorage.getItem("currentUsername")?.toString()!;
    this.userId = localStorage.getItem("currentId")?.toString()!;
    this.Username = this.Username.substring(1, this.Username.length - 1)
    this.userId=this.userId.substring(1,this.Username.length-1);
    this.getByUsername();
  }
  selectedCity: string = "";
  selectedGender: string = "";
  gender: Gender = new Gender();
  getByUsername() {
    this.userService.getUserByNameForEdit(this.Username).subscribe(x => {
      this.appUser = x;
    })
  }

  selectCity(target: any) {
    this.selectedCity = target.value;    
  }
  selectGender(target: any) {
    this.selectedGender = target.value;            
  }
  update(form: NgForm) {
    let dto: AppUserEditDto = new AppUserEditDto();
    let fv = form.value;
    dto.birthDate = fv["birthDate"];
    dto.name = fv["name"];
    dto.surname = fv["surname"];
    dto.userName = this.Username;
    dto.city = this.selectedCity;
    dto.gender = this.selectedGender;
    console.log(dto);

    this.userService.putUserEdit(dto);
    this.router.navigateByUrl("/Dispatch/User")

  }
}
