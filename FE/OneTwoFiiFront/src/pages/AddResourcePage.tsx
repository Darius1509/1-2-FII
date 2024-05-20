import React, { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import Card from '../components/Card/Card';
import Button from '../components/Button/Button';
import '../styles/AddResourcePage.module.css';

const AddResourcePage: React.FC = () => {
  const [resourceType, setResourceType] = useState('');
  const [resourceName, setResourceName] = useState('');
  const [resourceDescription, setResourceDescription] = useState('');
  const [resourcePrerequisites, setResourcePrerequisites] = useState('');
  const [resourceFile, setResourceFile] = useState<File | null>(null);
  const [error, setError] = useState('');
  const location = useLocation();
  const courseId = location.state?.courseData?.courseId;
  const navigate = useNavigate();

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files[0]) {
      setResourceFile(event.target.files[0]);
    }
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setError('');

    if (!resourceFile) {
      setError('Please select a file to upload.');
      return;
    }

    const formData = new FormData();
    formData.append('ResourceName', resourceName);
    formData.append('ResourceDescription', resourceDescription);
    formData.append('ResourceType', resourceType);
    formData.append('ResourcePrerequisites', resourcePrerequisites);
    formData.append('ResourceCourseId', courseId);
    formData.append('ResourceFileContent', resourceFile);

    try {
      const response = await fetch('http://localhost:5079/api/v1/Resources', {
        method: 'POST',
        body: formData,
      });

      if (response.ok) {
        setError('Resource uploaded successfully.');
        setResourceType('');
        setResourceName('');
        setResourceDescription('');
        setResourcePrerequisites('');
        setResourceFile(null);

      } else {
        const errorResponse = await response.json();
        setError(errorResponse.message || 'Failed to upload resource.');
      }
    } catch (error) {
      setError('Failed to upload resource.');
    }
  };

  return (
    <div className="add-resource-page">
      <Header />
      <Card>
        <h2 className="add-resource-header">Add a Resource</h2>
        <form className="resource-form" onSubmit={handleSubmit}>
          <label htmlFor="resourceType">Resource Type</label>
          <input
            type="text"
            id="resourceType"
            name="resourceType"
            value={resourceType}
            onChange={(e) => setResourceType(e.target.value)}
            required
          />

          <label htmlFor="resourceName">Resource Name</label>
          <input
            type="text"
            id="resourceName"
            name="resourceName"
            value={resourceName}
            onChange={(e) => setResourceName(e.target.value)}
            required
          />

          <label htmlFor="resourceDescription">Resource Description</label>
          <input
            type="text"
            id="resourceDescription"
            name="resourceDescription"
            value={resourceDescription}
            onChange={(e) => setResourceDescription(e.target.value)}
            required
          />

          <label htmlFor="resourcePrerequisites">Resource Prerequisites</label>
          <input
            type="text"
            id="resourcePrerequisites"
            name="resourcePrerequisites"
            value={resourcePrerequisites}
            onChange={(e) => setResourcePrerequisites(e.target.value)}
            required
          />

          <label htmlFor="uploadFile">Upload File</label>
          <input type="file" id="uploadFile" name="uploadFile" onChange={handleFileChange} required />

          <Button type="submit" className="upload-button" text="Upload" />

          {error && <p className="error">{error}</p>}
        </form>
      </Card>
    </div>
  );
};

export default AddResourcePage;
