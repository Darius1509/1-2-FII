// src/components/Button.tsx
import React from 'react';
import { Link } from 'react-router-dom';
import './styles.css';

interface ButtonProps {
  text: string;
  to?: string;
  type?: 'button' | 'submit' | 'reset';
  onClick?: () => void;
  className?: string;
}

const Button: React.FC<ButtonProps> = ({ text, to, type, onClick, className }) => {
  if (to) {
    return (
      <Link to={to} className={`custom-button ${className}`} type={type}>
        {text}
      </Link>
    );
  }

  return (
    <button className={`custom-button ${className}`} type={type} onClick={onClick}>
      {text}
    </button>
  );
};

export default Button;
