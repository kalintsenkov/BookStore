import React, { createContext, useState } from 'react';

import usersService from '../services/usersService';

interface IAuthenticationContextProps {
  children?: React.ReactNode;
}

export const AuthenticationContext = createContext({
  isAuthenticated: usersService.isAuthenticated(),
  setIsAuthenticated: (isAuthenticated: boolean) => {}
});

const AuthenticationContextProvider = ({ children }: IAuthenticationContextProps): JSX.Element => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(usersService.isAuthenticated());

  return (
    <AuthenticationContext.Provider
      value={{
        isAuthenticated,
        setIsAuthenticated
      }}
    >
      {children}
    </AuthenticationContext.Provider>
  );
};

export default AuthenticationContextProvider;