import { Guid } from "guid-typescript";
import { EmergencyReport } from "./emergency-report";
import { DisasterOperation } from "./disaster-operation";
import { AppUser } from "./app-user";
import { BaseEntity } from "./base-entity";

export class CustomOperation extends BaseEntity {
    emergencyReportId:Guid;
    emergencyReport:EmergencyReport;
    disasterOperationId:Guid;
    disasterOperation:DisasterOperation;
    workers:AppUser[];
    status:string;
}
