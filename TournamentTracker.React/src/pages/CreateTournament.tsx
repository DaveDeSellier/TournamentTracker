import { useState } from "react";
import { Create, ITournamentModel } from "../services/TournamentService";

export default function CreateTournament() {
    const [tournamentName, setTournamentName] = useState<string>();
    const [entryFee, setEntryFee] = useState<number>();

    const tournament: ITournamentModel = { tournamentName, entryFee };

    function onSubmit() {
        if (!isFormValid()) {
            return;
        }
    }

    function isFormValid(): boolean {
        return true;
    }

    async function postData() {
        const response = await Create("api/Tournament", tournament);
    }

    return (
        <div className="container-fluid">
            <h2>Create Tournament</h2>
            <form>
                <div>
                    <div className="form-group w-25">
                        <label>Tournament Name </label>
                        <input
                            className="form-control"
                            type="text"
                            placeholder="Enter a tournament name..."
                            onChange={(e) => setTournamentName(e.target.value)}
                        />
                    </div>

                    <div className="mt-4 form-group-item w-25">
                        <label>Entry Fee</label>
                        <input
                            className="form-control"
                            type="text"
                            placeholder="Enter a entry fee..."
                            onChange={(e) =>
                                setEntryFee(parseInt(e.target.value))
                            }
                        />
                    </div>
                    <button
                        className="mt-4 btn btn-primary"
                        type="submit"
                        onClick={onSubmit}
                    >
                        Next
                    </button>
                </div>
            </form>
        </div>
    );
}
