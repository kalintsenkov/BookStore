import React from 'react';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import Router from './Router';
import AuthenticationContextProvider from '../providers/AuthenticationContextProvider';
import ThemeContextProvider from '../providers/ThemeContextProvider';

const App = (): JSX.Element => {
  return (
    <AuthenticationContextProvider>
      <ThemeContextProvider>
        <ToastContainer />
        <Router />
      </ThemeContextProvider>
    </AuthenticationContextProvider>
  );
};

export default App;
