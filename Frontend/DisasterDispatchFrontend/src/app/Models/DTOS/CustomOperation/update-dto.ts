import { Guid } from "guid-typescript";

export class UpdateDto {
    id:Guid;
    emergencyReportid:Guid
    disasterOperationid:Guid
    status:string
}
