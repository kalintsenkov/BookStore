import React from 'react';
import { renderToString } from 'react-dom/server';
import { useNavigate, useParams } from 'react-router-dom';

import JsPDF from 'jspdf';
import { Button, Col, Container, Row } from 'react-bootstrap';
import { FaCheckCircle } from 'react-icons/fa';

import Invoice from '../../../components/Invoice';
import routes from '../../../common/routes';
import useTheme from '../../../hooks/useTheme';
import ordersService from '../../../services/ordersService';
import errorsService from '../../../services/errorsService';

const OrderSuccess = (): JSX.Element => {
  const { id } = useParams();

  const { theme } = useTheme();
  const navigate = useNavigate();

  const saveInvoice = () => {
    ordersService
      .details(Number(id))
      .subscribe({
        next: value => {
          const doc = new JsPDF('portrait', 'pt', 'letter');

          doc
            .html(
              renderToString(
                <Invoice
                  id={value.data.id}
                  date={new Date(value.data.date).toLocaleString()}
                  customerName={value.data.customerName}
                  orderedBooks={value.data.orderedBooks}
                />
              )
            )
            .then(() => doc.save(`invoice-${new Date(value.data.date).toLocaleString()}.pdf`));
        },
        error: errorsService.handle
      });
  };

  return (
    <Container className='py-5'>
      <Row>
        <Col className='p-5 text-center'>
          <div className='d-flex justify-content-center mb-5 flex-column align-items-center'>
            <h3 className='align-items-center'>
              <FaCheckCircle className='text-success' size='2rem' />
            </h3>
            <h3 className={`font-weight-bold ${theme ? 'text-light' : 'text-black'}`}>
              Order Confirmed
            </h3>
            <h5 className={`mt-2 ${theme ? 'text-light' : 'text-black'}`}>
              Thank you for your shopping
            </h5>
          </div>
          <Button
            onClick={saveInvoice}
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