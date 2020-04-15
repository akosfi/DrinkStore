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
            'Authorization': "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IlVUMlVNTV9aUjJfdW1TMHNPa0ZDNEEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1ODY5NjUxNzcsImV4cCI6MTU4Njk2ODc3NywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDEiLCJhdWQiOiJyZXNvdXJjZWFwaSIsImNsaWVudF9pZCI6InZ1ZV9hcHAiLCJzdWIiOiI0YTFlYjdlYi1jYTkxLTRhMmEtYWI2OC03NDkwYzU1MTRhMTgiLCJhdXRoX3RpbWUiOjE1ODY5NjUxNzcsImlkcCI6ImxvY2FsIiwiZ2l2ZW5fbmFtZSI6InRvbWkiLCJlbWFpbCI6InRvbWlAdG9taS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDb25zdW1lciIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsIm9yZGVyOnJlYWQiLCJvcmRlcjpjcmVhdGUiXSwiYW1yIjpbInB3ZCJdfQ.XwDaT988FJUaJK_TVvWgBMOpcW0enIPZ31OXF6XFKXjZ48TMH5q66BWFKm_7ZsVsOj4GpUT1UXoU2n8o_f-cVptqA_0ddwMWOsc9BQ8HMR7a9Thrq7DPSw7QjmipjKGb3bK7UrleRAL3iVCTEPwNhzepZ3DQF_3odYScpEmz_dRdOFz0izEs5a42LBArBg9BIdGlC8esg0OiUbTpprj0VjiWTg1v8lhb6h75lGwvgN-CnlDaA8fqVfTF47pdz61eJPwYfFahKP0GmUw8TMDFEC8yLWfS_EGUqXxIinGu3S4RoPwuOHV2EeVRrNPZkIM2PGfoLW8gs1vvuf1AHKH_7A"
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
