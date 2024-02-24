import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperationService } from 'src/app/Services/operation.service';
import { OperationEmployeeDto } from 'src/app/Models/DTOS/OperationEmployee/operation-employee-dto';

@Component({
  selector: 'app-active-operation',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './active-operation.component.html',
  styleUrls: ['./active-operation.component.scss']
})
export class ActiveOperationComponent {
  dto:OperationEmployeeDto
  constructor(private service:OperationService){
    this.getById("ef56947a-4f13-4711-93b2-09817930c5b7");
  }
  getById(id:string){
    this.service.getActiveOperationUser(id).subscribe(data=>{
      this.dto=data;
    })
  }

}
