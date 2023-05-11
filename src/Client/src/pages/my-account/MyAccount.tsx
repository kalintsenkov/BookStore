import { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Col, Container, Image, Nav, Row, Tab } from 'react-bootstrap';
import { FaClipboardList, FaUser } from 'react-icons/fa';
import { IoLocationSharp, IoLogOut } from 'react-icons/io5';

import './my-account.css';
import profilePix from '../../images/profile-picture.png';
import { useThemeHook } from '../../providers/ThemeProvider';
import { AuthenticationContext } from '../../providers/AuthenticationContext';
import Heading from '../../components/Heading';
import usersService from '../../services/usersService';
import apiService from '../../services/apiService';
import errorsService from '../../services/errorsService';
import MyOrders from './MyOrders';
import MyAddress from './MyAddress';
import MyWallet from './MyWallet';
import MyDetails from './MyDetails';

const MyAccount = () => {
  const [theme] = useThemeHook();
  const navigate = useNavigate();
  const { setIsAuthenticated } = useContext(AuthenticationContext);
  const [ordersData, setOrdersData] = useState([]);

  const logout = () => {
    usersService.logout();
    setIsAuthenticated(false);
    navigate('/', { replace: true });
  };

  useEffect(() => {
    apiService
      .get('https://localhost:5001/orders/mine')
      .subscribe({
        next: response => setOrdersData(response.data.models),
        error: errorsService.handle
      });
  }, []);

  return (
    <Container className='py-5 mt-5'>
      <Heading heading='My Account' />
      <Tab.Container defaultActiveKey='my-orders'>
        <Row className='justify-content-evenly mt-4 p-1'>
          <Col sm={3}
               className={`${theme ? 'text-light bg-dark' : 'text-black bg-light'} p-2 rounded h-100 mb-3 user-menu`}>
            <Row className='mb-3 py-2'>
              <Col xs={3} className='pe-0'>
                <Image
                  src={profilePix}
                  thumbnail
                  fluid
                  roundedCircle
                  className='p-0'
                />
              </Col>
              <Col xs={9} className='pt-1'>
                <span>Hello,</span>
                <h4>Name</h4>
              </Col>
            </Row>
            <Nav variant='pills' className='flex-column'>
              <Nav.Item className='mb-3'>
                <Nav.Link eventKey='my-orders'>
                  My Orders
                  <FaClipboardList size='1.4rem' />
                </Nav.Link>
                <Nav.Link eventKey='account-details'>
                  Account Details
                  <FaUser size='1.4rem' />
                </Nav.Link>
                <Nav.Link eventKey='address'>
                  Address
                  <IoLocationSharp size='1.4rem' />
                </Nav.Link>
                <Nav.Link eventKey='logout' onClick={logout}>
                  Logout
                  <IoLogOut size='1.4rem' />
                </Nav.Link>
              </Nav.Item>
            </Nav>
          </Col>
          <Col sm={8} className={`${theme ? 'text-light bg-dark' : 'text-black bg-light'} p-2 rounded`}>
            <Tab.Content>
              <Tab.Pane eventKey='my-orders'>
                <MyOrders orders={ordersData} />
              </Tab.Pane>
              <Tab.Pane eventKey='account-details'>
                <MyDetails />
              </Tab.Pane>
              <Tab.Pane eventKey='address'>
                <MyAddress />
              </Tab.Pane>
              <Tab.Pane eventKey='wallet'>
                <MyWallet />
              </Tab.Pane>
            </Tab.Content>
          </Col>
        </Row>
      </Tab.Container>
    </Container>
  );
};

export default MyAccount;