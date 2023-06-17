import React from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { Button, Col, Container, Row } from 'react-bootstrap';
import { FaCheck } from 'react-icons/fa';

import routes from '../../../common/routes';
import { useThemeHook } from '../../../providers/ThemeProvider';

const OrderSuccess = (): JSX.Element => {
  const { id } = useParams();

  const [theme] = useThemeHook();
  const navigate = useNavigate();

  return (
    <Container className='py-5'>
      <Row>
        <Col className='p-5 text-center'>
          <div className='d-flex justify-content-center mb-5 flex-column align-items-center'>
            <h3 className='bg-success text-light align-items-center' style={{ width: '3%', borderRadius: '50%' }}>
              <FaCheck className='text-light' size='1.3rem' />
            </h3>
            <h3 className={`font-weight-bold ${theme ? 'text-light' : 'text-black'}`}>
              Order Confirmed
            </h3>
            <h5 className={`mt-2 ${theme ? 'text-light' : 'text-black'}`}>
              Thank you for your shopping
            </h5>
          </div>
          <Button
            // onClick={() => printInvoice())}
            style={{ border: 0, marginRight: 15 }}
            className={theme ? 'bg-dark-primary text-black' : 'bg-light-primary'}
          >
            Print invoice
          </Button>
          <Button
            onClick={() => navigate(routes.orderDetails.getRoute(Number(id)))}
            style={{ border: 0 }}
            className={theme ? 'bg-dark-primary text-black' : 'bg-light-primary'}
          >
            Go to your order
          </Button>
        </Col>
      </Row>
    </Container>
  );
};

export default OrderSuccess;