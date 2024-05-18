import React from 'react';
import './styles.css';

interface BlockProps {
  imageSrc: string;
  text: string;
  onClick?: () => void;
}

const Block: React.FC<BlockProps> = ({ imageSrc, text, onClick }) => {
  return (
    <div className="block-container" onClick={onClick}>
      <div className="block-upper">
        <img src={imageSrc} alt={text} className="block-image" />
      </div>
      <div className="block-lower">
        <p>{text}</p>
      </div>
    </div>
  );
};

export default Block;
