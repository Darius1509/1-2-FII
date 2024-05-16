import React, { createContext, useState, ReactNode, useContext } from 'react';

interface AuthContextProps {
  token: string | null;
  setToken: (token: string) => void;
  username: string | null;
  setUsername: (username: string) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextProps | undefined>(undefined);

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [token, setTokenState] = useState<string | null>(() => {
    return localStorage.getItem('jwtToken');
  });
  const [username, setUsernameState] = useState<string | null>(() => {
    return localStorage.getItem('username');
  });

  const setToken = (token: string) => {
    setTokenState(token);
    localStorage.setItem('jwtToken', token);
    console.log('JWT token set:', token);
  };

  const setUsername = (username: string) => {
    setUsernameState(username);
    localStorage.setItem('username', username);
    console.log('Username set:', username);
  };

  const logout = async () => {
    try {
      await fetch('http://localhost:5079/api/v1/Authentication/logout', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
      });
    } catch (error) {
      console.error('Logout error:', error);
    } finally {
      setTokenState(null);
      setUsernameState(null);
      localStorage.removeItem('jwtToken');
      localStorage.removeItem('username');
      window.location.href = '/';
    }
  };

  return (
    <AuthContext.Provider value={{ token, setToken, username, setUsername, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = (): AuthContextProps => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};
