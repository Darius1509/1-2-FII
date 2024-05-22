import React, { useState } from 'react';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';
import '../styles/AddAssignmentPage.modules.css';
import { useAuth } from '../context/AuthContext';
import Button from '../components/Button/Button';
import Card from '../components/Card/Card';

const AddAnswerPage: React.FC = () => {
  const { authFetch } = useAuth();
  const location = useLocation();
  const assignmentData = location.state?.assignment;
  const [answerContent, setAnswerContent] = useState('');
  const [message, setMessage] = useState('');

  if (!assignmentData) {
    return <div>No assignment data found.</div>;
  }

  const handleAddAnswer = async (e: React.FormEvent) => {
    e.preventDefault();

    const newAnswer = {
      answerId: '3fa85f64-5717-4562-b3fc-2c963f66afa6', // Placeholder value
      answerAssignmentRespondedId: assignmentData.assignmentId,
      answerStudentId: localStorage.getItem('userId') || '',
      answerContent,
    };

    try {
      const response = await authFetch('http://localhost:5079/api/v1/Answers', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newAnswer),
      });

      if (response.ok) {
        setMessage('Answer added successfully!');
        setAnswerContent('');
      } else {
        setMessage('Failed to add answer.');
      }
    } catch (error) {
      console.error('Error adding answer:', error);
      setMessage('Error adding answer.');
    }
  };

  return (
    <div className="add-assignment-page">
      <Header />
      <Card>
        <h2 className="card-title">Add an answer</h2>
        <form className="add-assignment-form" onSubmit={handleAddAnswer}>
          <label htmlFor="answerContent">Answer content</label>
          <textarea
            id="answerContent"
            name="answerContent"
            value={answerContent}
            onChange={(e) => setAnswerContent(e.target.value)}
            required
            style={{backgroundColor:'white',color:'black',borderRadius:'5px',padding:'10px',width:'100%'}}
          />
          <Button type="submit" className="upload-button" text="Submit answer"></Button>
          {message && <p>{message}</p>}
        </form>
      </Card>
    </div>
  );
};

export default AddAnswerPage;
