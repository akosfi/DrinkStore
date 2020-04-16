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
            'Authorization': "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IlVUMlVNTV9aUjJfdW1TMHNPa0ZDNEEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1ODcwMjczMzAsImV4cCI6MTU4NzAzMDkzMCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDEiLCJhdWQiOiJyZXNvdXJjZWFwaSIsImNsaWVudF9pZCI6InZ1ZV9hcHAiLCJzdWIiOiI0YTFlYjdlYi1jYTkxLTRhMmEtYWI2OC03NDkwYzU1MTRhMTgiLCJhdXRoX3RpbWUiOjE1ODcwMjczMzAsImlkcCI6ImxvY2FsIiwiZ2l2ZW5fbmFtZSI6InRvbWkiLCJlbWFpbCI6InRvbWlAdG9taS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDb25zdW1lciIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsIm9yZGVyOnJlYWQiLCJvcmRlcjpjcmVhdGUiXSwiYW1yIjpbInB3ZCJdfQ.c60KLQyJ2maJrGqhzQzCQmhWFlV6PYTQkPsjYYVZ5CGoqT_C4JgDusC-mvTEpWpRMsmTnF7kEwvFKDp_RMPBmvBQf4lpyVdUHueAergFX-0u-dkHkMu1eVD0SjlDhyfttrjWZHobp1SPMfoedPkXYF2i68fSO26EONl5HtvpDjtiJptm72gpuq_aDO2ZigkWlA-SJlcjcYbd1AOsb_L895i3ypMHCtnerEqJi0_pB87gTGG81nrf5b1Cjnzy9q3jnGssmLUt_IO37-FC0h1mnEOLMMwf0OU5W71b5fygQHlErglzozIZ-fiQelypqJrlOX5Qgp0CoGlWF6PqidHYHA"
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
