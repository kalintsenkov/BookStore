import { useEffect, useState } from 'react';
import { Button, Col, Container, Row } from 'react-bootstrap';
import { useThemeHook } from '../../../providers/ThemeProvider';
import Lightbox from 'react-lightbox-component';
import 'react-lightbox-component/build/css/index.css';
import './book-details.css';
import { BsCartPlus } from 'react-icons/bs';
import { useNavigate, useParams } from 'react-router-dom';
import apiService from '../../../services/apiService';
import errorsService from '../../../services/errorsService';

const BookDetails = (): JSX.Element => {
  const { id } = useParams();

  const navigate = useNavigate();
  const [theme] = useThemeHook();
  const [bookData, setBookData] = useState<any>({});

  useEffect(() => {
    apiService
      .get(`https://localhost:5001/books/${id}`)
      .subscribe({
        next: value => setBookData(value.data),
        error: errorsService.handle
      });
  }, [id]);

  const addToCart = () => {
    apiService
      .post('https://localhost:5001/shoppingCarts/addBook', {
        bookId: id,
        quantity: 1
      })
      .subscribe({
        next: () => navigate('/cart'),
        error: errorsService.handle
      });
  };

  return (
    <Container className='py-5'>
      <Row className='justify-content-center mt-5'>
        <Col xs={10} md={7} lg={5} className='p-0'>
          <Lightbox
            images={[
              {
                src: bookData.imageUrl,
                title: bookData.title,
                description: 'Cover'
              }
            ]}
          />
        </Col>
        <Col xs={10} md={7} lg={7} className={`${theme ? 'text-light' : 'text-black'} product-details`}>
          <h1>{bookData.title}</h1>
          <Button
            onClick={() => addToCart()}
            disabled={!bookData.isAvailable}
            className={theme ? 'bg-dark-primary text-black' : 'bg-light-primary'}
            style={{ borderRadius: '0', border: 0 }}
          >
            <BsCartPlus size='1.8rem' />
            {bookData.isAvailable ? 'Add to cart' : 'Out of stock'}
          </Button>
          <br />
          <b className={`${theme ? 'text-dark-primary' : 'text-light-primary'} h4 mt-3 d-block`}>
            ${bookData.price}
          </b>
          <br />
          <b className='h5'>4.1 ⭐</b>
          <p className='mt-3 h5' style={{ opacity: '0.8', fontWeight: '400' }}>
            {bookData.genre}
          </p>
          <p className='mt-3 h5' style={{ opacity: '0.8', fontWeight: '400' }}>
            {bookData.description}
          </p>
        </Col>
      </Row>
    </Container>
  );
};

export default BookDetails;