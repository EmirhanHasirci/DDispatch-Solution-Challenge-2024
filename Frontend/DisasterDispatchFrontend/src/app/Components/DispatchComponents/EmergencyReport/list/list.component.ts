import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { EmergencyReportDto } from 'src/app/Models/DTOS/EmergencyReport/emergency-report-dto';
import { EmergencyReportService } from 'src/app/Services/emergency-report.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {
  result: EmergencyReportDto[]=[];
  status:string="";
  constructor(private _service:EmergencyReportService,private _activated:ActivatedRoute){
    this._activated.params.subscribe(res=>{
      this.status= res["status"];
      this.getAll();                                    
   })
  }
  
  getAll() {
    this._service.getEmergencyReports(this.status).subscribe(x => {      
      this.result = x.filter(report=>report.status===this.status);                             
    })
  }
  changeStatusInActive(id:string){
    this._service.putChangeStatusInActive(id);
  }
  
  changeStatusOnMission(id:string){
    this._service.putChangeStatusOnMission(id);
  }
}
