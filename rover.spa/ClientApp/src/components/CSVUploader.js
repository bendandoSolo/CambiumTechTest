import React, {useCallback} from 'react';
import { useDropzone } from 'react-dropzone';


const CVSUploader = () => {

    const onDrop = useCallback((acceptedFiles) => {
        acceptedFiles.forEach((file) => {
            const reader = new FileReader()
            reader.onabort = () => console.log('file reading was aborted')
            reader.onerror = () => console.log('file reading has failed')
            reader.onload = () => {
                var data = new FormData();
                data.append('file', file);
                uploadCSVToServer(data);
            }
            reader.readAsArrayBuffer(file)
        })

    }, [])

    const uploadCSVToServer = async (filedata) => {
        try {
            var response = await fetch('api/file', {
                method: 'POST',
                body: filedata,
            });
            var json = await response.json();
            alert(JSON.stringify(json));
            //console.log(JSON.stringify(json));

        }
        catch (ex) { console.error(ex); }
    };

    const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })

    return (
        <>
            <h2>To begin upload a file to the server for processing</h2>
            <div className='csv-uploader-container' {...getRootProps()}>
                <input {...getInputProps()} />
                {
                    isDragActive ?
                        <p>Drop the files here ...</p> :
                        isDragActive ? <p>Drop files here...</p> :
                            <div>
                                <h5 className='csv-uploader-header' >Upload CSV File</h5>
                                <p className='text-center'>Try dropping a CSV file here, or click to select files to upload.</p>
                            </div>
                }
            </div>
        </>
        )


}


export default CVSUploader;