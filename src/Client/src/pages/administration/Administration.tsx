import React from 'react';
import { Link } from 'react-router-dom';

import { Card, Col, Container, Row } from 'react-bootstrap';

import { useThemeHook } from '../../providers/ThemeProvider';
import routes from '../../common/routes';
import { BiEdit } from 'react-icons/bi';

const Administration = (): JSX.Element => {
  const [theme] = useThemeHook();

  return (
    <Container className='py-5 mt-5'>
      <Row className='justify-content-center mt-5 text-center'>
        <h1 className={theme ? 'text-light mb-5' : 'text-black mb-5'}>Administration</h1>
        <Col>
          <Link to={routes.ordersSearch.getRoute()} className='nav-link'>
            <Card className={`${theme ? 'bg-light-black text-light' : 'bg-light text-black'} mb-3`}
                  border={theme ? 'warning' : 'primary'}>
              <Card.Header>
                <BiEdit size='2rem' />
                &nbsp;Orders
              </Card.Header>
            </Card>
          </Link>
        </Col>
        <Col>
          <Link to={routes.authorsSearch.getRoute()} className='nav-link'>
            <Card className={`${theme ? 'bg-light-black text-light' : 'bg-light text-black'} mb-3`}
                  border={theme ? 'warning' : 'primary'}>
              <Card.Header>
                <BiEdit size='2rem' />
                &nbsp;Authors
              </Card.Header>
            </Card>
          </Link>
        </Col>
      </Row>
    </Container>
  );
};

export default Administration;