// src/components/Header.tsx
import React from 'react';
import Button from './Button';
import './Header.css';

const Header: React.FC = () => {
  return (
    <header className="header">
      <h1 className="app-name">1-2-FII</h1>
      <div className="header-buttons">
        <Button text="Login" />
        <Button text="Register" />
      </div>
    </header>
  );
};

export default Header;
