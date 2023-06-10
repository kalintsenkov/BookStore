import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { Button, Col, Container, Form, FormControl, InputGroup, Row } from 'react-bootstrap';
import { BiSearch } from 'react-icons/bi';

import { useThemeHook } from '../../../providers/ThemeProvider';
import BookCard from '../../../components/BookCard';
import Pagination from '../../../components/Pagination';
import booksService from '../../../services/booksService';
import errorsService from '../../../services/errorsService';
import routes from '../../../common/routes';
import { Genre } from '../../../models/Genre';

const BooksList = (): JSX.Element => {
  const { page } = useParams();
  const navigate = useNavigate();
  const [theme] = useThemeHook();
  const [booksSearchData, setBooksSearchData] = useState<any>({});
  const [searchTerms, setSearchTerms] = useState<{ [key: string]: string }>({});

  const updateData = (e: any) => {
    setSearchTerms({
      ...searchTerms,
      [e.target.name]: e.target.value
    });
  };

  useEffect(() => {
    booksService
      .search(Number(page ?? 1), '')
      .subscribe({
        next: value => setBooksSearchData(value.data),
        error: errorsService.handle
      });
  }, [page]);

  const changePage = (page: number) => {
    navigate(routes.booksSearch.getRoute(page));
  };

  const handleSearch = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const params = new URLSearchParams();

    for (const key in searchTerms) {
      if (!searchTerms[key]) {
        continue;
      }

      params.append(key, searchTerms[key]);
    }

    const pageNumber = Number(page ?? 1);
    const searchTermsQuery = params.toString();

    booksService
      .search(pageNumber, searchTermsQuery)
      .subscribe({
        next: value => setBooksSearchData(value.data),
        error: errorsService.handle
      });
  };

  return (
    <Container style={{ paddingTop: '6rem' }}>
      <Row>
        <Col lg={3}>
          <Form onSubmit={handleSearch}>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                placeholder='Search by title'
                name='title'
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                placeholder='Search by author'
                name='author'
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                placeholder='Search by genre'
                name='genre'
                as='select'
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              >
                <option value='' disabled selected hidden>Search by genre</option>
                {Genre.values.map((genre, index) => {
                  return <option key={index} value={genre.value}>{genre.name}</option>;
                })}
              </FormControl>
            </InputGroup>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                placeholder='Search by min price'
                type='number'
                name='minPrice'
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                placeholder='Search by max price'
                type='number'
                name='maxPrice'
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <Button
              type='submit'
              className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} border-0`}
            >
              Search
            </Button>
          </Form>
        </Col>
        <Col lg={8}>
          <Row>
            {booksSearchData.models?.map((item: any, i: number) => (
              <BookCard data={item} key={i} />
            ))}
          </Row>
          <Pagination
            page={booksSearchData.page}
            totalPages={booksSearchData.totalPages}
            onPageSelected={changePage}
          />
        </Col>
      </Row>
    </Container>
  );
};

export default BooksList;