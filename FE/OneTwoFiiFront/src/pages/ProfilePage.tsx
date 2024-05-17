// src/pages/ProfilePage.tsx
import React, { useState } from 'react';
import Card from '../components/Card/Card';
import Header from '../components/Header/Header';
import '../styles/ProfilePage.module.css';
import { useAuth } from '../context/AuthContext';
import profileIcon from '../assets/profile_icon.svg';

const ProfilePage: React.FC = () => {
  const { token } = useAuth();
  const [userInfo, setUserInfo] = useState<{ username: string; role: string; id: string } | null>(null);
  const [error, setError] = useState<string | null>(null);

  const fetchUserInfo = async () => {
    try {
      const response = await fetch('http://localhost:5079/api/v1/Authentication/currentuserinfo', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        throw new Error('Failed to fetch user info');
      }

      const data = await response.json();
      const username = data.claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
      const role = data.claims["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      const id = data.claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
      setUserInfo({ username, role, id });
      setError(null);
    } catch (error) {
      setError('Failed to fetch user info');
      setUserInfo(null);
    }
  };

  return (
    <div className="profile-page">
      <Header />
      <Card>
        <div className="profile-card-content">
        <img src={profileIcon} alt="Profile" className="profile-card-icon" style={{ width: '30%', height: 'auto', marginRight: '20px' }} />
          <div className="profile-card-details">
            <h2 className="card-title">Profile Page</h2>
            <button className="fetch-info-button" onClick={fetchUserInfo}>Fetch Info</button>
            {userInfo && (
              <div className="user-info">
                <p><strong>Username:</strong> {userInfo.username}</p>
                <p><strong>Role:</strong> {userInfo.role}</p>
                <p><strong>ID:</strong> {userInfo.id}</p>
              </div>
            )}
            {error && <p className="error-message">{error}</p>}
          </div>
        </div>
      </Card>
    </div>
  );
};

export default ProfilePage;
