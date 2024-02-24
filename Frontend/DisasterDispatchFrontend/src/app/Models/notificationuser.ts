import { Guid } from "guid-typescript";
import { Notificationcl } from "./notificationcl";
import { AppUser } from "./app-user";

export class Notificationuser {
    notificationId:Guid
    notification:Notificationcl;
    appUserId:string;
    AppUser:AppUser
}
