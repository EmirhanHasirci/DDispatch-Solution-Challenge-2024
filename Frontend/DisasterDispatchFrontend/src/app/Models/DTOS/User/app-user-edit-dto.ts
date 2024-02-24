export class AppUserEditDto{
    name: string;
    surname: string;
    userName?: string | null
    email?: string | null
    picture?: string | null
    gender?: string | null
    birthDate?: Date | null
    city?: string | null
}