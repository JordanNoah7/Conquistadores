import { ItemRequest } from "./ItemRequest";

export interface RequestValidateUser {
    Request: ItemRequest;
    APLI_CodApli: string;
    Captcha: string;
    Key: string | boolean;
}
