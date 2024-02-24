import { BaseEntity } from "./base-entity";
import { DisasterOperation } from "./disaster-operation";

export class DisasterCategory extends BaseEntity {
    name:string;
    color:string;
    disasterOperations:DisasterOperation[]
}
