import { Guid } from "guid-typescript";
import { BaseEntity } from "./base-entity";
import { CustomOperation } from "./custom-operation";
import { AppUser } from "./app-user";

export class OperationEmployee extends BaseEntity {
    customOperation:CustomOperation
    customOperationId:Guid
    appUser:AppUser
    appUserId:string
}
