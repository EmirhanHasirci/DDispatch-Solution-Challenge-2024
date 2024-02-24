import { WithAssignerAndCategory } from "../DisasterOperation/with-assigner-and-category";
import { EmergencyReportDto } from "../EmergencyReport/emergency-report-dto";
import { AppUserDto } from "../User/app-user-dto";

export class WithWorkersDto {
    public id: string;
    public emergencyReport: EmergencyReportDto;
    public disasterOperation: WithAssignerAndCategory;
    public workers: AppUserDto[];
    public status: string;
}
