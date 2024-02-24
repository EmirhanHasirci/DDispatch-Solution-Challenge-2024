import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { SidebarUserComponent } from './sidebar-user/sidebar-user.component';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dispatch-layout',
  standalone: true,
  imports: [SharedModule, SidebarUserComponent],
  templateUrl: './dispatch-layout.component.html',
  styleUrls: ['./dispatch-layout.component.scss']
})
export class DispatchLayoutComponent {
constructor(private service:UserServicesService,private route:Router){

}
  logout(){
      this.service.logout();
      this.route.navigateByUrl("/Login")
  }
  ngOnInit() {
    const body: HTMLElement = document.querySelector('body')!;
    const sidebar: HTMLElement = body.querySelector('nav')!;
    const toggle: HTMLElement = body.querySelector(".toggle")!;
    const searchBtn: HTMLElement = body.querySelector(".search-box")!;
    const userInformation: HTMLElement = body.querySelector(".user_information")!;
   
    if (body && sidebar && toggle && searchBtn) {
      toggle.addEventListener("click", () => {
        sidebar.classList.toggle("close");
        userInformation.classList.toggle("d-none");
      });

      searchBtn.addEventListener("click", () => {
        sidebar.classList.remove("close");
      });


    }

  }
}
