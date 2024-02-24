import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { NgForm } from '@angular/forms';
import { UserLoginDto } from 'src/app/Models/DTOS/User/user-login-dto';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { Router } from '@angular/router';
import { AppUserDto } from 'src/app/Models/DTOS/User/app-user-dto';
import { CustomResponse } from 'src/app/contracts/custom-response';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private service: UserServicesService,private router:Router) {
    if(localStorage.getItem('currentUsername')!=null){
      this.router.navigateByUrl("/Dispatch/User")
    }
  }
  login(form: NgForm) {
    let fv = form.value;
    let loginDto: UserLoginDto = new UserLoginDto();
    loginDto.tc = fv["tc"];
    loginDto.password = fv["password"];    
    this.service.login(loginDto).subscribe(x=>{
      if(x.errors==null){
        let appUserDto:AppUserDto= new AppUserDto();
         
         appUserDto=x.data as AppUserDto
         console.log(appUserDto);
         
         
         
         localStorage.setItem('currentUsername', JSON.stringify(appUserDto.userName)) ;
         localStorage.setItem('currentId', JSON.stringify(appUserDto.id)) ;
                          
         this.router.navigateByUrl("/Dispatch/User")
       }
    });    
    
    

  }
}
