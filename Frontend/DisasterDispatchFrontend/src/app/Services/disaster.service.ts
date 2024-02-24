import { Injectable } from '@angular/core';
import { DisasterCategoryDto } from '../Models/DTOS/DisasterCategory/disaster-category-dto';
import { HttpClientService } from './http-client.service';
import { CustomResponse } from '../contracts/custom-response';
import { Observable, map } from 'rxjs';
import { WithDisasterOperations } from '../Models/DTOS/DisasterCategory/with-disaster-operations';
import { WithAssignerAndCategory } from '../Models/DTOS/DisasterOperation/with-assigner-and-category';
import { CreateDto } from '../Models/DTOS/DisasterOperation/create-dto';


@Injectable({
  providedIn: 'root'
})
export class DisasterServicesService {

  constructor(private _http: HttpClientService) { }
  getDisasterCategoryDtos(): Observable<DisasterCategoryDto[]> {
    return this._http.get<CustomResponse<DisasterCategoryDto[]>>({
      controller: "DisasterCategory"
    }).pipe(
      map(data => data.data!) // Extract the data from the response
    );
  }
  getDisasterOperationsWithCategories(): Observable<WithAssignerAndCategory[]> {
    return this._http.get<CustomResponse<WithAssignerAndCategory[]>>({
      controller: "DisasterOperation",
      action:"GetDisasterOperationWithAssignerAndCategory"
    }).pipe(
      map(data => data.data!)
    );
  }
  postDisasterOperationAddRange(creates:CreateDto[]){
    this._http.post<CreateDto[]>({controller:"DisasterOperation",action:"DisasterOperationAddRange"},creates).subscribe();
  }
}
