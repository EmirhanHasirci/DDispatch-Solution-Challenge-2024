import { Guid } from "guid-typescript";

export class AddressDto {
    id:Guid
    province: string;
    district: string;
    neighbourhood: string;
    street: string;
    appUserId: string;
}
