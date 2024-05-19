import React, { useEffect, useState } from 'react';
import '../styles/CourseResourcePage.module.css';
import { useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import LongCard from '../components/LongCard/LongCard';
import Button from '../components/Button/Button';

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
  const courseData = location.state?.courseData;
  const [resources, setResources] = useState<Resource[]>([]);

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
            <Button
              text="Download"
              onClick={() => handleDownload(resource.resourceId, `${resource.resourceName}`)}
              className="download-button"
            >
            </Button>
          </LongCard>
        ))}
      </div>
    </div>
  );
};

export default CourseResourcePage;
