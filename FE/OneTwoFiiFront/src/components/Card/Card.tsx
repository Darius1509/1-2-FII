import React, { ReactNode } from 'react';
import './styles.css';

const Card: React.FC<{ children: ReactNode }> = ({ children }) => {
    return (
        <div className="card-container">
            <div className="card-shadow"></div>
            <div className="card">{children}</div>
        </div>
    );
};

export default Card;
