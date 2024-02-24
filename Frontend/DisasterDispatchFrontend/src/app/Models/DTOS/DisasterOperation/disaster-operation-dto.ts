
import { CustomOperation } from "../../custom-operation";

export class DisasterOperationDto {
    public id: string;
    public disasterCategoryId: string;
    public provinceId: string;
    public assignerId: string;
    public operations: CustomOperation[];

}
