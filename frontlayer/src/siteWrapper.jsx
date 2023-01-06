import React, { useState, useEffect } from "react";
import LoginForm from "./loginForm";
import UserForm from "./loggedUserForm";
import ChartForm from "./ChartForm.js";

const SiteWrapper = () => {

    const [isAuthenticatedState, setIsAuthenticatedState] = useState(false);

    async function isAuthenticated() {
        var url = 'api/User/IsAuthenticated';
        const response = await fetch(url);
        const data = await response.json();
        setIsAuthenticatedState(data);
    }

    useEffect(() => {
        isAuthenticated();
    }, [])

    return (
        <div style={{ width: '100%', height: '1000px', backgroundColor: '#C0CCC0', display: 'flex', alignItems: 'center', justifyContent: 'center'  }}>
            {isAuthenticatedState ? (
                <LoginForm setIsAuthenticatedState={setIsAuthenticatedState}/>
            ) : (
                <ChartForm />
                // <UserForm />
                
            )}

        </div>
    );
}

export default SiteWrapper;