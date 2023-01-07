import React, { useEffect } from "react";
import { getMap } from './map.js'

const UserForm = ({coords}) => {

    const qwe = [
        54.570717,
        27.276983
    ];

    async function success({ coords }) {
        const { latitude, longitude } = coords;
        const currentPosition = [latitude, longitude];
        console.log(currentPosition);
        getMap(qwe, 'searched position');
        // getMap(currentPosition, 'current position')
    }
    
    function error({ message }) {
      console.log(message)
    }

    const btnHandler = () => {
        navigator.geolocation.getCurrentPosition(success, error, {
            enableHighAccuracy: true
          })
    };

    const handler = () => getMap(qwe, 'current position')

    useEffect(() => btnHandler(), []);

    return (
        <div style={{ width: '100%', height: '100%', display: 'block' }}>
            <div style={{ width: '100%', height: '10%', display: 'flex' }}>
                
            <body>
                <div id="map"></div>
                <button id="my_position" onClick={() => handler()}>My Position</button>
                <div id="cities"></div>
                {/* <script src="./script.js" type="module"></script> */}
            </body>
            </div>
        </div>
    );
};

export default UserForm;