import { Guid } from "guid-typescript";
import { DisasterCategory } from "./disaster-category";
import { AppUser } from "./app-user";
import { CustomOperation } from "./custom-operation";
import { BaseEntity } from "./base-entity";

export class DisasterOperation extends BaseEntity {
    disasterCategory:DisasterCategory
    disasterCategoryId:Guid;
    provinceId:string;
    Assigner:AppUser;
    assignerId:string;
    Operations:CustomOperation[];
}
