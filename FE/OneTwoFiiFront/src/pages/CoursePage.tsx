import React from 'react';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import '../styles/CoursePage.module.css';

const CoursePage: React.FC = () => {
  const location = useLocation();
  const courseData = location.state?.courseData;

  if (!courseData) {
    return <p>No course data found.</p>;
  }

  return (
    <div>
      <Header />
      <h2 style={{ color: 'black', textAlign: 'center', fontSize: '2rem', margin: 0 }}>{courseData.courseName}</h2>
    </div>
  );
};

export default CoursePage;
