import { AppUser } from "./app-user";
import { BaseEntity } from "./base-entity";

export class PhoneNumber extends BaseEntity {
    number:string;
    appUserId:string;
    appUser:AppUser
}
