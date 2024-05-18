import React from 'react';
import '../styles/CourseInfoPage.module.css';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';

const CourseInfoPage: React.FC = () => {
  const location = useLocation();
  const courseData = location.state?.courseData;

  if (!courseData) {
    return <p>No course data found.</p>;
  }

  return (
    <div className="course-info-page">
      <Header />
      <LongCard>
        <h2 className="course-info-header">{courseData.courseName}</h2>
        <p className="course-info-description">{courseData.courseDescription}</p>
        <p className="course-info-semester">Semester: {courseData.courseSemester}</p>
        <p className="course-info-credits">Credits: {courseData.courseNrOfCredits}</p>
        <a href={courseData.courseWebsite} className="course-info-website" target="_blank" rel="noopener noreferrer">
          Course Website
        </a>
      </LongCard>
    </div>
  );
};

export default CourseInfoPage;
