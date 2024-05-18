import React, { ReactNode } from 'react';
import './styles.css';

const LongCard: React.FC<{ children: ReactNode }> = ({ children }) => {
    return (
        <div className="long-card-container">
            <div className="long-card-shadow"></div>
            <div className="long-card">{children}</div>
        </div>
    );
};

export default LongCard;
