import React, { useContext } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { useThemeHook } from '../providers/ThemeProvider';
import { AuthenticationContext } from '../providers/AuthenticationContext';
import Header from './Header';
import Home from '../pages/home/Home';
import MyAccount from '../pages/my-account/MyAccount';
import SignIn from '../pages/authentication/SignIn';
import Register from '../pages/authentication/Register';
import BookDetails from '../pages/books/details/BookDetails';
import Cart from '../pages/cart/Cart';
import NotFound from './NotFound';
import ProtectedRoute from './ProtectedRoute';

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