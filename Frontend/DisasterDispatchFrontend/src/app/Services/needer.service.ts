import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { NeederDto } from '../Models/DTOS/Needer/needer-dto';

@Injectable({
  providedIn: 'root'
})
export class NeederService {

  constructor(private _http:HttpClientService) { }

  postNeeder(create:NeederDto){                
    this._http.post<NeederDto>({controller:"Needer"},create).subscribe();        
  }

}
