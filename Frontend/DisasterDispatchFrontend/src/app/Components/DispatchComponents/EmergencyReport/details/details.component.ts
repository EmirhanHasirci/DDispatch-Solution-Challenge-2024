import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { EmergencyReportDto } from 'src/app/Models/DTOS/EmergencyReport/emergency-report-dto';
import { EmergencyReportService } from 'src/app/Services/emergency-report.service';
import { Cities } from 'src/app/Common/cities';
import { SharedModule } from 'src/app/Common/Shared/shared.module';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent {
  dto:EmergencyReportDto=new EmergencyReportDto();
  id:string;
  constructor(private _activated: ActivatedRoute,private service:EmergencyReportService) {
    this._activated.params.subscribe(res=>{
       this.id= res["id"];
       this.getById();              
    })
  }
  cities: Cities=new Cities();
  getCityName(id: string): string|any {            
    return this.cities.searchCityById(id)?.name;
  }
  getById(){
    this.service.getEmergencyReportById(this.id).subscribe(x=>{
      this.dto=x;
    });
  }
}
