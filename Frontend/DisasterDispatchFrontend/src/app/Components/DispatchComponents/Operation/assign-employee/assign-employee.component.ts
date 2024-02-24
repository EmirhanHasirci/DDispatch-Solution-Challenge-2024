import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmergencyReportService } from 'src/app/Services/emergency-report.service';
import { EmergencyReportDto } from 'src/app/Models/DTOS/EmergencyReport/emergency-report-dto';
import { OperationService } from 'src/app/Services/operation.service';
import { CustomOperationDto } from 'src/app/Models/DTOS/CustomOperation/custom-operation-dto';
import { AppUserDto } from 'src/app/Models/DTOS/User/app-user-dto';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { UserStatus } from 'src/app/Common/userStatus';
import { Cities } from 'src/app/Common/cities';
import { CreateDto } from 'src/app/Models/DTOS/OperationEmployee/create-dto';

@Component({
  selector: 'app-assign-employee',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './assign-employee.component.html',
  styleUrls: ['./assign-employee.component.scss']
})
export class AssignEmployeeComponent {
  customOperationId: string;
  customOperation: CustomOperationDto
  activeUsersByCity: AppUserDto[]
  cityId: string
  cities:Cities=new Cities();
  userStatus: UserStatus = new UserStatus();
  selectedUsers: string[] = []
  selected:boolean=false;
  constructor(private _activated: ActivatedRoute, private _operation: OperationService, private _user: UserServicesService) {
    this._activated.params.subscribe(res => {
      this.customOperationId = res["id"];
      this.cityId = res["city"];
      this.getById();
      this.getActiveUsersByCity();
    })
  }
  getById() {
    this._operation.getActiveOperationById(this.customOperationId).subscribe(res => {
      this.customOperation = res;
    })
  }
  getActiveUsersByCity() {
    this._user.getUsersByActiveAndCity(this.cities.searchCityById(this.cityId)?.name!).subscribe(x => {
      this.activeUsersByCity = x;
      console.log(x);
      
    })
  }
  ListCheck(id: string) {
    const index = this.selectedUsers.indexOf(id);
    if (index === -1) {
      this.selectedUsers.push(id);
      this.selected=true;
    } else {
      this.selectedUsers.splice(index, 1);
      this.selected=false;
    }
  }
  Add(){
    let EmployeeCreateDto:CreateDto[]=[]
    for(let id of this.selectedUsers){
      let temp:CreateDto=new CreateDto();
      temp.appUserId=id;
      temp.customOperationId=this.customOperationId;
      EmployeeCreateDto.push(temp);
    }
    this._operation.postEmployeeAddRangeAsync(EmployeeCreateDto)
    this._operation.postChangeStatusOnMission(this.customOperationId)
  }

}
