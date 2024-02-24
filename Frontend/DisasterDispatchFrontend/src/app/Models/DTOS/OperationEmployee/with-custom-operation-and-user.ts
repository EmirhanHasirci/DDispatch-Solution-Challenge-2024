import { Guid } from "guid-typescript";
import { CustomOperationDto } from "../CustomOperation/custom-operation-dto";
import { AppUserDto } from "../User/app-user-dto";

export class WithCustomOperationAndUser {
    id:Guid;
    customOperation:CustomOperationDto
    worker:AppUserDto
}
