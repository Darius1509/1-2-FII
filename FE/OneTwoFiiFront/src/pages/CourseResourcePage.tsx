import React, { useEffect, useState } from 'react';
import '../styles/CourseResourcePage.module.css';
import { useLocation, useNavigate } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';
import Button from '../components/Button/Button';
import { useAuth } from '../context/AuthContext';

type Resource = {
  resourceId: string;
  resourceName: string;
  resourceDescription: string;
  resourceType: string;
  resourcePrerequisites: string;
  resourceFileContent: string;
  resourceCourseId: string;
};

const CourseResourcePage: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const courseData = location.state?.courseData;
  const [resources, setResources] = useState<Resource[]>([]);
  const { token, role } = useAuth();

  useEffect(() => {
    if (courseData?.courseId) {
      fetch(`http://localhost:5079/api/v1/Resources/courseId/${courseData.courseId}`)
        .then((response) => {
          if (response.status === 404) {
            throw new Error('Not found');
          }
          return response.json();
        })
        .then((data: Resource[]) => {
          setResources(data);
        })
        .catch((error) => {
          console.error('Error fetching resources:', error);
        });
    }
  }, [courseData?.courseId]);

  const handleDownload = (resourceId: string, resourceName: string) => {
    fetch(`http://localhost:5079/api/v1/Resources/download/${resourceId}`, {
      method: 'GET',
    })
      .then((response) => response.blob())
      .then((blob) => {
        const url = window.URL.createObjectURL(new Blob([blob]));
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', resourceName);
        document.body.appendChild(link);
        link.click();
        link.parentNode?.removeChild(link);
      })
      .catch((error) => {
        console.error('Error downloading file:', error);
      });
  };

  const handleDelete = async (resourceId: string) => {
    if (!token) {
      navigate('/login');
      return;
    }

    if (role == 'Student') {
      alert('You must be a professor to complete this action.');
      return;
    }

    try {
      const response = await fetch(`http://localhost:5079/api/v1/Resources/${resourceId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify({ resourceId }),
      });

      if (response.ok) {
        const deletedResource = await response.json();
        setResources((prevResources) =>
          prevResources.filter((resource) => resource.resourceId !== deletedResource.resourceId)
        );
      } else {
        console.error('Failed to delete resource');
      }
    } catch (error) {
      console.error('Error deleting resource:', error);
    }
  };

  const handleAddResource = () => {
    if (!token) {
      navigate('/login');
      return;
    }

    if (role == 'Student') {
      alert('You must be a professor to complete this action.');
      return;
    }

    navigate('/course/resources/addresource', { state: { courseData } });
  };

  const handleUpdate = (resource: Resource) => {
    if (!token) {
      navigate('/login');
      return;
    }

    if (role === 'Student') {
      alert('You must be a professor to complete this action.');
      return;
    }

    navigate('/course/resources/updateresource', { state: { resource, courseData } });
  };

  if (!courseData) {
    return <p>No course data found.</p>;
  }

  return (
    <div className="course-resource-page">
      <Header />
      <h1 className="course-resource-header">Resources for {courseData.courseName}</h1>
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        {resources.map((resource) => (
          <LongCard key={resource.resourceId}>
            <h3>[{resource.resourceType}] {resource.resourceName}</h3>
            <p>Description: {resource.resourceDescription}</p>
            <p>Prerequisites: {resource.resourcePrerequisites}</p>
            <div className="button-group">
              <Button
                text="Download"
                onClick={() => handleDownload(resource.resourceId, resource.resourceName)}
                className="download-button"
              />
              <Button
                text="Delete"
                onClick={() => handleDelete(resource.resourceId)}
                className="delete-button"
              />
              <Button
                text="Update"
                onClick={() => handleUpdate(resource)}
                className="update-button"
              />
            </div>
          </LongCard>
        ))}
      </div>
      <div style={{display:'flex',flexDirection:'row',justifyContent:'center', marginBottom:'10px'}}>
        <button className="add-resource-button" onClick={handleAddResource} style={{backgroundColor:'#618B4A'}}>
          <span className="plus-icon">+</span> Add Resource
        </button>
      </div>
    </div>
  );
};

export default CourseResourcePage;
