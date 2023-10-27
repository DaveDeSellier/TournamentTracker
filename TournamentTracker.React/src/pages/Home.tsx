import GetTournaments, {
    ITournamentModel,
    ITournaments,
} from "../services/TournamentService";
import React, { useEffect, useState } from "react";

function TournamentList({ tournaments }: ITournaments) {
    if (tournaments === null) {
        return <></>;
    }

    const listItems = tournaments?.map((tournament) => (
        <option>{tournament.tournamentName}</option>
    ));
    return listItems;
}

export default function Home() {
    const [data, setData] = useState<ITournamentModel[]>(
        new Array<ITournamentModel>()
    );

    const fetchData = async () => {
        const result = await GetTournaments("api/Home");
        setData(result);
    };

    useEffect(() => {
        fetchData();
    }, []);

    const handleLoadTournament = (e: React.MouseEvent<HTMLButtonElement>) => {};

    const handleCreateTournament = (
        e: React.MouseEvent<HTMLButtonElement>
    ) => {};

    return (
        <>
            {/* @if(isVisible){
                <Alert IsVisible=@isVisible ErrorMessage=@ErrorMessage />
            } */}
            <div className="d-flex p-5 m-lg-5 align-items-center flex-column">
                <h1>Tournament Dashboard</h1>
                <div className="">
                    <label>Load Existing Tournament</label>
                    <select className="form-select">
                        <option defaultValue="-- select an option --">
                            -- select an option --
                        </option>
                        <TournamentList tournaments={data} />
                    </select>
                </div>
                <div className="d-flex flex-column gap-2 mt-4">
                    <button
                        onClick={(e) => handleLoadTournament(e)}
                        className="btn btn-secondary"
                        type="button"
                    >
                        Load Tournament
                    </button>
                    <button
                        onClick={(e) => handleCreateTournament(e)}
                        className="btn btn-lg btn-primary"
                        type="button"
                    >
                        Create Tournament
                    </button>
                </div>
            </div>
        </>
    );
}
