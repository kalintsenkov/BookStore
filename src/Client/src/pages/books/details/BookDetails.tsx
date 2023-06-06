import { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';

import 'react-lightbox-component/build/css/index.css';
import { Button, Col, Container, Row } from 'react-bootstrap';
// @ts-ignore
import Lightbox from 'react-lightbox-component';
import { BsCartPlus } from 'react-icons/bs';

import './book-details.css';
import { useThemeHook } from '../../../providers/ThemeProvider';
import booksService from '../../../services/booksService';
import errorsService from '../../../services/errorsService';
import usersService from '../../../services/usersService';
import shoppingCartsService from '../../../services/shoppingCartsService';
import routes from '../../../common/routes';

const BookDetails = (): JSX.Element => {
  const { id } = useParams();

  const navigate = useNavigate();
  const [theme] = useThemeHook();
  const [bookData, setBookData] = useState<any>({});

  useEffect(() => {
    booksService
      .details(Number(id))
      .subscribe({
        next: value => setBookData(value.data),
        error: errorsService.handle
      });
  }, [id]);

  const addToCart = () => {
    shoppingCartsService
      .addBook({
        bookId: Number(id),
        quantity: 1
      })
      .subscribe({
        next: () => navigate(routes.cart.getRoute()),
        error: errorsService.handle
      });
  };

  const deleteBook = () => {
    booksService
      .delete(Number(id))
      .subscribe({
        next: () => navigate(routes.home.getRoute()),
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
          <Link to={routes.authorDetails.getRoute(bookData.authorId)}>
            <p className='h5'>{bookData.authorName}</p>
          </Link>
          <p className='h5'>4.1 ⭐</p>
          <p className='mt-3 h5' style={{ opacity: '0.8', fontWeight: '400' }}>
            {bookData.genre}
          </p>
          <p className='mt-3 h5' style={{ opacity: '0.8', fontWeight: '400' }}>
            {bookData.description}
          </p>
          {usersService.isAdministrator() ? (
            <>
              <Button
                variant='warning'
                onClick={() => navigate(routes.bookEdit.getRoute(Number(id)))}
                style={{ marginRight: 15 }}
              >
                Edit
              </Button>
              <Button
                variant='danger'
                onClick={() => deleteBook()}
              >
                Delete
              </Button>
            </>
          ) : (
            <></>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default BookDetails;