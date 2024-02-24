import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Create } from '../Models/DTOS/EmergencyReport/create';
import { Observable, map } from 'rxjs';
import { EmergencyReportDto } from '../Models/DTOS/EmergencyReport/emergency-report-dto';
import { CustomResponse } from '../contracts/custom-response';
import { StatusUpdate } from '../Models/DTOS/EmergencyReport/status-update';

@Injectable({
  providedIn: 'root'
})
export class EmergencyReportService {
  constructor(private _http:HttpClientService) { }

  postEmergencyReport(create:Create){        
    this._http.post<Create>({controller:"EmergencyReport"},create).subscribe();        
  }

  getEmergencyReports(status:string):Observable<EmergencyReportDto[]>{
    return this._http.get<CustomResponse<EmergencyReportDto[]>>({
      controller: "EmergencyReport",     
    }).pipe(
      map(data => data.data!)
    );
  }

  getEmergencyReportById(id:string):Observable<EmergencyReportDto>{
    return this._http.get<CustomResponse<EmergencyReportDto>>({
      controller: "EmergencyReport"        
    },id).pipe(
      map(data => data.data!)
    );
  }
  deleteEmergencyReport(id:string){
    this._http.delete({controller:"EmergencyReport"},id).subscribe();
  }
  putChangeStatusOnMission(id:string){
    let eStatusUpdate:StatusUpdate=new StatusUpdate;
    eStatusUpdate.id=id;
    eStatusUpdate.status="OnMission";
    this._http.put({controller:"EmergencyReport",action:"ChangeStatus"},eStatusUpdate).subscribe();        
  }
  putChangeStatusInActive(id:string){
    let eStatusUpdate:StatusUpdate=new StatusUpdate;
    eStatusUpdate.id=id;
    eStatusUpdate.status="InActive"
    this._http.put({controller:"EmergencyReport",action:"ChangeStatus"},eStatusUpdate).subscribe();        
  }
}
