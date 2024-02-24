export class Cities {
    cities: City[] = [];
    constructor() {
        this.cities.push(new City("01", "Adana"));
        this.cities.push(new City("02", "Adıyaman"));
        this.cities.push(new City("03", "Afyon"));
        this.cities.push(new City("04", "Ağrı"));
        this.cities.push(new City("05", "Amasya"));
        this.cities.push(new City("06", "Ankara"));
        this.cities.push(new City("07", "Antalya"));
        this.cities.push(new City("08", "Artvin"));
        this.cities.push(new City("09", "Aydın"));
        this.cities.push(new City("10", "Balıkesir"));
        this.cities.push(new City("11", "Bilecik"));
        this.cities.push(new City("12", "Bingöl"));
        this.cities.push(new City("13", "Bitlis"));
        this.cities.push(new City("14", "Bolu"));
        this.cities.push(new City("15", "Burdur"));
        this.cities.push(new City("16", "Bursa"));
        this.cities.push(new City("17", "Çanakkale"));
        this.cities.push(new City("18", "Çankırı"));
        this.cities.push(new City("19", "Çorum"));
        this.cities.push(new City("20", "Denizli"));
        this.cities.push(new City("21", "Diyarbakır"));
        this.cities.push(new City("22", "Edirne"));
        this.cities.push(new City("23", "Elazığ"));
        this.cities.push(new City("24", "Erzincan"));
        this.cities.push(new City("25", "Erzurum"));
        this.cities.push(new City("26", "Eskişehir"));
        this.cities.push(new City("27", "Gaziantep"));
        this.cities.push(new City("28", "Giresun"));
        this.cities.push(new City("29", "Gümüşhane"));
        this.cities.push(new City("30", "Hakkari"));
        this.cities.push(new City("31", "Hatay"));
        this.cities.push(new City("32", "Isparta"));
        this.cities.push(new City("33", "Mersin"));
        this.cities.push(new City("34", "İstanbul"));
        this.cities.push(new City("35", "İzmir"));
        this.cities.push(new City("36", "Kars"));
        this.cities.push(new City("37", "Kastamonu"));
        this.cities.push(new City("38", "Kayseri"));
        this.cities.push(new City("39", "Kırklareli"));
        this.cities.push(new City("40", "Kırşehir"));
        this.cities.push(new City("41", "Kocaeli"));
        this.cities.push(new City("42", "Konya"));
        this.cities.push(new City("43", "Kütahya"));
        this.cities.push(new City("44", "Malatya"));
        this.cities.push(new City("45", "Manisa"));
        this.cities.push(new City("46", "Kahramanmaraş"));
        this.cities.push(new City("47", "Mardin"));
        this.cities.push(new City("48", "Muğla"));
        this.cities.push(new City("49", "Muş"));
        this.cities.push(new City("50", "Nevşehir"));
        this.cities.push(new City("51", "Niğde"));
        this.cities.push(new City("52", "Ordu"));
        this.cities.push(new City("53", "Rize"));
        this.cities.push(new City("54", "Sakarya"));
        this.cities.push(new City("55", "Samsun"));
        this.cities.push(new City("56", "Siirt"));
        this.cities.push(new City("57", "Sinop"));
        this.cities.push(new City("58", "Sivas"));
        this.cities.push(new City("59", "Tekirdağ"));
        this.cities.push(new City("60", "Tokat"));
        this.cities.push(new City("61", "Trabzon"));
        this.cities.push(new City("62", "Tunceli"));
        this.cities.push(new City("63", "Şanlıurfa"));
        this.cities.push(new City("64", "Uşak"));
        this.cities.push(new City("65", "Van"));
        this.cities.push(new City("66", "Yozgat"));
        this.cities.push(new City("67", "Zonguldak"));
        this.cities.push(new City("68", "Aksaray"));
        this.cities.push(new City("69", "Bayburt"));
        this.cities.push(new City("70", "Karaman"));
        this.cities.push(new City("71", "Kırıkkale"));
        this.cities.push(new City("72", "Batman"));
        this.cities.push(new City("73", "Şırnak"));
        this.cities.push(new City("74", "Bartın"));
        this.cities.push(new City("75", "Ardahan"));
        this.cities.push(new City("76", "Iğdır"));
        this.cities.push(new City("77", "Yalova"));
        this.cities.push(new City("78", "Karabük"));
        this.cities.push(new City("79", "Kilis"));
        this.cities.push(new City("80", "Osmaniye"));
        this.cities.push(new City("81", "Düzce"));
    }
    searchCityById(id: string): City | undefined {        
        return this.cities.find(city => city.id === id);
    }
}
class City {
    id: string;
    name: string;
    constructor(id: string, name: string) {
        this.id = id;
        this.name = name;
    }
}