import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { NgForm } from '@angular/forms';
import { Create } from 'src/app/Models/DTOS/EmergencyReport/create';
import { EmergencyReportService } from 'src/app/Services/emergency-report.service';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {
  constructor(private service:EmergencyReportService){}

  add(form: NgForm) {
    if (form.valid) {
      let formV=form.value;
      const newReport: Create=new Create();     
      newReport.district=formV["district"]
      newReport.info=formV["info"]
      newReport.neighbourhood=formV["neighbourhood"]
      newReport.province=formV["province"]
      newReport.reporterPhoneNumber=formV["reporterPhoneNumber"]
      newReport.reporterTc=formV["reporterTc"]
      newReport.street=formV["street"]
      newReport.id=null!;
      this.service.postEmergencyReport(newReport);      
    }
  }
}
