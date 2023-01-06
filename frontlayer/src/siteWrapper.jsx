import React, { useState, useEffect } from "react";
import LoginForm from "./loginForm";
import UserForm from "./loggedUserForm";
import ChartForm from "./ChartForm.js";

const SiteWrapper = () => {

    const [selectedSection, setSelectedSection] = useState(false);
    
    const [isAuthenticatedState, setIsAuthenticatedState] = useState(false);

    const [coords, setCoords] = useState();

    async function isAuthenticated() {
        var url = 'api/User/IsAuthenticated';
        const response = await fetch(url);
        const data = await response.json();
        setIsAuthenticatedState(data);
    }

    async function getMapCoords() {
        var url = 'api/Sensor/GetSensorList';
        const response = await fetch(url);
        const data = await response.json();
        console.log(data);
        setCoords(data);
    }

    useEffect(() => {
        isAuthenticated();
        getMapCoords();
    }, [])

    const onClickBtnHandler = (currentValue) => {
        if (selectedSection !== currentValue) setSelectedSection(!selectedSection);
    };

    return (
        <div style={{ width: '1000px', height: '670px', backgroundColor: '#C0CCC0', display: 'flex', alignItems: 'center', justifyContent: 'center'  }}>
            {isAuthenticatedState ? (
                <LoginForm setIsAuthenticatedState={setIsAuthenticatedState}/>
            ) : (
                <div>
                    <div style={{ width: '100%', display: 'flex', justifyContent: "space-evenly", cursor: 'pointer' }}>
                        <div style={{ width: '50px', height: '50px', backgroundColor: 'yellow', display: 'flex' , alignItems: 'center', justifyContent: 'center' }} onClick={() => setSelectedSection(!selectedSection)}>map</div>
                        <div style={{ width: '50px', height: '50px', backgroundColor: 'yellow', display: 'flex' , alignItems: 'center', justifyContent: 'center' }} onClick={() => setSelectedSection(!selectedSection)}>chart</div>
                    </div>
                    <div style={{ width: '1000px', height: '670px', backgroundColor: '#C0CCC0', display: 'flex', alignItems: 'center', justifyContent: 'center'  }}>{!selectedSection ? <ChartForm /> : <UserForm coords={coords} />}</div>
                </div>
            )}

        </div>
    );
}

export default SiteWrapper;