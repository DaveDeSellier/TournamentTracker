const api: string = import.meta.env.VITE_API;

export interface ITournamentModel {
    entryFee?: number;
    tournamentName?: string;
    id?: number;
}

export interface ITournaments {
    tournaments?: ITournamentModel[];
}

async function FetchData(uri: string): Promise<ITournamentModel[]> {
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

async function PostData(uri: string, data: ITournamentModel) {
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

export async function GetAll(uri: string): Promise<ITournamentModel[]> {
    const tournamentData = await FetchData(uri);
    return tournamentData;
}

export async function Create(uri: string, data: ITournamentModel) {
    const response = await PostData(uri, data);
    return response;
}
