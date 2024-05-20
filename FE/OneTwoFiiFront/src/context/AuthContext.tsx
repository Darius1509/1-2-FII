import React, { createContext, useState, ReactNode, useContext } from 'react';

interface AuthContextProps {
  token: string | null;
  setToken: (token: string) => void;
  username: string | null;
  setUsername: (username: string) => void;
  userId: string | null;
  setUserId: (userId: string) => void;
  role: string | null;
  setRole: (role: string) => void;
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
  const [userId, setUserIdState] = useState<string | null>(() => {
    return localStorage.getItem('userId');
  });
  const [role, setRoleState] = useState<string | null>(() => {
    return localStorage.getItem('role');
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

  const setUserId = (userId: string) => {
    setUserIdState(userId);
    localStorage.setItem('userId', userId);
    console.log('User ID set:', userId);
  };

  const setRole = (role: string) => {
    setRoleState(role);
    localStorage.setItem('role', role);
    console.log('Role set:', role);
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
      setUserIdState(null);
      setRoleState(null);
      localStorage.removeItem('jwtToken');
      localStorage.removeItem('username');
      localStorage.removeItem('userId');
      localStorage.removeItem('role');
      localStorage.removeItem('token')
      window.location.href = '/';
    }
  };

  return (
    <AuthContext.Provider value={{ token, setToken, username, setUsername, userId, setUserId, role, setRole, logout }}>
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
