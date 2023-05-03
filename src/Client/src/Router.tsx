import React, { useContext } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { useThemeHook } from './providers/ThemeProvider';
import Header from './components/Header';
import Home from './pages/Home';
import MyAccount from './pages/MyAccount';
import SignIn from './pages/SignIn';
import Register from './pages/Register';
import BookDetails from './pages/BookDetails';
import Cart from './pages/Cart';
import NotFound from './components/NotFound';
import ProtectedRoute from './components/ProtectedRoute';
import { AuthenticationContext } from './providers/AuthenticationContext';

const AppRouter = (): JSX.Element => {
  const [theme] = useThemeHook();
  const { isAuthenticated } = useContext(AuthenticationContext);

  return (
    <Router>
      <main className={theme ? 'bg-black' : 'bg-light-2'} style={{ height: '100vh', overflowY: 'auto' }}>
        <Header />
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/sign-in' element={<SignIn />} />
          <Route path='/register' element={<Register />} />
          <Route path='/book/:id' element={<BookDetails />} />
          <Route
            path='/cart'
            element={
              <ProtectedRoute isAllowed={isAuthenticated}>
                <Cart />
              </ProtectedRoute>
            }
          />
          <Route
            path='/my-account'
            element={
              <ProtectedRoute isAllowed={isAuthenticated}>
                <MyAccount />
              </ProtectedRoute>
            }
          />
          <Route path='*' element={<NotFound />} />
        </Routes>
      </main>
    </Router>
  );
};

export default AppRouter;