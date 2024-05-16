import React from 'react';
import Header from '../components/Header/Header';
import styles from '../styles/HomePage.module.css';
import studentImage from '../assets/student_image.svg';
import searchIcon from '../assets/search_icon.svg';

const HomePage: React.FC = () => {
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
              <input type="text" className={styles['search-bar']} placeholder="Search for a class..." />
              <button className={styles['search-button']}>
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
