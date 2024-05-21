import React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Header from '../components/Header/Header';
import Block from '../components/Block/Block';
import infoIcon from '../assets/information_icon.svg';
import resourcesIcon from '../assets/download_icon.svg';
import assignmentsIcon from '../assets/assignment_icon.svg';
import '../styles/CoursePage.module.css';

const CoursePage: React.FC = () => {
  const location = useLocation();
  const courseData = location.state?.courseData;
  const navigate = useNavigate();

  if (!courseData) {
    return <p>No course data found.</p>;
  }

  const handleInfoClick = () => {
    navigate('/course/info', { state: { courseData } });
  };

  const handleResourceClick = () => {
    navigate('/course/resources', { state: { courseData } });
  };

  const handleAssignmentsClick = () => {
    navigate('/course/assignments', { state: { courseData } });
  };

  return (
    <div className="course-page">
      <Header />
      <div className="course-content">
        <h1 style={{ display: 'flex', flexDirection: 'column', alignItems:'center', color:'black'}} className="course-header">{courseData.courseName}</h1>
        <div style={{display: 'flex', justifyContent:'space-evenly'}} className="course-blocks">
          <Block imageSrc={infoIcon} text="View info" onClick={handleInfoClick} />
          <Block imageSrc={resourcesIcon} text="Access resources" onClick={handleResourceClick} />
          <Block imageSrc={assignmentsIcon} text="View assignments" onClick={handleAssignmentsClick}/>
        </div>
      </div>
    </div>
  );
};

export default CoursePage;
