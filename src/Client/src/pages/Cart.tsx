import { useEffect, useState } from 'react';
import { Button, Col, Container, Row, Table } from 'react-bootstrap';
import { useThemeHook } from '../providers/ThemeProvider';
import apiService from '../services/apiService';
import errorsService from '../services/errorsService';

const Cart = () => {
  const [theme] = useThemeHook();
  const [booksData, setBooksData] = useState([]);

  const getResponse = () => {
    apiService
      .get('https://localhost:5001/shoppingCarts/mine')
      .subscribe({
        next: value => setBooksData(value.data),
        error: errorsService.handle
      });
  };

  useEffect(() => {
    getResponse();
  }, []);

  const editQuantity = async (bookId, quantity) => {
    apiService
      .put('https://localhost:5001/shoppingCarts/editQuantity', {
        bookId,
        quantity
      })
      .subscribe({
        next: () => getResponse(),
        error: errorsService.handle
      });
  };

  const removeBook = async (bookId) => {
    apiService
      .delete('https://localhost:5001/shoppingCarts/removeBook', {
        data: {
          bookId
        }
      })
      .subscribe({
        next: () => getResponse(),
        error: errorsService.handle
      });
  };

  const totalPrice = () => {
    const initialValue = 0;
    return booksData.reduce(
      (sum, item) => sum + item.quantity * item.bookPrice,
      initialValue
    );
  };

  return (
    <Container className='py-4 mt-5'>
      <h1 className={`${theme ? 'text-light' : 'text-light-primary'} my-5 text-center`}>
        {booksData.length === 0 ? 'Your Cart is Empty' : 'The Cart'}
      </h1>
      <Row className='justify-content-center'>
        <Table responsive='sm' striped bordered hover variant={theme ? 'dark' : 'light'} className='mb-5'>
          <tbody>
          {booksData.map((item, index) => {
            return (
              <tr key={index}>
                <td>
                  <div style={{
                    background: 'white', height: '8rem', overflow: 'hidden', display: 'flex',
                    justifyContent: 'center', alignItems: 'center'
                  }}>
                    <div style={{ padding: '.5rem' }}>
                      <img src={item.bookImageUrl} style={{ width: '4rem' }} alt={item.bookTitle} />
                    </div>
                  </div>
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
                <td>${item.bookPrice}</td>
                <td>Quantity ({item.quantity})</td>
                <td>
                  <Button onClick={() => editQuantity(item.bookId, item.quantity - 1)}
                          className='ms-2'>-</Button>
                  <Button onClick={() => editQuantity(item.bookId, item.quantity + 1)}
                          className='ms-2'>+</Button>
                  <Button variant='danger' onClick={() => removeBook(item.bookId)} className='ms-2'>
                    Remove Item
                  </Button>
                </td>
              </tr>
            );
          })}
          </tbody>
        </Table>
        {booksData.length !== 0 &&
          <Row
            style={{ position: 'fixed', bottom: 0 }}
            className={`${theme ? 'bg-light-black text-light' : 'bg-light text-balck'} justify-content-center w-100`}
          >
            <Col className='py-2'>
              <h4>Total Price: ${totalPrice().toFixed(2)}</h4>
            </Col>
          </Row>}
      </Row>
    </Container>
  );
};

export default Cart;