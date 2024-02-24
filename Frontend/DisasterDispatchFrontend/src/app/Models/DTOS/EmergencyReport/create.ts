import { Guid } from "guid-typescript";

export class Create {
    id: Guid;
    reporterTc: string;
    reporterPhoneNumber: string;
    info: string;
    province: string;
    district: string;
    neighbourhood: string;
    street: string;
    status: string;
}
