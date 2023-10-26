import { MouseEventHandler } from "react"

export default function Home() {

  const handleLoadTournament = (e : React.MouseEvent<HTMLButtonElement>) => {

  }

  const handleCreateTournament = (e : React.MouseEvent<HTMLButtonElement>) => {

  }


  return (
    <>
            {/* @if(isVisible){
                <Alert IsVisible=@isVisible ErrorMessage=@ErrorMessage />
            } */}
          <div className="d-flex vh-100">
            <div className="d-flex w-100 m-auto align-items-center flex-column">
                <h1>Tournament Dashboard</h1>
                <div className="">
                        <label>Load Existing Tournament</label>
                        <select className="form-select">
                          
                        </select>
                </div>
                <div className="d-flex flex-column gap-2 mt-4">
                    <button onClick={(e) => handleLoadTournament(e)} className="btn btn-secondary" type="button">Load Tournament</button>
                    <button onClick={(e) => handleCreateTournament(e)} className="btn btn-lg btn-primary" type="button">Create Tournament</button>
                </div>
            </div>
          </div> 
    </>
  )
}
