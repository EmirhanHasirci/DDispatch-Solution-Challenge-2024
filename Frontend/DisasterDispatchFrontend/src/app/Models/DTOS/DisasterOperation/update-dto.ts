import { Guid } from "guid-typescript";

export class UpdateDto {
    id:Guid;
    disasterCategoryId:Guid;
    provinceId:string;
    assignerId:string;
}
