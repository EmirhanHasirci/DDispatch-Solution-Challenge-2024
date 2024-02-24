import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperationService } from 'src/app/Services/operation.service';
import { CustomOperationDto } from 'src/app/Models/DTOS/CustomOperation/custom-operation-dto';
import { OperationEmployeeDto } from 'src/app/Models/DTOS/OperationEmployee/operation-employee-dto';
import { SharedModule } from 'src/app/Common/Shared/shared.module';

@Component({
  selector: 'app-my-operations',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './my-operations.component.html',
  styleUrls: ['./my-operations.component.scss']
})
export class MyOperationsComponent {
  constructor(private _operation:OperationService){

  }
  myOperations:OperationEmployeeDto
  getOperations(){
this._operation.getActiveOperationUser("ef56947a-4f13-4711-93b2-09817930c5b7").subscribe(x=>{
  this.myOperations=x;
})
  }

}
