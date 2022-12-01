import axios from "axios";
import { useEffect, useState } from "react";

export const ScoreBoardTableComponent = () => {

    const [scores, setScores] = useState<IScore[]>([]);

    useEffect(()=>{
        fetchScores();
        const interval = setInterval(()=>{
            fetchScores();
        }, 10000);
        return () => clearInterval(interval);
    },[]);

    const fetchScores = () => {        
        let apiUrl = "https://gambler-api.codefellas.no/api/Gamblers/GetTop10";
        axios.get<IScore[]>(apiUrl).then((result => {
            // result comes here
            console.log(result.data);
            setScores(result.data);
        })).catch((error) => {
            alert(error);
        })
    }

    return (
        <table id="scorers">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Score</th>
                </tr>
            </thead>
                <tbody>
                    {scores?.map((s) => <tr><td>{s.nickname}</td><td>{s.points}</td></tr>)}            
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
}

