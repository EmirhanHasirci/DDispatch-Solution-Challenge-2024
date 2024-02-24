import { Guid } from "guid-typescript";

export class BaseEntity {
    id:Guid;
    createdDate:string;
    updatedDate:string;
}
