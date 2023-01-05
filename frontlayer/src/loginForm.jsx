import React, { Component, useState, useEffect } from 'react';

const LoginForm = ({ setIsAuthenticatedState }) => {

    async function LoginUser() {
        var url = 'api/User/Login';
        const response = await fetch(url, {
            method: 'POST',
            body: new FormData( document.getElementById('userData') ),
        })
        if (response.ok) setIsAuthenticatedState(true);
    }

    async function RegUser() {
        var url = 'api/User/Register';
        const response = await fetch(url, {
            method: 'POST',
            body: new FormData( document.getElementById('userData') ),
        })
        if (response.ok) setIsAuthenticatedState(true);
    }

    const onRegButtonClick = (event) => {
        event.stopPropagation();
        RegUser();
    }

    const onLoginButtonClick = (event) => {
        event.stopPropagation();
        LoginUser();
    }

    return (
        <div style={{
            border: '4px double #333', 
            borderSpacing: '7px 11px',
            marginLeft: '10'}}>
            <form id="userData" style={{ margin: '10px' }}>
                <label for="userName">User name:</label><br />
                <input type="text" id="userName" name="userName" /><br />
                <label for="email">Email:</label><br />
                <input type="text" id="email" name="email" /><br />
                <label for="password">Password:</label><br />
                <input type="text" id="password" name="password" /><br />
                </form>
            <div style={{ display: 'flex', margin: '10px', justifyContent: 'space-evenly' }}>
            <div onClick={(event) => { onLoginButtonClick(event) }} 
                style={{alignContent: 'center', 
                    borderStyle: 'solid',
                    borderWidth: 'medium',
                    backgroundColor: 'rgb(240, 240, 240)'}}>
                Login
            </div>
            <div onClick={(event) => { onRegButtonClick(event) }} 
                style={{alignContent: 'center', 
                    borderStyle: 'solid',
                    borderWidth: 'medium',
                    backgroundColor: 'rgb(240, 240, 240)'}}>
                Register
            </div>
            </div>
        </div>
    )
}

export default LoginForm;