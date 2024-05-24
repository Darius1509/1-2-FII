import React, { useState } from 'react';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import '../styles/AddAssignmentPage.modules.css';
import { useAuth } from '../context/AuthContext';
import Button from '../components/Button/Button';
import Card from '../components/Card/Card';

const AddAssignmentPage: React.FC = () => {
  const { authFetch } = useAuth();
  const location = useLocation();
  const courseData = location.state?.courseData;
  const [assignmentQuestion, setAssignmentQuestion] = useState('');
  const [assignmentCode, setAssignmentCode] = useState('');
  const [message, setMessage] = useState('');

  const handleAddAssignment = async (e: React.FormEvent) => {
    e.preventDefault();

    const newAssignment = {
      assignmentId: '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
      assignmentQuestion,
      assignmentCode,
      assignmentCourseId: courseData.courseId,
      assignmentProfessorId: localStorage.getItem('userId') || '',
      assignmentAnswersId: ['3fa85f64-5717-4562-b3fc-2c963f66afa6']
    };

    try {
      const response = await authFetch('http://localhost:5079/api/v1/Assignments', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newAssignment),
      });

      if (response.ok) {
        setMessage('Assignment added successfully!');
        setAssignmentQuestion('');
        setAssignmentCode('');
      } else {
        setMessage('Failed to add assignment.');
      }
    } catch (error) {
      console.error('Error adding assignment:', error);
      setMessage('Error adding assignment.');
    }
  };

  return (
    <div className="add-assignment-page">
      <Header />
      <Card>
        <h2 className="card-title">Add an assignment</h2>
        <form className="add-assignment-form" onSubmit={handleAddAssignment}>
          <label htmlFor="assignmentQuestion">Assignment question</label>
          <input
            type="text"
            id="assignmentQuestion"
            name="assignmentQuestion"
            value={assignmentQuestion}
            onChange={(e) => setAssignmentQuestion(e.target.value)}
            required
          />
          <label htmlFor="assignmentCode">Code snippet</label>
          <textarea
            id="assignmentCode"
            name="assignmentCode"
            value={assignmentCode}
            onChange={(e) => setAssignmentCode(e.target.value)}
            required
            style={{backgroundColor:'white',color:'black',borderRadius:'5px',padding:'10px',width:'100%'}}
          />
          <Button type="submit" text="Upload"></Button>
          {message && <p>{message}</p>}
        </form>
      </Card>
    </div>
  );
};

export default AddAssignmentPage;
