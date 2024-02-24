export class Gender {
    arr: genderEnum[]=[];
    constructor() {
        this.arr.push(new genderEnum("Unknown", "0"))
        this.arr.push(new genderEnum("Male", "1"))
        this.arr.push(new genderEnum("Female", "2"))
    }
    searchByVal(val:string){
        return this.arr.find(x=>x.value==val)?.status
    }
}
class genderEnum {
    status: string;
    value: string;
    constructor(status: string, value: string) {
        this.status = status;
        this.value = value;
    }
}