import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Observable, map } from 'rxjs';
import { AddressDto } from '../Models/DTOS/Address/address-dto';
import { CustomResponse } from '../contracts/custom-response';
import { CreateDto } from '../Models/DTOS/Address/create-dto';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private _http:HttpClientService) { }
  getAddressById(id:string):Observable<AddressDto>{
    return this._http.get<CustomResponse<AddressDto>>({
      controller: "Address"        
    },id).pipe(
      map(data => data.data!)
    );
  }
  getAddressByUserName(name:string):Observable<AddressDto>{
    return this._http.get<CustomResponse<AddressDto>>({
      controller: "Address",
      action:"GetAddressesByUsername"        
    },name).pipe(
      map(data => data.data!)
    );
  }

  postAddress(create:CreateDto){        
    this._http.post<CreateDto>({controller:"Address"},create).subscribe();        
  }

  putAddress(update:AddressDto){        
    this._http.put<AddressDto>({controller:"Address"},update).subscribe();        
  }
}
