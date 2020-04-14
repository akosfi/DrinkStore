import authService from '../services/AuthService';

export enum RequestMethod {
    GET = "GET",
    POST = "POST",
    PUT = "PUT",
    DELETE = "DELETE"
}


export function makeRequest(url, body, method: RequestMethod = RequestMethod.GET) {
    return fetch(`https://localhost:44302${url}`, {
        method: method.toString(),
        body: (method === RequestMethod.GET) ? null : JSON.stringify(body),
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json',
        },
    })
    .then(response => {
        if(response.status === 401) {
            authService.isLoggedIn().then((isLoggedIn) => {
                if(!isLoggedIn) {
                    return authService.login();
                }
                return response.json();
            });
        }
        else {
            return response.json();
        }
    });
}
