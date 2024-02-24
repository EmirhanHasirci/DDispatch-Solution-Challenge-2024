import { Guid } from "guid-typescript";
import { CustomOperation } from "../../custom-operation";
import { AppUser } from "../../app-user";

export class OperationEmployeeDto {
    public id: Guid;
    public customOperationId: Guid;
    public customOperation: CustomOperation | null;
    public appUserId: string;
    public appUser: AppUser | null;
}
