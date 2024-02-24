interface ICustomResponse<T> {
    data?: T;
    statusCode: string;
    errors?: string[];
}

export class CustomResponse<T> {
    constructor(
        public data?: T,
        public statusCode: string = "200",
        public errors?: string[]
    ) { }

    static Success<T>(data: T, statusCode = "200"): ICustomResponse<T> {
        return new CustomResponse(data, statusCode);
    }

    static SuccessWithoutData(statusCode = "200"): ICustomResponse<any> {
        return new CustomResponse(undefined, statusCode);
    }

    static Fail<T>(errors: string[], statusCode = "400"): ICustomResponse<T> {
        return new CustomResponse(undefined, statusCode, errors);
    }

    static FailWithData<T>(data: T, error: string, statusCode = "400"): ICustomResponse<T> {
        return new CustomResponse(data, statusCode, [error]);
    }
}