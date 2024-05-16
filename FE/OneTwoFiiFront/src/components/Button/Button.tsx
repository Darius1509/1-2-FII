import React from 'react';
import { Link } from 'react-router-dom';
import './styles.css';

interface ButtonProps {
  text: string;
  to?: string;
  type?: 'button' | 'submit' | 'reset';
  onClick?: () => void;
}

const Button: React.FC<ButtonProps> = ({ text, to, type = 'button', onClick }) => {
  if (to) {
    return (
      <Link to={to} className="custom-button">
        {text}
      </Link>
    );
  }

  return (
    <button className="custom-button" type={type} onClick={onClick}>
      {text}
    </button>
  );
};

export default Button;
