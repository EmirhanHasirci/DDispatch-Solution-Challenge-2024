import { Guid } from "guid-typescript";
import { AppUserDto } from "../User/app-user-dto";
import { DisasterCategoryDto } from "../DisasterCategory/disaster-category-dto";

export class WithAssignerAndCategory {
    id:Guid;
    provinceId:string;
    assigner:AppUserDto;
    disasterCategory:DisasterCategoryDto
}
