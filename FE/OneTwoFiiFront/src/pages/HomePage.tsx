import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Header from '../components/Header/Header';
import styles from '../styles/HomePage.module.css';
import studentImage from '../assets/student_image.svg';
import searchIcon from '../assets/search_icon.svg';

const HomePage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();

  const handleSearch = async () => {
    try {
      const response = await fetch(`http://localhost:5079/api/v1/Courses/name/${encodeURIComponent(searchTerm)}`);
      if (response.status === 404) {
        navigate('/not-found');
        return;
      }

      const data = await response.json();
      navigate('/course', { state: { courseData: data } });
    } catch (error) {
      console.error('Error fetching course:', error);
      navigate('/not-found');
    }
  };

  return (
    <div className={styles.homepage}>
      <Header />
      <main className={styles['main-content']}>
        <div className={styles['text-container']}>
          <div className={styles['text-content']}>
            <h2 className={styles['main-header']}>The place that bridges the gap between teachers and students.</h2>
            <p className={styles['sub-text']}>
              1-2-FII offers guidance and scripts that can help students get up to speed with their labs and help teachers see real time progress of their students.
            </p>
            <div className={styles['search-bar-container']}>
              <input
                type="text"
                className={styles['search-bar']}
                placeholder="Search for a class..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
              />
              <button className={styles['search-button']} onClick={handleSearch}>
                <img src={searchIcon} alt="Search" />
              </button>
            </div>
          </div>
          <div className={styles['image-content']}>
            <img src={studentImage} alt="Student" />
          </div>
        </div>
      </main>
    </div>
  );
};

export default HomePage;
