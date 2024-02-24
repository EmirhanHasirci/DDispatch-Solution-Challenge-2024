import { AppUserDto } from "../User/app-user-dto";
import { AddressDto } from "./address-dto";

export class WithUserDto extends AddressDto {
    AppUser:AppUserDto
}
