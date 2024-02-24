import { AppUserDto } from "../User/app-user-dto";

export class PhoneDtoWithUser{
    id:string;
    number:string;
    AppUser:AppUserDto;
}