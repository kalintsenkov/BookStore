import { useContext, useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row, Spinner } from 'react-bootstrap';
import { useThemeHook } from '../../providers/ThemeProvider';
import 'react-phone-input-2/lib/high-res.css';
import { useNavigate } from 'react-router-dom';
import usersService from '../../services/usersService';
import errorsService from '../../services/errorsService';
import { AuthenticationContext } from '../../providers/AuthenticationContext';
import jwtService from '../../services/jwtService';

const Register = () => {
  const [loading, setLoading] = useState(false);
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthenticationContext);
  // const [number, setNumber] = useState(null);
  const navigate = useNavigate();
  const [theme] = useThemeHook();

  useEffect(() => {
    if (isAuthenticated) {
      navigate('/', { replace: true });
    }
  }, [isAuthenticated, navigate]);

  const handleSubmit = (event) => {
    const form = event.currentTarget;

    event.preventDefault();

    const firstName = form.firstName.value;
    const lastName = form.lastName.value;
    const email = form.email.value;
    const password = form.password.value;
    const confirmPassword = form.confirmPassword.value;

    if (firstName && lastName && email && password && confirmPassword) {
      setLoading(true);
      usersService
        .register({
          fullName: firstName.trim() + ' ' + lastName.trim(),
          email: email,
          password: password,
          confirmPassword: confirmPassword
        })
        .subscribe({
          next: res => {
            jwtService.saveToken(res.data.token);
            navigate('/', { replace: true });
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
            Create Account
          </h1>
          <Form onSubmit={handleSubmit}>
            <Row>
              <Form.Group className='mb-3 col-lg-6'>
                <Form.Label>First name</Form.Label>
                <Form.Control name='firstName' type='text' placeholder='First name' required />
              </Form.Group>
              <Form.Group className='mb-3 col-lg-6'>
                <Form.Label>Last name</Form.Label>
                <Form.Control name='lastName' type='text' placeholder='Last name' required />
              </Form.Group>
            </Row>
            <Form.Group className='mb-3'>
              <Form.Label>Email</Form.Label>
              <Form.Control name='email' type='email' placeholder='Email' required />
            </Form.Group>
            {/*<Form.Group className="mb-3">*/}
            {/*    <Form.Label>Mobile number</Form.Label>*/}
            {/*    <PhoneInput*/}
            {/*        country={'in'}*/}
            {/*        value={number}*/}
            {/*        onChange={phone=> setNumber(phone)}*/}
            {/*        className="text-dark"*/}
            {/*    />*/}
            {/*</Form.Group>*/}
            <Form.Group className='mb-3'>
              <Form.Label>Password</Form.Label>
              <Form.Control name='password' type='password' placeholder='Password' minLength={6}
                            required />
            </Form.Group>
            <Form.Group className='mb-3'>
              <Form.Label>Confirm Password</Form.Label>
              <Form.Control name='confirmPassword' type='password' placeholder='Confirm Password'
                            minLength={6} required />
            </Form.Group>
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
                </> : 'Continue'
              }
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default Register;