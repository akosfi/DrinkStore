export function makeRequest(url, body, method = 'GET') {
    return fetch(`https://localhost:44302${url}`, {
        method: (method == 'POST') ? 'POST' : 'GET',
        //body: JSON.stringify(body),
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json',
        },
    })
    .then(response => response.json());
}