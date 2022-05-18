import React, { useState } from 'react';

const rover = (index, direction, step) => ({ no: index, direction, step });
//const MapCell = ({ data }) => <td>Rovers: {JSON.stringify(data.rovers)}</td>;
const MapCell = ({ data }) => <td>{data.rovers.length ? JSON.stringify(data.rovers) : ' '}</td>;


const MarsMap = ({data}) => {
    //create map array from 0,0 to 5,5
    const initializeEmptyMap = () => {
        let dataArray = [];
        for (var y = 0; y < 6; y++) {
            dataArray[y] = [];
            for (var x = 0; x < 6; x++) {
                dataArray[y].push({ rovers: [] });
            }
        }
        console.log(dataArray);
        return dataArray;
    }

    const [mapArray, setMapArray] = useState(initializeEmptyMap());
    const [step, setStep] = useState(0);

    const runTest = () => {
        let step = 0;
        for (let i = 0; i < data.length; i++) {
            let currentRoverData = data[i];
            for (let j = 0; j < currentRoverData.length; j++) {
                let xpos = currentRoverData[j].x;
                let ypos = currentRoverData[j].y;
                console.log(xpos + "" + ypos);
                step++;
                mapArray[ypos][xpos].rovers.push(rover(i, currentRoverData[j].direction, step));
            }
        }
        setStep(step);
        console.log(JSON.stringify(mapArray));
        setMapArray([...mapArray]);
    }


    return (
        <>
            <h2>Map of area of mars that rovers will be traversing</h2>
            <table>
                <tbody>
                    {mapArray.map((row, i) => <tr key={i}>{row.map((x, i2) => <MapCell key={i2} data={x} step={step} />)}</tr>)}
                </tbody>
            </table>

            {Object.keys(data).length > 0 &&
                <>
                <h3>Test Controls</h3>
                <button onClick={runTest}>Run Test</button>
                </>
            }
            <h3>Current Map Data</h3>
            {mapArray.map(function (item, index) {
                return (
                    <div key={index} >
                        <p > {JSON.stringify(item)} </p>
                    </div>
                );
            })
            }
            <h3>Current Loaded Data</h3>
            {
                Object.keys(data).length > 0 && data.map(function (item, index) {
                    return (
                        <div key={index}>
                            <p > {JSON.stringify(item)} </p>
                        </div>
                    );
                })
            }
            {Object.keys(data).length === 0 ? <p>No Data loaded</p> : <p>Data loaded</p>}
        </>
    )


}


export default MarsMap;