export const environment = {
    production: false,
    appsettings: {
        "params": {
            "key": "C1U8C0NQU15T4D0R",
            "iv": "C1U8C0L454GU1L45"
        },
        "http": {
            "/auth": {
                "target": "https://localhost:7093/RESTServiceAuth/",
                "secure": false
            },
            "/api": {
                "target": "https://localhost:7093/RESTService/",
                "secure": false
            },
            "/base": {
                "target": "http://localhost:4200/#/auth/login/",
                "secure": false
            }
        },
        "captcha": {
            "public": "6Leh0xseAAAAAF6ihQa5AUhQfu8UXC2h4TktV_8E"
        }
    }
};