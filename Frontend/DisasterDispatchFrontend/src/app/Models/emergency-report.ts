import { CustomOperation } from "./custom-operation";

export class EmergencyReport extends Location {
    reporterTc:string;
    reporterPhoneNumber:string;
    info:string;
    status:string;
    public province:string;
    public district:string;
    public neighbourhood:string;
    public street:string;
    CustomOperations:CustomOperation[];
}
