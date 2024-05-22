import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';
import { useAuth } from '../context/AuthContext';

type Answer = {
  answerId: string;
  answerAssignmentRespondedToId: string;
  answerStudentId: string;
  answerContent: string;
};

const ViewAnswersPage: React.FC = () => {
  const location = useLocation();
  const { assignmentId, courseData } = location.state || {};
  const [answers, setAnswers] = useState<Answer[]>([]);
  const { authFetch } = useAuth();

  useEffect(() => {
    if (assignmentId) {
      authFetch(`http://localhost:5079/api/v1/Answers/assignment/${assignmentId}`)
        .then((response) => {
          if (response.status === 404) {
            throw new Error('Not found');
          }
          return response.json();
        })
        .then((data: Answer[]) => {
          setAnswers(data);
        })
        .catch((error) => {
          console.error('Error fetching answers:', error);
        });
    }
  }, [assignmentId, authFetch]);

  if (!assignmentId || !courseData) {
    return <p>No assignment data found.</p>;
  }

  return (
    <div className="view-answers-page">
      <Header />
      <h1 className="view-answers-header">Answers for {courseData.courseName}</h1>
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        {answers.map((answer) => (
          <LongCard key={answer.answerId}>
            <p>Student ID: {answer.answerStudentId}</p>
            <pre className="code-snippet">{answer.answerContent}</pre>
          </LongCard>
        ))}
      </div>
    </div>
  );
};

export default ViewAnswersPage;
