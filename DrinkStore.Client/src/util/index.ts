export function makeRequest(url, body, method: 'GET' | 'POST' = 'GET') {
    return fetch(`https://localhost:44330${url}`,{
        method,
        body: JSON.stringify(body),
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json',
        },
    })
    .then(response => response.json());
}