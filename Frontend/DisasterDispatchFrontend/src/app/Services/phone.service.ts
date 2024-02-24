import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { PhoneDto } from '../Models/DTOS/Phone/phoneDto';
import { Observable, map } from 'rxjs';
import { CustomResponse } from '../contracts/custom-response';
import { PhoneNumberCreateDto } from '../Models/DTOS/Phone/phoneNumberCreateDto';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  constructor(private _http:HttpClientService) { }

  getPhoneById(id:string):Observable<PhoneDto>{
    return this._http.get<CustomResponse<PhoneDto>>({
      controller: "PhoneNumber"        
    },id).pipe(
      map(data => data.data!)
    );
  }
  getPhoneByUserName(name:string):Observable<PhoneDto[]>{
    return this._http.get<CustomResponse<PhoneDto[]>>({
      controller: "PhoneNumber",
      action:"GetPhoneNumbersByUserName"        
    },name).pipe(
      map(data => data.data!)
    );
  }

  postPhone(create:PhoneNumberCreateDto){        
    this._http.post<PhoneNumberCreateDto>({controller:"PhoneNumber"},create).subscribe();        
  }

  putPhone(update:PhoneDto){        
    this._http.put<PhoneDto>({controller:"PhoneNumber"},update).subscribe();        
  }

}
