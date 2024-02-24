import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { CreateDto } from '../Models/DTOS/CustomOperation/create-dto';
import { CreateDto as employeeCreateDto}  from  '../Models/DTOS/OperationEmployee/create-dto';
import { Observable, map } from 'rxjs';
import { CustomOperationDto } from '../Models/DTOS/CustomOperation/custom-operation-dto';
import { CustomResponse } from '../contracts/custom-response';
import { OperationEmployeeDto } from '../Models/DTOS/OperationEmployee/operation-employee-dto';
import { StatusChangeDto } from '../Models/DTOS/User/status-change-dto';
import { StatusUpdate } from '../Models/DTOS/CustomOperation/status-update';

@Injectable({
  providedIn: 'root'
})
export class OperationService {
  constructor(private _http:HttpClientService) { }

  postOperation(create:CreateDto){        
   this._http.post<CreateDto>({controller:"CustomOperation"},create).subscribe();        
  }

  getActiveOperations(status:string):Observable<CustomOperationDto[]>{
    return this._http.get<CustomResponse<CustomOperationDto[]>>({
      controller: "CustomOperation",
      action:"GetActiveCustomOperations"      
    },status).pipe(
      map(data => data.data!)
    );
  }
  getActiveOperationById(id:string):Observable<CustomOperationDto>{
    return this._http.get<CustomResponse<CustomOperationDto>>({
      controller: "CustomOperation",
      action:"GetOperationById"      
    },id).pipe(
      map(data => data.data!)
    );
  }

  getActiveOperationUser(id:string):Observable<OperationEmployeeDto>{
    return this._http.get<CustomResponse<OperationEmployeeDto>>({
      controller: "CustomOperation",
      action:"ActiveOperation"      
    },id).pipe(
      map(data => data.data!)
    );
  }

  postEmployeeAddRangeAsync(create:employeeCreateDto[]){        
    this._http.post<employeeCreateDto[]>({controller:"OperationEmployee",action:"AddRange"},create).subscribe();        
  }
  postChangeStatusOnMission(id:string){
    let customOperationStatusUpdate:StatusUpdate=new StatusUpdate();
    customOperationStatusUpdate.id=id;
    customOperationStatusUpdate.status="OnMission";
    this._http.put({controller:"CustomOperation",action:"ChangeStatus"},customOperationStatusUpdate).subscribe();        
  }
  postChangeStatusInActive(id:string){
    let customOperationStatusUpdate:StatusUpdate=new StatusUpdate();
    customOperationStatusUpdate.id=id;
    customOperationStatusUpdate.status="InActive";
    this._http.put({controller:"CustomOperation",action:"ChangeStatus"},customOperationStatusUpdate).subscribe();        
  }

  getOperations():Observable<CustomOperationDto[]>{
    return this._http.get<CustomResponse<CustomOperationDto[]>>({
      controller: "CustomOperation"     
    }).pipe(
      map(data => data.data!)
    );
  }

  getOnMissionUsers(id:string):Observable<OperationEmployeeDto[]>{
    return this._http.get<CustomResponse<OperationEmployeeDto[]>>({
      controller: "OperationEmployee",
      action:"OnMissionUsers"      
    },id).pipe(
      map(data => data.data!)
    );
  }

  getOperationsByUser(id:string):Observable<OperationEmployeeDto[]>{
    return this._http.get<CustomResponse<OperationEmployeeDto[]>>({
      controller: "OperationEmployee",
      action:"GetOperationsByUser"      
    },id).pipe(
      map(data => data.data!)
    );
  }

}
