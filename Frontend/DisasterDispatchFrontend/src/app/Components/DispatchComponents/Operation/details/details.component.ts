import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { OperationService } from 'src/app/Services/operation.service';
import { CustomOperationDto } from 'src/app/Models/DTOS/CustomOperation/custom-operation-dto';
import { SharedModule } from 'src/app/Common/Shared/shared.module';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent {  
  customOperationId:string;
  customOperationDto:CustomOperationDto;
  constructor(private _activated: ActivatedRoute,private service:OperationService) {
    this._activated.params.subscribe(res=>{
       this.customOperationId= res["id"];
       this.getById();              
    })
  }
  getById() {
    this.service.getActiveOperationById(this.customOperationId).subscribe(res => {
      this.customOperationDto = res;
    })
  }
}
