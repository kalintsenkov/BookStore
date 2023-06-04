import React from 'react';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import Router from './Router';
import { ThemeProvider } from '../providers/ThemeProvider';
import ContextWrapper from '../providers/AuthenticationContext';

const App = (): JSX.Element => {
  return (
    <ContextWrapper>
      <ThemeProvider>
        <ToastContainer />
        <Router />
      </ThemeProvider>
    </ContextWrapper>
  );
};

export default App;
