import { Request } from './Request';

export interface RequestRest {
    TypeKey: string;
    APLI_CodApli: string;
    Captcha: string;
    Key: string;
    IpClient: string;
    USER_CodUsr: string;
    USER_PassUser: string;
    AUDI_HostCrea: string;
    itemRequest: Request;
}
