import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { AppUserDto } from 'src/app/Models/DTOS/User/app-user-dto';
import { Cities } from 'src/app/Common/cities';
import { Gender } from 'src/app/Common/gender';
import { UserStatus } from 'src/app/Common/userStatus';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { StatusChangeDto } from 'src/app/Models/DTOS/User/status-change-dto';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {
  userst:UserStatus=new UserStatus();
  appUser: AppUserDto;
  Username: string
  userId:string 
  constructor(private userService: UserServicesService) {
    this.Username = localStorage.getItem("currentUsername")?.toString()!;
    this.userId = localStorage.getItem("currentId")?.toString()!;
    this.Username = this.Username.substring(1, this.Username.length - 1) 
    this.userId=this.userId.substring(1,this.userId.length-1)       
    this.getByUsername();
  
  }
  getByUsername() {
    this.userService.getUserByName(this.Username).subscribe(x => {
      this.appUser = x;
    })
  }
  
  gender: Gender = new Gender();
  
  changeStatus(status:string){
    let dto:StatusChangeDto=new StatusChangeDto();
    dto.userid=this.userId;
    dto.value=status;
    this.userService.postChangeStatus(dto);
    this.getByUsername();
  }
}
