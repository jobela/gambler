import axios from "axios";
import { useEffect, useState } from "react";

export const ScoreBoardTableComponent = () => {

    const [scores, setScores] = useState<IScore[]>([]);

    useEffect(()=>{
        fetchScores();
        const interval = setInterval(()=>{
            fetchScores();
        }, 1000);
        return () => clearInterval(interval);
    },[]);

    const fetchScores = () => {        
        let apiUrl = "https://example.com/url/url";
        axios.get<IApiData>(apiUrl).then((result => {
            // result comes here
            setScores(result.data.scores);
        })).catch((error) => {
            alert(error);
        })
    }

    return (
        <table id="scorers">
            <tr>
                <th>Name</th>
                <th>Score</th>
            </tr>
            {scores.map((s) => <tr><td>{s.name}</td><td>{s.score}</td></tr>)}            
        </table>
    );

}

interface IApiData {
    success : boolean;
    scores : IScore[];

}

interface IScore {
    name : string,
    score : number
}

