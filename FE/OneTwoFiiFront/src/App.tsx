import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import ProfilePage from './pages/ProfilePage';
import { AuthProvider } from './context/AuthContext';
import ProtectedRoute from './components/ProtectedRoute';
import CoursePage from './pages/CoursePage';
import NotFoundPage from './pages/NotFoundPage';
import CourseInfoPage from './pages/CourseInfoPage';
import CourseResourcePage from './pages/CourseResourcePage';
import AddResourcePage from './pages/AddResourcePage';
import UpdateResourcePage from './pages/UpdateResourcePage';
import CourseAssignmentsPage from './pages/CourseAssignmentPage';
import AddAssignmentPage from './pages/AddAssignmentPage';
import ViewAnswersPage from './pages/ViewAnswersPage';
import AddAnswerPage from './pages/AddAnswerPage';

const App: React.FC = () => {
  return (
    <AuthProvider>
      <Router>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route
            path="/profile"
            element={<ProtectedRoute component={ProfilePage} path="/profile" />}
          />
          <Route path="/course" element={<CoursePage/>}/>
          <Route path="/course/info" element={<CourseInfoPage/>}/>
          <Route path="/course/resources" element={<CourseResourcePage/>}/>
          <Route path="/course/resources/addresource" element={<AddResourcePage />} />
          <Route path="/course/resources/updateresource" element={<UpdateResourcePage />} />
          <Route
            path="/course/assignments"
            element={<ProtectedRoute component={CourseAssignmentsPage} path="/course/assignments" />}
          />
          <Route path="/course/assignments/addassignment" element={<AddAssignmentPage />} />
          <Route path="/course/assignments/viewanswers" element={<ViewAnswersPage />} />
          <Route path="/course/assignments/addanswer" element={<AddAnswerPage />} />
          <Route path="*" element={<NotFoundPage/>} />
        </Routes>
      </Router>
    </AuthProvider>
  );
};

export default App;
