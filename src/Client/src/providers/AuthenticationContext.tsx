import React, { createContext, useState } from 'react';

import usersService from '../services/usersService';

interface IAuthenticationContextProps {
  children?: React.ReactNode;
}

export const AuthenticationContext = createContext({
  isAuthenticated: usersService.isAuthenticated(),
  setIsAuthenticated: (isAuthenticated: boolean) => {}
  // customerId: 0,
  // setCustomerId: (customerId: number) => {}
});

const ContextWrapper = ({ children }: IAuthenticationContextProps): JSX.Element => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(usersService.isAuthenticated());
  // const [customerId, setCustomerId] = useState<number>(
  //   customerService.getIdFromLocalStorage() ? Number(customerService.getIdFromLocalStorage()) : 0
  // );

  return (
    <AuthenticationContext.Provider
      value={{
        isAuthenticated,
        setIsAuthenticated
        // customerId,
        // setCustomerId
      }}
    >
      {children}
    </AuthenticationContext.Provider>
  );
};

export default ContextWrapper;