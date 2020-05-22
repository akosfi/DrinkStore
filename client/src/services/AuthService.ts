import { UserManager, WebStorageStateStore, User, UserManagerSettings } from "oidc-client";
import {request} from '../util/';

class AuthService {
    userManager: UserManager;

    constructor() {
        const AUTH0_DOMAIN = process.env.NODE_ENV === 'production' ? process.env.VUE_APP_AUTH_PROD : process.env.VUE_APP_AUTH_DEV;
        const clientAddress = process.env.NODE_ENV === 'production' ? 'https://drinkstoreclient.azurewebsites.net' : 'http://localhost:8080';

        const settings: UserManagerSettings = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: AUTH0_DOMAIN,
            client_id: "vue_app",
            redirect_uri: `${clientAddress}/auth-callback.html`,
            response_type: "id_token token",
            scope: "openid profile email resourceapi:use",
            post_logout_redirect_uri: `${clientAddress}/`,
            filterProtocolClaims: true,
            metadata: {
                issuer: AUTH0_DOMAIN + "/",
                authorization_endpoint: AUTH0_DOMAIN + "/connect/authorize",
                userinfo_endpoint: AUTH0_DOMAIN + "/connect/userinfo",
                end_session_endpoint: AUTH0_DOMAIN + "/connect/endsession",
                jwks_uri: AUTH0_DOMAIN + "/.well-known/openid-configuration",
            }
        };

        this.userManager = new UserManager(settings);
        this.userManager.events.addUserLoaded(user => {
            request.setAccessToken(user.access_token);
        });
    }

    public getUser(): Promise<User | null> {
        return this.userManager.getUser();
    }

    public login(): Promise<void> {
        return this.userManager.signinRedirect();
    }

    public logout(): Promise<void> {
        return this.userManager.signoutRedirect();
    }

    public async isLoggedIn(): Promise<boolean> {
        const user: User | null = await this.getUser();

        console.log(user);
        return (user !== null && !user.expired);
    }
}

const authService = new AuthService();

export default authService;
