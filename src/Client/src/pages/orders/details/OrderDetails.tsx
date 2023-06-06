import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';

import { Badge, Col, Container, Row, Table } from 'react-bootstrap';

import { useThemeHook } from '../../../providers/ThemeProvider';
import errorsService from '../../../services/errorsService';
import ordersService from '../../../services/ordersService';
import routes from '../../../common/routes';

const OrderDetails = (): JSX.Element => {
  const { id } = useParams();

  const [theme] = useThemeHook();
  const [orderData, setOrderData] = useState<any>({});

  useEffect(() => {
    ordersService
      .details(Number(id))
      .subscribe({
        next: value => setOrderData(value.data),
        error: errorsService.handle
      });
  }, [id]);

  const totalPrice = () => {
    const initialValue = 0;
    return orderData.orderedBooks?.reduce(
      (sum: number, item: any) => sum + item.quantity * item.bookPrice,
      initialValue
    );
  };

  return (
    <Container className='py-5'>
      <Row className={`${theme ? 'justify-content-center mt-5 text-light' : 'justify-content-center mt-5 text-black'}`}>
        <Col>
          <h1>Order ID: {orderData.id}</h1>
          <b className={`${theme ? 'text-dark-primary' : 'text-light-primary'} h4 mt-3 d-block`}>
            {new Date(orderData.date).toLocaleString()}
          </b>
          <Badge pill bg='success' className='mt-lg-3 mb-lg-3'>
            Status: {orderData.status}
          </Badge>
          <h4>Total Price: ${totalPrice()?.toFixed(2)}</h4>
          <Table responsive='sm' striped bordered hover variant={theme ? 'dark' : 'light'} className='mb-5 mt-lg-3'>
            <tbody>
            {orderData.orderedBooks?.map((item: any, index: number) => {
              return (
                <tr key={index}>
                  <td>
                    <Link to={routes.bookDetails.getRoute(item.bookId)}>
                      <div style={{
                        background: 'white', height: '8rem', overflow: 'hidden', display: 'flex',
                        justifyContent: 'center', alignItems: 'center'
                      }}>
                        <div style={{ padding: '.5rem' }}>
                          <img src={item.bookImageUrl} style={{ width: '4rem' }} alt={item.bookTitle} />
                        </div>
                      </div>
                    </Link>
                  </td>
                  <td>
                    <h6 style={{
                      whiteSpace: 'nowrap',
                      width: '14rem',
                      overflow: 'hidden'
                    }}>
                      {item.bookTitle}
                    </h6>
                  </td>
                  <td>Quantity ({item.quantity})</td>
                  <td>${item.bookPrice}</td>
                </tr>
              );
            })}
            </tbody>
          </Table>
        </Col>
      </Row>
    </Container>
  );
};

export default OrderDetails;