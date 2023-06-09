import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Button, Container, Row } from 'react-bootstrap';

import { useThemeHook } from '../../providers/ThemeProvider';
import BookCard from '../../components/BookCard';
import booksService from '../../services/booksService';
import errorsService from '../../services/errorsService';
import routes from '../../common/routes';

const Home = (): JSX.Element => {
  const [theme] = useThemeHook();
  const [booksSearchData, setBooksSearchData] = useState<any>({});

  useEffect(() => {
    booksService
      .search()
      .subscribe({
        next: value => setBooksSearchData(value.data),
        error: errorsService.handle
      });
  }, []);

  return (
    <Container className='py-4'>
      <Row className='justify-content-center mb-3 mx-auto text-center'>
        <h1 className={theme ? 'text-light my-5' : 'text-black my-5'}>Hot New Releases</h1>
        {booksSearchData.models?.map((item: any, i: number) => (
          <BookCard data={item} key={i} />
        ))}
        <Link to={routes.booksSearch.getRoute()}>
          <Button
            className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} mt-3 border-0`}
          >
            View all books
          </Button>
        </Link>
      </Row>
    </Container>
  );
};

export default Home;