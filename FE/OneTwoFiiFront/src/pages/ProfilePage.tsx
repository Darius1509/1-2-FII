import React from 'react';
import Card from '../components/Card/Card';
import Header from '../components/Header/Header';
import '../styles/ProfilePage.module.css';

const ProfilePage: React.FC = () => {
  return (
    <div className="profile-page">
      <Header />
      <Card>
        <h2 className="card-title">Profile Page</h2>
        {/* Additional profile information can go here */}
      </Card>
    </div>
  );
};

export default ProfilePage;
