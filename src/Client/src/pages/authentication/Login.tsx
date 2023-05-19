import { useContext, useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Button, Col, Container, Form, InputGroup, Row, Spinner } from 'react-bootstrap';

import { AiOutlineUser } from 'react-icons/ai';
import { VscKey } from 'react-icons/vsc';

import { useThemeHook } from '../../providers/ThemeProvider';
import { AuthenticationContext } from '../../providers/AuthenticationContext';
import usersService from '../../services/usersService';
import errorsService from '../../services/errorsService';
import jwtService from '../../services/jwtService';
import routes from '../../common/routes';

const Login = () => {
  const [loading, setLoading] = useState(false);
  const [theme] = useThemeHook();
  const navigate = useNavigate();
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthenticationContext);

  useEffect(() => {
    if (isAuthenticated) {
      navigate(routes.home.getRoute(), { replace: true });
    }
  }, [isAuthenticated, navigate]);

  const handleSubmit = (event: any) => {
    const form = event.currentTarget;

    event.preventDefault();

    const email = form.email.value;
    const password = form.password.value;
    if (email && password) {
      setLoading(true);
      usersService
        .login({ email, password })
        .subscribe({
          next: res => {
            jwtService.saveToken(res.data.token);
            navigate(routes.home.getRoute(), { replace: true });
            setIsAuthenticated(true);
          },
          error: errorsService.handle
        });
      setLoading(false);
    }
  };

  return (
    <Container className='py-5 mt-5'>
      <Row className='justify-content-center mt-5'>
        <Col xs={11} sm={10} md={8} lg={4}
             className={`p-4 rounded ${theme ? 'text-light bg-dark' : 'text-black bg-light'}`}>
          <h1 className={`text-center border-bottom pb-3 ${theme ? 'text-dark-primary' : 'text-light-primary'}`}>
            Login
          </h1>
          <Form onSubmit={handleSubmit}>
            <InputGroup className='mb-4 mt-5'>
              <InputGroup.Text>
                <AiOutlineUser size='1.8rem' />
              </InputGroup.Text>
              <Form.Control name='email' type='email' placeholder='Email' required />
            </InputGroup>
            <InputGroup className='mb-4'>
              <InputGroup.Text>
                <VscKey size='1.8rem' />
              </InputGroup.Text>
              <Form.Control name='password' type='password' placeholder='Password' minLength={6}
                            required />
            </InputGroup>
            <Button
              type='submit'
              className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} m-auto d-block`}
              disabled={loading}
              style={{ border: 0 }}
            >
              {loading ?
                <>
                  <Spinner
                    as='span'
                    animation='grow'
                    size='sm'
                    role='status'
                    aria-hidden='true'
                  />
                  &nbsp;Loading...
                </> : 'Sign in'
              }
            </Button>
            <Form.Group className='mt-3 text-center'>
              <Form.Text className='text-muted fw-bold'>
                New to BookStore?
              </Form.Text>
              <Row className='py-2 border-bottom mb-3' />
              <Link to={routes.register.getRoute()} className='btn btn-info rounded-0'>
                Create your BookStore account
              </Link>
            </Form.Group>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default Login;