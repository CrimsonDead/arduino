import React, { Component, useState, useEffect } from 'react';

const App = () => {

    const onButtonClick = (event) => {
        event.stopPropagation();
        populateUser(inputIdState);
    }

    const [state, setState] = useState({ data: [], loading: true });

    const [inputIdState, setInputIdState] = useState('');

    const [inputDateState, setInputDateState] = useState('');

    const onInputIdChange = (event) => {
        event.stopPropagation();
        const { target: { value } } = event;
        setInputIdState(value);
    }

    async function populateUser(inputState) {
        //console.log("пошел нахуй");
        var url = `api/sensordata?is=${inputState}`;
        //var url = `api/user?unp=${inputState}`;
        const response = await fetch(url);
        const data = await response.json();
        console.log(data);
        setState({ unps: data, loading: false });
        console.log(state.unps.value);
        //console.log("пошел нахуй");
    }

    const onInputDateChange = (event) => {
        event.stopPropagation();
        const { target: { value } } = event;
        setInputDateState(value);
    }

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel" style={{
            border: '4px double #333', 
            borderCollapse: 'separate',
            width: '100%',
            borderSpacing: '7px 11px'}}>
            <thead>
                <tr>
                    <th>User unique number</th>
                    <th>User Email</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input onChange={(event) => onInputIdChange(event)} type="text" name="Id" placeholder="Data Identifier" /></td>
                    <td><input onChange={(event) => onInputDateChange(event)} type="text" name="Date" placeholder="Date of the data" /></td>
                </tr>
                <tr>
                    <td>
                        <div onClick={(event) => { onButtonClick(event) }} 
                            style={{alignContent: 'center', 
                                    borderStyle: 'solid',
                                    marginRight: '60%',
                                    borderWidth: 'medium'}}>
                            Check
                        </div>
                    </td>
                </tr>
            </tbody>
        </table >
    );
}


export default App;