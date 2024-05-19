import React from 'react';
import './styles.css';

interface LongCardProps {
  children: React.ReactNode;
}

const LongCard: React.FC<LongCardProps> = ({ children }) => {
  return (
    <div className="long-card-container">
      <div className="long-card-shadow"></div>
      <div className="long-card">
        {children}
      </div>
    </div>
  );
};

export default LongCard;
