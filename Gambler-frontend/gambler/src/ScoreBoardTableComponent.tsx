import axios from "axios";
import { useEffect, useState } from "react";
import internal from "stream";

export const ScoreBoardTableComponent = () => {

    const [scores, setScores] = useState<IScore[]>([]);

    useEffect(()=>{
        fetchScores();
        const interval = setInterval(()=>{
            fetchScores();
        }, 15000);
        return () => clearInterval(interval);
    },[]);

    const fetchScores = () => {        
        let apiUrl = "https://gambler-api.codefellas.no/api/Gamblers/GetTop10";
        axios.get<IScore[]>(apiUrl).then((result => {
            // result comes here
            //console.log(result.data);
            setScores(result.data);
        })).catch((error) => {
            console.log(error);
        })
    }

    return (
        <table id="scorers">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Score</th>
                    <th>Highscore</th>
                    <th>Bets today</th>
                </tr>
            </thead>
                <tbody>
                    {scores?.map((s) => <tr><td>{s.nickname}</td><td>{s.points}</td><td>{s.highscore}</td><td>{s.numberOfBets}</td></tr>)}            
                </tbody>
        </table>
    );

}

interface IApiData {
    success : boolean;
    scores : IScore[];

}

interface IScore {
    nickname : string,
    points : number,
    message : string,
    latestBet : Date,
    highscore : number,
    numberOfBets : number
}

