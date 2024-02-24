import { Guid } from "guid-typescript";
import { DisasterOperation } from "../../disaster-operation";

export class WithDisasterOperations {
    id:Guid;
    name:string;
    color:string;
    disasterOperations:DisasterOperation[]
}
