import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { CustomResponse } from '../contracts/custom-response';
import { AppUserDto } from '../Models/DTOS/User/app-user-dto';
import { Observable, map } from 'rxjs';
import { AppUserEditDto } from '../Models/DTOS/User/app-user-edit-dto';
import { StatusChangeDto } from '../Models/DTOS/User/status-change-dto';
import { UserLoginDto } from '../Models/DTOS/User/user-login-dto';
import { UserSignUpDto } from '../Models/DTOS/User/user-sign-up-dto';

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {

  constructor(private _http: HttpClientService) { }

  getUserByTc(tc: string): Observable<AppUserDto> {
    return this._http.get<CustomResponse<AppUserDto>>({
      controller: "User",
      action: "GetUserByTc"
    }, tc!).pipe(
      map(data => data.data!)
    );
  }
  getUserByName(name: string): Observable<AppUserDto> {
    return this._http.get<CustomResponse<AppUserDto>>({
      controller: "User",
      action: "GetUserByName"
    }, name!).pipe(
      map(data => data.data!)
    );
  }

  getUsersByActiveAndCity(city: string): Observable<AppUserDto[]> {
    return this._http.get<CustomResponse<AppUserDto[]>>({
      controller: "User",
      action: "GetUsersByCity"
    }, city!).pipe(
      map(data => data.data!)
    );
  }

  getUserByNameForEdit(name: string): Observable<AppUserEditDto> {
    return this._http.get<CustomResponse<AppUserEditDto>>({
      controller: "User",
      action: "GetUserByNameForEdit"
    }, name!).pipe(
      map(data => data.data!)
    );
  }
  getUserRoles(name: string): Observable<string[]> {
    return this._http.get<CustomResponse<string[]>>({
      controller: "User",
      action: "GetRolesByUser"
    }, name!).pipe(
      map(data => data.data!)
    );
  }
  putUserEdit(dto:AppUserEditDto){
    this._http.put<AppUserEditDto>({controller:"user"},dto).subscribe(x=>{
      console.log(x);
      
    });
  }
  postChangeStatus(dto: StatusChangeDto) {
    this._http.post<StatusChangeDto>({ controller: "User", action: "ChangeStatus" }, dto).subscribe();
  }
  login(dto: UserLoginDto): Observable<CustomResponse<AppUserDto>> {
    return this._http.post<any>({ controller: "User", action: "Login" }, dto);
  }
  logout(){
    localStorage.removeItem("currentUsername")
    localStorage.removeItem("currentId")
  }
  register(dto: UserSignUpDto):Observable<CustomResponse<AppUserDto>> {
    return this._http.post<any>({ controller: "User"}, dto);
  }


}
