import { useAuth } from '../context/AuthContext';

const useApi = () => {
  const { token } = useAuth();

  const apiFetch = async (url: string, options: RequestInit = {}) => {
    const headers = {
      ...options.headers,
      Authorization: `Bearer ${token}`,
    };

    const response = await fetch(url, { ...options, headers });
    if (!response.ok) {
      throw new Error('API request failed');
    }
    return response.json();
  };

  return { apiFetch };
};

export default useApi;