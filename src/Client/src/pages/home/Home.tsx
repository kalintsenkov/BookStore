import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { BiSearch } from 'react-icons/bi';
import { Col, Container, FormControl, InputGroup, Row } from 'react-bootstrap';

import { useThemeHook } from '../../providers/ThemeProvider';
import BookCard from '../../components/BookCard';
import Pagination from '../../components/Pagination';
import booksService from '../../services/booksService';
import errorsService from '../../services/errorsService';
import routes from '../../common/routes';

const Home = () => {
  const { page } = useParams();
  const navigate = useNavigate();
  const [theme] = useThemeHook();
  const [searchInput, setSearchInput] = useState<string>('');
  const [booksSearchData, setBooksSearchData] = useState<any>({});

  useEffect(() => {
    booksService
      .search(Number(page ?? 1), searchInput)
      .subscribe({
        next: value => setBooksSearchData(value.data),
        error: errorsService.handle
      });
  }, [page, searchInput]);

  const changePage = (page: number) => {
    navigate(routes.home.getRoute(page));
  };

  return (
    <Container className='py-4'>
      <Row className='justify-content-center'>
        <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto text-center'>
          <h1 className={theme ? 'text-light my-5' : 'text-black my-5'}>Search books</h1>
          <InputGroup className='mb-3'>
            <InputGroup.Text
              className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
              <BiSearch size='2rem' />
            </InputGroup.Text>
            <FormControl
              placeholder='Search'
              value={searchInput}
              onChange={(e) => setSearchInput(e.target.value)}
              className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
            />
          </InputGroup>
        </Col>
        <Row className='justify-content-center'>
          {booksSearchData.models?.map((item: any, i: number) => (
            <BookCard data={item} key={i} />
          ))}
        </Row>
      </Row>
      <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto'>
        <Pagination page={booksSearchData.page}
                    totalPages={booksSearchData.totalPages}
                    onPageSelected={changePage} />
      </Col>
    </Container>
  );
};

export default Home;