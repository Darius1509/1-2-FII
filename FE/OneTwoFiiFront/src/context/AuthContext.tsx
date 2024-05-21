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
  authFetch: (input: RequestInfo, init?: RequestInit) => Promise<Response>;
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
  };

  const setUsername = (username: string) => {
    setUsernameState(username);
    localStorage.setItem('username', username);
  };

  const setUserId = (userId: string) => {
    setUserIdState(userId);
    localStorage.setItem('userId', userId);
  };

  const setRole = (role: string) => {
    setRoleState(role);
    localStorage.setItem('role', role);
  };

  const logout = async () => {
    try {
      await authFetch('http://localhost:5079/api/v1/Authentication/logout', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
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
      window.location.href = '/';
    }
  };

  const authFetch = async (input: RequestInfo, init?: RequestInit): Promise<Response> => {
    const token = localStorage.getItem('jwtToken');
    const authInit = {
      ...init,
      headers: {
        ...init?.headers,
        'Authorization': `Bearer ${token}`,
      },
    };
    return fetch(input, authInit);
  };

  return (
    <AuthContext.Provider value={{ token, setToken, username, setUsername, userId, setUserId, role, setRole, logout, authFetch }}>
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
