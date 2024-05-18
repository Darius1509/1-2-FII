import React from 'react';
import { Link } from 'react-router-dom';
import Button from '../Button/Button';
import { useAuth } from '../../context/AuthContext';
import profileIcon from '../../assets/profile_icon.svg';
import './styles.css';

const Header: React.FC = () => {
  const { token, username, logout } = useAuth();

  return (
    <header className="header">
      <Link to="/" className="app-name">1-2-FII</Link>
      <div className="header-buttons">
        {token ? (
          <>
            <Link to="/profile">
              <img src={profileIcon} alt="Profile" className="profile-icon" />
            </Link>
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
