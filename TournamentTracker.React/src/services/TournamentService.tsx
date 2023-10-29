const api: string = import.meta.env.VITE_API;

export interface ITournamentModel {
    tournamentName: string;
    id: number;
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

export default async function GetTournaments(
    uri: string
): Promise<ITournamentModel[]> {
    const tournamentData = await FetchData(uri);
    return tournamentData;
}
