import { Component } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { NgForm } from '@angular/forms';
import { UserSignUpDto } from 'src/app/Models/DTOS/User/user-sign-up-dto';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private service:UserServicesService,private route:Router){

  }
  Add(form:NgForm){
    let fv=form.value;
    let userRegister:UserSignUpDto=new UserSignUpDto();
    userRegister.email=fv["mail"]
    userRegister.name=fv["name"]
    userRegister.surname=fv["surname"]
    userRegister.username=fv["username"]
    userRegister.password=fv["password"]
    userRegister.confirmPassword=fv["confirmPassword"]
    userRegister.tc=fv["tc"]
    this.service.register(userRegister).subscribe(x=>{
      if(x.errors!==null){
        this.route.navigateByUrl("/Login")
      }
    });
    this.route.navigateByUrl("/Login")

  }
}
