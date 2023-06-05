import { useContext, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import { Container, Nav, Navbar } from 'react-bootstrap';

import { VscAccount } from 'react-icons/vsc';
import { BiCart, BiMoon, BiSun } from 'react-icons/bi';

import { ThemeContext } from '../providers/ThemeProvider';
import { AuthenticationContext } from '../providers/AuthenticationContext';
import routes from '../common/routes';
import usersService from '../services/usersService';

const Header = () => {
  const [theme, setTheme] = useContext(ThemeContext);
  const [darkMode, setDarkMode] = useState(theme);
  const { isAuthenticated } = useContext(AuthenticationContext);

  useEffect(() => {
    setTheme(darkMode);
  }, [darkMode, setTheme]);

  return (
    <Navbar collapseOnSelect expand='md'
            variant={darkMode ? 'dark' : 'light'}
            className={darkMode ? 'bg-light-black border-bottom' : 'bg-light border-bottom'}
            style={{ width: '100%', position: 'fixed', zIndex: 100 }}
    >
      <Container>
        <Link to={routes.home.getRoute()}
              className='nav-link'>
          <Navbar.Brand className={darkMode ? 'text-dark-primary' : 'text-light-primary'}>
            <b>BookStore</b>
          </Navbar.Brand>
        </Link>
        <Navbar.Toggle aria-controls='basic-navbar-nav' />
        <Navbar.Collapse id='basic-navbar-nav'>
          <Nav className='ms-auto'>
            {!isAuthenticated ? (
              <Link to={routes.login.getRoute()}
                    className={`nav-link ${darkMode ? 'text-dark-primary' : 'text-light-primary'}`}>
                Sign in
              </Link>
            ) : (
              <></>
            )}
            <Nav.Link
              className={darkMode ? 'text-dark-primary' : 'text-light-primary'}
              onClick={() => setDarkMode(!darkMode)}
            >
              {darkMode ? <BiSun size='2rem' /> : <BiMoon size='2rem' />}
            </Nav.Link>
            {usersService.isAdministrator() ? (
              <Link
                to={routes.ordersSearch.getRoute()}
                className={`${darkMode ? 'text-dark-primary' : 'text-light-primary'} nav-link d-flex align-items-center`}
              >
                <BiCart size='2rem' />
                <span>&nbsp;Orders</span>
              </Link>
            ) : (
              <></>
            )}
            {isAuthenticated ? (
              <Link
                to={routes.cart.getRoute()}
                className={`${darkMode ? 'text-dark-primary' : 'text-light-primary'} nav-link d-flex align-items-center`}
              >
                <BiCart size='2rem' />
                {/*{!isEmpty &&*/}
                {/*  <span*/}
                {/*    style={{ position: 'relative', left: '-21px', top: '-18px' }}>{totalItems}</span>}*/}
                <span>&nbsp;Cart</span>
              </Link>
            ) : (
              <></>
            )}
            {isAuthenticated ? (
              <Link to={routes.myAccount.getRoute()}
                    className={`nav-link ${darkMode ? 'text-dark-primary' : 'text-light-primary'}`}>
                <VscAccount size='2rem' />
                &nbsp;My Account
              </Link>
            ) : (
              <></>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Header;