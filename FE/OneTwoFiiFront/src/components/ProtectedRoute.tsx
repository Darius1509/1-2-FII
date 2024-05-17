import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

interface ProtectedRouteProps {
  component: React.FC;
  path: string;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ component: Component, path }) => {
  const { token } = useAuth();

  return token ? <Component /> : <Navigate to="/login" />;
};

export default ProtectedRoute;
