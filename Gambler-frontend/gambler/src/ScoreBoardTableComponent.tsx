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
            {scores && scores.map((s : any) => <TableRow name={s.name} score={s.score}/>)}            
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


const TableRow = ({name, score} : IScore) => {

    return <tr>
        <td>{name}</td>
        <td>{score}</td>
    </tr>;

}