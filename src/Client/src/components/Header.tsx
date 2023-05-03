import { useContext, useEffect, useState } from 'react';
import { Container, Nav, Navbar } from 'react-bootstrap';
import { ThemeContext } from '../providers/ThemeProvider';
import { BiCart, BiMoon, BiSun } from 'react-icons/bi';
import { VscAccount } from 'react-icons/vsc';
import { Link } from 'react-router-dom';
import { AuthenticationContext } from '../providers/AuthenticationContext';

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
        <Link to='/'>
          <Navbar.Brand className={darkMode ? 'text-dark-primary' : 'text-light-primary'}>
            <b>BookStore</b>
          </Navbar.Brand>
        </Link>
        <Navbar.Toggle aria-controls='basic-navbar-nav' />
        <Navbar.Collapse id='basic-navbar-nav'>
          <Nav className='ms-auto'>
            {!isAuthenticated ? (
              <Link to='sign-in'
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
              {darkMode ? <BiSun size='1.7rem' /> : <BiMoon size='1.7rem' />}
            </Nav.Link>
            {isAuthenticated ? (
              <Link
                to='/cart'
                className={`${darkMode ? 'text-dark-primary' : 'text-light-primary'} d-flex align-items-center`}
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
              <Link to='my-account'
                    className={`nav-link ${darkMode ? 'text-dark-primary' : 'text-light-primary'}`}>
                <VscAccount size='1.8rem' />
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