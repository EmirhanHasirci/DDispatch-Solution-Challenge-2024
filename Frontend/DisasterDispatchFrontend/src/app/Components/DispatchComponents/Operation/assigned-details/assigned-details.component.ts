import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { OperationService } from 'src/app/Services/operation.service';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { CustomOperationDto } from 'src/app/Models/DTOS/CustomOperation/custom-operation-dto';
import { OperationEmployeeDto } from 'src/app/Models/DTOS/OperationEmployee/operation-employee-dto';
import { UserStatus } from 'src/app/Common/userStatus';

@Component({
  selector: 'app-assigned-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './assigned-details.component.html',
  styleUrls: ['./assigned-details.component.scss']
})
export class AssignedDetailsComponent {
  customOperationId:string;
  city:string;
  operationEmployee:OperationEmployeeDto[]
  userStatus: UserStatus = new UserStatus();
  constructor(private _activated: ActivatedRoute, private _operation:OperationService, private _user: UserServicesService) {
    this._activated.params.subscribe(res => {
      this.customOperationId = res["id"];
      this.city = res["city"];
      this.getById();
    })
  }
  getById() {
    this._operation.getOnMissionUsers(this.customOperationId).subscribe(res => {
      this.operationEmployee = res;
    })
  }
}
