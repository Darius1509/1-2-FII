import React, { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import Header from '../components/Header/Header';
import Card from '../components/Card/Card';
import Button from '../components/Button/Button';
import '../styles/UpdateResourcePage.module.css';

const UpdateResourcePage: React.FC = () => {
  const location = useLocation();
  const resource = location.state?.resource;
  const courseData = location.state?.courseData;
  const [resourceType, setResourceType] = useState(resource.resourceType);
  const [resourceName, setResourceName] = useState(resource.resourceName);
  const [resourceDescription, setResourceDescription] = useState(resource.resourceDescription);
  const [resourcePrerequisites, setResourcePrerequisites] = useState(resource.resourcePrerequisites);
  const [resourceFile, setResourceFile] = useState<File | null>(null);
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files[0]) {
      setResourceFile(event.target.files[0]);
    }
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setError('');

    const formData = new FormData();
    formData.append('ResourceId', resource.resourceId);
    formData.append('ResourceName', resourceName);
    formData.append('ResourceDescription', resourceDescription);
    formData.append('ResourceType', resourceType);
    formData.append('ResourcePrerequisites', resourcePrerequisites);
    formData.append('ResourceCourseId', courseData.courseId);
    formData.append('ResourceFileContent', resourceFile || new Blob([resource.resourceFileContent], { type: 'text/plain' }));

    try {
      const response = await fetch(`http://localhost:5079/api/v1/Resources/${resource.resourceId}`, {
        method: 'PUT',
        body: formData,
      });

      if (response.status === 202) {
        setError('Resource updated successfully.');
      } else {
        const errorResponse = await response.json();
        setError(errorResponse.message || 'Failed to update resource.');
      }
    } catch (error) {
      setError('Failed to update resource.');
    }
  };

  return (
    <div className="add-resource-page">
      <Header />
      <Card>
        <h2 className="add-resource-header">Update a Resource</h2>
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
          <input type="file" id="uploadFile" name="uploadFile" onChange={handleFileChange} />

          <Button type="submit" className="upload-button" text="Update" />

          {error && <p className="error">{error}</p>}
        </form>
      </Card>
    </div>
  );
};

export default UpdateResourcePage;
