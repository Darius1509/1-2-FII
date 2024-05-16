import React from 'react';
import Button from '../Button/Button';
import { useAuth } from '../../context/AuthContext';
import './styles.css';

const Header: React.FC = () => {
  const { token, username, logout } = useAuth();

  return (
    <header className="header">
      <h1 className="app-name">1-2-FII</h1>
      <div className="header-buttons">
        {token ? (
          <>
            <span className="username">Welcome, {username}!</span>
            <Button text="Logout" onClick={logout} />
          </>
        ) : (
          <>
            <Button text="Login" to="/login" />
            <Button text="Register" to="/register" />
          </>
        )}
      </div>
    </header>
  );
};

export default Header;
