export interface ITournamentModel {
    tournamentName: string;
}

export interface ITournaments {
    tournaments?: ITournamentModel[];
}

export default async function GetTournaments(
    uri: string
): Promise<ITournamentModel[]> {
    const api: string = "https://localhost:7238";
    const url: string = `${api}/${uri}`;

    try {
        const response = await fetch(`${url}`, { mode: "cors" });
        if (!response.ok) {
            throw new Error("Network had trouble retrieving results");
        }
        const result = await response.json();
        return result;
    } catch (e) {
        console.log(e);
        throw new Error("Error");
    }
}
