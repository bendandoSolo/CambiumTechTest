import React, { useState } from 'react';
import CSVUploader from './components/CSVUploader';
import MarsMap from './components/MarsMap';

const RoverTestPage = () => {

    const [data, setData] = useState({});
    //const [dataReady, setDataReady] = useState(false);

    const handleData = (csvData) => {
        setData(data => csvData);
        //setDataReady(Object.keys(csvData).length === 0 ? false : true);
    }



    return (
        <>
        <h1>Rover Test Page</h1>
            <CSVUploader handleData={handleData} />
            {Object.keys(data).length === 0 ? <p>No Data loaded</p> : <p>Data loaded</p>}
            <MarsMap data={data} />
        </>
        )

}


export default RoverTestPage;
