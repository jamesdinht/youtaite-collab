interface AuthConfig {
    CLIENT_ID: string;
    CLIENT_DOMAIN: string;
    RESPONSETYPE: string;
    AUDIENCE: string;
    REDIRECT: string;
    RETURNTO: string;
    SCOPE: string;
}

export class Config {

    AUTH_CONFIG: AuthConfig;

    constructor() {
        this.AUTH_CONFIG = {
            CLIENT_ID: 'c6DwkGblBC8vr9lnLFPpJ5a79MeEkeuc',
            CLIENT_DOMAIN: 'jamesdinht.auth0.com',
            RESPONSETYPE: 'token id_token',
            AUDIENCE: 'http://localhost:9000/auth',
            REDIRECT: 'http://localhost:9100/callback',
            RETURNTO: 'http://localhost:9100/',
            SCOPE: 'openid profile read:projects'
        };
    }
}
