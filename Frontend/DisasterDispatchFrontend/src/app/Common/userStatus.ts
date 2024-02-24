export class UserStatus {
    arr: statusEnum[]=[];
    constructor() {
        this.arr.push(new statusEnum("InActive", "0"))
        this.arr.push(new statusEnum("Active", "1"))
        this.arr.push(new statusEnum("OnMission", "2"))
    }
    searchByVal(val:string){
        return this.arr.find(x=>x.value==val)?.status
    }
}
class statusEnum {
    status: string;
    value: string;
    constructor(status: string, value: string) {
        this.status = status;
        this.value = value;
    }
}