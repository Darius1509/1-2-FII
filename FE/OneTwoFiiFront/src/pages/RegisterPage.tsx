import React, { useState } from 'react';
import Card from '../components/Card/Card';
import Header from '../components/Header/Header';
import Button from '../components/Button/Button';
import '../styles/RegisterPage.module.css';

const RegisterPage: React.FC = () => {
  const [username, setUsername] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [repeatPassword, setRepeatPassword] = useState('');
  const [role, setRole] = useState('Student');
  const [error, setError] = useState('');

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    if (password !== repeatPassword) {
      setError('Passwords do not match');
      return;
    }

    const registerData = {
      email,
      password,
      userName: username,
      firstName,
      lastName,
      role,
    };

    try {
      const response = await fetch('http://localhost:5079/api/v1/Authentication/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(registerData),
      });

      if (!response.ok) {
        throw new Error('Registration failed');
      }

      const data = await response.json();
      console.log('Registered user:', data);

      window.location.href = '/';
    } catch (error) {
      console.error('Registration error:', error);
      setError('Registration failed. Please check your input.');
    }
  };

  return (
    <div className="register-page">
      <Header />
      <Card>
        <h2 className="card-title">Get started!</h2>
        <form className="register-form" onSubmit={handleRegister}>
          <label htmlFor="Username">Username</label>
          <input
            type="text"
            id="Username"
            name="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
          <label htmlFor="FirstName">First Name</label>
          <input
            type="text"
            id="FirstName"
            name="FirstName"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />
          <label htmlFor="LastName">Last Name</label>
          <input
            type="text"
            id="LastName"
            name="LastName"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
          <label htmlFor="Email">Email</label>
          <input
            type="email"
            id="Email"
            name="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
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
          <label htmlFor="RepeatPassword">Repeat Password</label>
          <input
            type="password"
            id="RepeatPassword"
            name="RepeatPassword"
            value={repeatPassword}
            onChange={(e) => setRepeatPassword(e.target.value)}
            required
          />
          <label htmlFor="Role">Are you a teacher or student?</label>
          <select
            id="Role"
            name="Role"
            value={role}
            onChange={(e) => setRole(e.target.value)}
          >
            <option value="Student">Student</option>
            <option value="Professor">Professor</option>
          </select>
          <Button text="Register" type="submit" />
          {error && <p className="error">{error}</p>}
        </form>
      </Card>
    </div>
  );
};

export default RegisterPage;
