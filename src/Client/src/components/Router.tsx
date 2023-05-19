import React, { useContext } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { useThemeHook } from '../providers/ThemeProvider';
import { AuthenticationContext } from '../providers/AuthenticationContext';
import routes from '../common/routes';
import Header from './Header';
import Home from '../pages/home/Home';
import MyAccount from '../pages/my-account/MyAccount';
import Login from '../pages/authentication/Login';
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
          <Route path={routes.home.path} element={<Home />} />
          <Route path={routes.login.path} element={<Login />} />
          <Route path={routes.register.path} element={<Register />} />
          <Route path={routes.bookDetails.path} element={<BookDetails />} />
          <Route
            path={routes.cart.path}
            element={
              <ProtectedRoute isAllowed={isAuthenticated}>
                <Cart />
              </ProtectedRoute>
            }
          />
          <Route
            path={routes.myAccount.path}
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