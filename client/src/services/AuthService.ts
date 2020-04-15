import { UserManager, WebStorageStateStore, User, UserManagerSettings } from "oidc-client";

class AuthService {
    userManager: UserManager;

    constructor() {
        const AUTH0_DOMAIN = "https://localhost:44301";

        const settings: UserManagerSettings = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: AUTH0_DOMAIN,
            client_id: "vue_app",
            redirect_uri: "http://localhost:8080/auth-callback.html",
            response_type: "id_token token",
            scope: "openid profile email order:read order:create",
            post_logout_redirect_uri: "http://localhost:8080/",
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

        return (user !== null && !user.expired);
    }
}

export default new AuthService();