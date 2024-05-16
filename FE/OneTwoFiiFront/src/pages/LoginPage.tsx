import React, { useState } from 'react';
import Card from '../components/Card/Card';
import Header from '../components/Header/Header';
import Button from '../components/Button/Button';
import '../styles/LoginPage.module.css';
import { useAuth } from '../context/AuthContext';

const LoginPage: React.FC = () => {
  const { setToken, setUsername } = useAuth();
  const [username, setUsernameState] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    const loginData = {
      userName: username,
      password: password,
    };

    try {
      const response = await fetch('http://localhost:5079/api/v1/Authentication/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginData),
      });

      if (!response.ok) {
        throw new Error('Login failed');
      }

      const token = await response.text();
      console.log('Received token:', token);
      setToken(token);
      setUsername(username);
      window.location.href = '/';
    } catch (error) {
      console.error('Login error:', error);
      setError('Login failed. Please check your username and password.');
    }
  };

  return (
    <div className="login-page">
      <Header />
      <Card>
        <h2 className="card-title">Welcome back!</h2>
        <form className="login-form" onSubmit={handleLogin}>
          <label htmlFor="UserName">Username</label>
          <input
            type="text"
            id="UserName"
            name="UserName"
            value={username}
            onChange={(e) => setUsernameState(e.target.value)}
            required
          />
          <label htmlFor="Password">Password</label>
          <input
            type="password"
            id="Password"
            name="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <Button text="Login" type="submit" />
          {error && <p className="error">{error}</p>}
        </form>
      </Card>
    </div>
  );
};

export default LoginPage;
