import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import CreateTournament from "./pages/CreateTournament";
import NoMatch from "./pages/NoMatch";

function App() {
    return (
        <>
            <Routes>
                <Route index element={<Home />} />
                <Route
                    path="/createtournament"
                    element={<CreateTournament />}
                />

                {/* Using path="*"" means "match anything", so this route
                acts like a catch-all for URLs that we don't have explicit
                routes for. */}
                <Route path="*" element={<NoMatch />} />
            </Routes>
        </>
    );
}

export default App;
