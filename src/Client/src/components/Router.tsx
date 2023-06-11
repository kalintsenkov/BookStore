import React, { useContext } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { useThemeHook } from '../providers/ThemeProvider';
import { AuthenticationContext } from '../providers/AuthenticationContext';
import routes from '../common/routes';
import Header from './Header';
import Home from '../pages/home/Home';
import Administration from '../pages/administration/Administration';
import Login from '../pages/authentication/Login';
import Register from '../pages/authentication/Register';
import AuthorsSearch from '../pages/authors/search/AuthorsSearch';
import AuthorDetails from '../pages/authors/details/AuthorDetails';
import BooksList from '../pages/books/list/BooksList';
import BookDetails from '../pages/books/details/BookDetails';
import BookEdit from '../pages/books/edit/BookEdit';
import BookCreate from '../pages/books/create/BookCreate';
import OrderDetails from '../pages/orders/details/OrderDetails';
import OrdersSearch from '../pages/orders/search/OrdersSearch';
import Cart from '../pages/cart/Cart';
import MyAccount from '../pages/my-account/MyAccount';
import NotFound from '../pages/not-found/NotFound';
import ProtectedRoute from './ProtectedRoute';
import usersService from '../services/usersService';

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
          <Route path={routes.authorsSearch.path} element={<AuthorsSearch />} />
          <Route path={routes.authorDetails.path} element={<AuthorDetails />} />
          {[
            routes.booksSearch.path,
            routes.booksByTitleSearch.path,
            routes.booksByGenreSearch.path,
            routes.booksByAuthorSearch.path,
            routes.booksByTitleAndGenreSearch.path,
            routes.booksByGenreAndAuthorSearch.path,
            routes.booksByTitleAndAuthorSearch.path,
            routes.booksByTitleGenreAndAuthorSearch.path
          ].map((path, index) =>
            <Route path={path} element={<BooksList />} key={index} />
          )}
          <Route path={routes.bookDetails.path} element={<BookDetails />} />
          <Route
            path={routes.bookEdit.path}
            element={
              <ProtectedRoute isAllowed={usersService.isAdministrator()}>
                <BookEdit />
              </ProtectedRoute>
            }
          />
          <Route
            path={routes.bookCreate.path}
            element={
              <ProtectedRoute isAllowed={usersService.isAdministrator()}>
                <BookCreate />
              </ProtectedRoute>
            }
          />
          <Route
            path={routes.ordersSearch.path}
            element={
              <ProtectedRoute isAllowed={usersService.isAdministrator()}>
                <OrdersSearch />
              </ProtectedRoute>
            }
          />
          <Route
            path={routes.orderDetails.path}
            element={
              <ProtectedRoute isAllowed={isAuthenticated || usersService.isAdministrator()}>
                <OrderDetails />
              </ProtectedRoute>
            }
          />
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
          <Route
            path={routes.administration.path}
            element={
              <ProtectedRoute isAllowed={usersService.isAdministrator()}>
                <Administration />
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