import authService from '../services/AuthService';

export enum RequestMethod {
    GET = "GET",
    POST = "POST",
    PUT = "PUT",
    DELETE = "DELETE"
}

class Request {
    base_url: string;
    access_token = "";

    constructor(url: string, access_token = "") {
        this.base_url = url;
        this.access_token = access_token;
    }
    
    async make(url: string, body: object, method: RequestMethod = RequestMethod.GET) {
        const response = await fetch(`${this.base_url + url}`, {
            method: method.toString(),
            body: (method === RequestMethod.GET) ? null : JSON.stringify(body),
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.access_token}`
            },
        });
        if (response.status === 401) {
            authService.isLoggedIn().then((isLoggedIn) => {
                if (!isLoggedIn) {
                    return authService.login();
                }
                return response.json();
            });
        }
        else {
            return response.json();
        }
    }
 
    setAccessToken(token: string) {
        this.access_token = token;
    }
}

export const request = new Request('https://localhost:44302');
