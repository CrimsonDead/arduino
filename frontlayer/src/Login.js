import React, { Component, useState, useEffect } from 'react';

const Login = () => {

    const [state, setState] = useState({ data: [], loading: true });

    const [isAuthenticatedState, setIsAuthenticatedState] = useState({ data: Boolean, loading: true });

    async function isAuthenticated() {
        var url = 'api/User/IsAuthenticated';
        const response = await fetch(url);
        const data = await response.json();
        console.log(data);
        setIsAuthenticatedState({ data: data, loading: false });
    }
    document.addEventListener("DOMContentLoaded", isAuthenticated);

    const isAuthenticatedIndicator = () => {
        if (isAuthenticatedState)
            return (
                <p>Вы авторизированы</p>
            )
        else 
            return (
                <p>Нахуй пошел</p>
            )
    }

    async function LoginUser() {
        var url = 'api/User/Login';
        const response = await fetch(url, {
            method: 'POST',
            body: new FormData( document.getElementById('userData') ),
        })
    }

    async function RegUser() {
        var url = 'api/User/Register';
        const response = await fetch(url, {
            method: 'POST',
            body: new FormData( document.getElementById('userData') ),
        })
    }

    const onRegButtonClick = (event) => {
        event.stopPropagation();
        RegUser();
        isAuthenticated();
    }

    const onLoginButtonClick = (event) => {
        event.stopPropagation();
        LoginUser();
        isAuthenticated();
    }

    return (
        <div style={{
            border: '4px double #333', 
            borderSpacing: '7px 11px',
            marginLeft: '10'}}>
            <form id="userData">
                <label for="userName">User name:</label><br />
                <input type="text" id="userName" name="userName" /><br />
                <label for="email">Email:</label><br />
                <input type="text" id="email" name="email" /><br />
                <label for="password">Password:</label><br />
                <input type="text" id="password" name="password" /><br />
                </form>
            <div onClick={(event) => { onLoginButtonClick(event) }} 
                style={{alignContent: 'center', 
                    borderStyle: 'solid',
                    marginRight: '60%',
                    borderWidth: 'medium',
                    backgroundColor: 'rgb(240, 240, 240)'}}>
                Login
            </div>
            <div onClick={(event) => { onRegButtonClick(event) }} 
                style={{alignContent: 'center', 
                    borderStyle: 'solid',
                    marginRight: '60%',
                    borderWidth: 'medium',
                    backgroundColor: 'rgb(240, 240, 240)'}}>
                Register
            </div>
            <div>
                {isAuthenticatedIndicator()}
            </div>
        </div>
    )
}

export default Login;