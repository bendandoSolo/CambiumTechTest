import React, { useState } from 'react';



const MarsMap = () => {

    //create map array from 0,0 to 5,5
    const initializeEmptyMap = () => {
        let dataArray = [];
        for (var y = 0; y < 6; y++) {
            dataArray[y] = [];
            for (var x = 0; x < 6; x++) {
                dataArray[y].push(' ');
            }
        }
        console.log(dataArray);
        return dataArray;
    }

    const [mapArray, setMapArray] = useState(initializeEmptyMap());




    return (
        <>
            <h2>Map of area of mars that rovers will be traversing</h2>
            <table>
                <tbody>
                    {mapArray.map((row, i) => <tr key={i}>{row.map((x, i2) => <td key={i2}>{row[i]}</td>)}</tr>)}
                </tbody>
            </table>
            <h3>Current Map Data</h3>
            {mapArray.map(function (item, index) {
                return (
                    <div key={index} >
                        <p > {JSON.stringify(item)} </p>
                    </div>
                );
            })
            }
        </>
    )


}


export default MarsMap;