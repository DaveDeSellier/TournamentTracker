import { useState } from "react";
import { CreatePrize } from "../services/TournamentService";

export default function PrizeForm() {
    const [placeNumber, setPlaceNumber] = useState<number>();
    const [placeName, setPlaceName] = useState<string>();
    const [prizeAmount, setPrizeAmount] = useState<number>();
    const [prizePercentage, setPrizePercentage] = useState<number>();

    function isValid(): boolean {
        const prize: IPrizeModel = {
            placeNumber,
            placeName,
            prizeAmount,
            prizePercentage,
        };

        const response = CreatePrize("api/Tournament", prize);

        return true;
    }

    <div>
        <form onSubmit={isValid}>
            <div className="form-group">
                <label>PlaceNumber: </label>
                <input
                    id="placeNumber"
                    className="form-control"
                    placeholder="Enter a place number..."
                    onChange={(e) => setPlaceNumber(parseInt(e.target.value))}
                />
                <label>PlaceName: </label>
                <input
                    id="placeName"
                    className="form-control"
                    placeholder="Enter a place name..."
                    onChange={(e) => setPlaceName(e.target.value)}
                />
                <label>Prize Amount: </label>
                <input
                    id="prizeAmount"
                    className="form-control"
                    placeholder="Enter a prize amount..."
                    onChange={(e) => setPrizeAmount(parseFloat(e.target.value))}
                />
                <p className="m-1">Or...</p>
                <label>Prize Percentage: </label>
                <input
                    id="prizePercentage"
                    className="form-control"
                    placeholder="Enter a prize percentage..."
                    onChange={(e) =>
                        setPrizePercentage(parseInt(e.target.value))
                    }
                />
            </div>
            <div className="mt-1">
                <button className="btn btn-primary" type="submit">
                    Submit
                </button>
            </div>
        </form>
    </div>;
}
