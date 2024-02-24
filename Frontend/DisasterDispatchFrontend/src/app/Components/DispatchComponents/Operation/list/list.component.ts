import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { OperationService } from 'src/app/Services/operation.service';
import { CustomOperationDto } from 'src/app/Models/DTOS/CustomOperation/custom-operation-dto';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {
  status: string;
  dto: CustomOperationDto[]
  constructor(private _activated: ActivatedRoute, private service: OperationService) {
    this._activated.params.subscribe(res => {
      this.status = res["status"];
      this.getOperations();
    })
  }
  getOperations() {
    this.service.getActiveOperations(this.status).subscribe(data => {
      console.log(data);
      
      this.dto = data;
    })
  }
  inActiveOperation(id:Guid){
    this.service.postChangeStatusInActive(id.toString());
    console.log(id);
    
  }
}
