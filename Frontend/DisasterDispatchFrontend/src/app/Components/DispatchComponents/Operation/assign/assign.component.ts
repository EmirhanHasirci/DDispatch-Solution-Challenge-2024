import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { EmergencyReportService } from 'src/app/Services/emergency-report.service';
import { EmergencyReportDto } from 'src/app/Models/DTOS/EmergencyReport/emergency-report-dto';
import { DisasterOperationDto } from 'src/app/Models/DTOS/DisasterOperation/disaster-operation-dto';
import { DisasterServicesService } from 'src/app/Services/disaster.service';
import { WithDisasterOperations } from 'src/app/Models/DTOS/DisasterCategory/with-disaster-operations';
import { DisasterOperationAndCity } from 'src/app/Models/DTOS/DisasterOperation/disaster-operation-and-city';
import { WithAssignerAndCategory } from 'src/app/Models/DTOS/DisasterOperation/with-assigner-and-category';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { NgForm } from '@angular/forms';
import { CreateDto } from 'src/app/Models/DTOS/CustomOperation/create-dto';
import { Guid } from 'guid-typescript';
import { OperationService } from 'src/app/Services/operation.service';

@Component({
  selector: 'app-assign',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './assign.component.html',
  styleUrls: ['./assign.component.scss']
})
export class AssignComponent {
  emergencyReportId: string;
  emergencyReport: EmergencyReportDto
  selecetedOperationId: Guid;
  disasterOperations: WithAssignerAndCategory[]
  constructor(private _router:Router,private _activated: ActivatedRoute, private _emergencyService: EmergencyReportService, private _disasterOperations: DisasterServicesService,private _customOperation:OperationService) {
    this._activated.params.subscribe(res => {
      this.emergencyReportId = res["id"];
      this.getById();
      this.getDisasterOperations();
    })
  }
  getById() {
    this._emergencyService.getEmergencyReportById(this.emergencyReportId).subscribe(res => {
      this.emergencyReport = res;
    })
  }
  getDisasterOperations() {
    this._disasterOperations.getDisasterOperationsWithCategories().subscribe(x => {
      
      this.disasterOperations = x;
      console.log(this.disasterOperations);
    })
  }
  selectOperation(id: Guid) {
    this.selecetedOperationId = id;
  }
  add(form: NgForm) {
    let dto: CreateDto = new CreateDto();
    let fv = form.value;
    dto.disasterOperationId = this.selecetedOperationId.toString();
    dto.emergencyReportId = this.emergencyReportId
    this._customOperation.postOperation(dto)
    this._emergencyService.putChangeStatusOnMission(dto.emergencyReportId.toString());
    this._router.navigateByUrl("/Dispatch/EmergencyReport/List/OnMission")

  }

}
