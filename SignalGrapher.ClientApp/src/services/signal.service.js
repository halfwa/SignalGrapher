//const API_URL = "http://localhost:80/api";

export const getSignalById= async (id) => {
    const response = await fetch(`api/signals/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/octet-stream'
            }
    });
    if (response.ok) {
        return await response;
    } else {
        throw new Error(`Failed to fetch SinusoidalSignal. Status: ${response.status}`);
    }
}

export const createSignal = async (signalRequest) => {
    const response = await fetch('api/signals', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(signalRequest)  
    });
    if (response.status === 201) {
        return await response.json();
    } else {
        throw new Error(`Failed to create SinusoidalSignal. Status: ${response.status}`);
    }
}
