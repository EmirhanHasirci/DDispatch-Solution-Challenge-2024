import { Guid } from "guid-typescript";

export class UpdateDto {
    id:Guid;
    customOperationId:Guid
    appUserId:string;
}
