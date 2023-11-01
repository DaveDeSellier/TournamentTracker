const api: string = import.meta.env.VITE_API;

interface IPrizeModel {
    id?: number;
    placeNumber?: number;
    placeName?: string;
    prizeAmount?: number;
    prizePercentage?: number;
}

interface IPrizes {
    prizes: IPrizeModel[];
}

async function FetchData(uri: string): Promise<IPrizes[]> {
    const url: string = `${api}/${uri}`;

    try {
        const response = await fetch(`${url}`);
        if (!response.ok) {
            throw new Error("Network had trouble retrieving results");
        }
        const result = await response.json();
        return result;
    } catch (e) {
        throw new Error("Error");
    }
}

async function PostData(uri: string, data: IPrizeModel) {
    const url: string = `${api}/${uri}`;

    try {
        const response = await fetch(url, {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            mode: "cors", // no-cors, *cors, same-origin
            cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
            credentials: "same-origin", // include, *same-origin, omit
            headers: {
                "Content-Type": "application/json",
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            redirect: "follow", // manual, *follow, error
            referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(data), // body data type must match "Content-Type" header
        });
        if (!response.ok) {
            throw new Error("Network had trouble retrieving results");
        }
        const result = await response.json();
        return result;
    } catch (e) {
        throw new Error("Error");
    }
}
