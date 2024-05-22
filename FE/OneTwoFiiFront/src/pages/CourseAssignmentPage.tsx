import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';
import '../styles/CourseAssignmentPage.module.css';
import { useAuth } from '../context/AuthContext';
import Button from '../components/Button/Button';

interface Assignment {
  assignmentId: string;
  assignmentQuestion: string;
  assignmentCode: string;
  assignmentCourseId: string;
  assignmentProfessorId: string;
  assignmentAnswersId: string[];
}

const CourseAssignmentsPage: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const { authFetch, role } = useAuth();
  const courseData = location.state?.courseData;
  const [assignments, setAssignments] = useState<Assignment[]>([]);
  const { token } = useAuth();

  useEffect(() => {
    if (!courseData) {
      navigate('/login');
      return;
    }

    const fetchAssignments = async () => {
      try {
        const response = await authFetch(`http://localhost:5079/api/v1/Assignments/courseId/${courseData.courseId}`, {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (response.ok) {
          const data = await response.json();
          setAssignments(data);
        } else {
          console.error('Failed to fetch assignments');
        }
      } catch (error) {
        console.error('Error fetching assignments:', error);
      }
    };

    fetchAssignments();
  }, [courseData, navigate]);

  const handleAddAssignment = () => {
    if (!token) {
      navigate('/login');
      return;
    }

    if (role == 'Student') {
      alert('You must be a professor to complete this action.');
      return;
    }

    navigate('/course/assignments/addassignment', { state: { courseData } });
  };

  const handleViewAnswers = (assignmentId: string) => {
    if (!token) {
      navigate('/login');
      return;
    }

    if (role === 'Student') {
      alert('You must be a professor to complete this action.');
      return;
    }

    navigate(`/course/assignments/viewanswers`, { state: { assignmentId, courseData } });
  };

  return (
    <div className="course-assignments-page">
      <Header />
      <h1 className="course-assignments-header">Assignments for {courseData?.courseName}</h1>
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        {assignments.map((assignment) => (
          <LongCard key={assignment.assignmentId}>
            <p className="assignment-question" style={{fontSize:'1.5rem'}}>{assignment.assignmentQuestion}</p>
            <pre style={{display:'flex',backgroundColor:'white',color:'black',borderRadius:'5px',padding:'10px'}}>{assignment.assignmentCode}</pre>
            <div className="button-group">
              <Button
                  text="View Answers"
                  onClick={() => handleViewAnswers(assignment.assignmentId)}
                  className="view-answers-button"
                />
            </div>
          </LongCard>
        ))}
      </div>
      <div style={{display:'flex',flexDirection:'row',justifyContent:'center', marginBottom:'10px'}}>
        <button className="add-assignment-button" onClick={handleAddAssignment} style={{backgroundColor:'#618B4A'}}>
          <span className="plus-icon">+</span> Add Assignment
        </button>
      </div>
    </div>
  );
};

export default CourseAssignmentsPage;
