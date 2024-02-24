import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { AppUserDto } from 'src/app/Models/DTOS/User/app-user-dto';

@Component({
  selector: 'app-sidebar-user',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './sidebar-user.component.html',
  styleUrls: ['./sidebar-user.component.scss']
})
export class SidebarUserComponent {
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
}
