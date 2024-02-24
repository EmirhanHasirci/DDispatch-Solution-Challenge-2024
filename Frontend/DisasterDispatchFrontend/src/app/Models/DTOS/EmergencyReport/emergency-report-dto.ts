import { Guid } from "guid-typescript";
import { CustomOperation } from "../../custom-operation";

export class EmergencyReportDto {
    id: Guid;
    reporterTc: string;
    reporterPhoneNumber: string;
    info: string;
    province: string;
    district: string;
    neighbourhood: string;
    street: string;
    status: string;
    customOperations: CustomOperation[]
}
