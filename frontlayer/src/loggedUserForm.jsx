import React from "react";
import { getMap } from './map.js'

const UserForm = () => {

    function success({ coords }) {
        const { latitude, longitude } = coords
        const currentPosition = [latitude, longitude]
        getMap(currentPosition, 'You are here')
      }
      
      function error({ message }) {
        console.log(message)
      }

    const btnHandler = () => {
        console.log('click');
        navigator.geolocation.getCurrentPosition(success, error, {
            enableHighAccuracy: true
          })
    };

    return (
        <div style={{ width: '100%', height: '100%', display: 'block' }}>
            <div style={{ width: '100%', height: '10%', display: 'flex' }}>
            <body>
                <div id="map"></div>
                <button id="my_position" onClick={() => btnHandler()}>My Position</button>
                {/* <script src="./script.js" type="module"></script> */}
            </body>
            </div>
        </div>
    );
};

export default UserForm;