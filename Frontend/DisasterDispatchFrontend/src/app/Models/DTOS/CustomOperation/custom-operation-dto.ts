import { Guid } from "guid-typescript";
import { AppUser } from "../../app-user";
import { DisasterOperation } from "../../disaster-operation";
import { EmergencyReport } from "../../emergency-report";

export class CustomOperationDto {
    public id: Guid;
    public emergencyReportId: Guid;
    public emergencyReport: EmergencyReport | null;
    public disasterOperationId: Guid;
    public disasterOperation: DisasterOperation | null;
    public workers: AppUser[];
    public status: string;
}
