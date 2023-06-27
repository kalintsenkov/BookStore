import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { Button, Col, Container, Form, FormControl, FormLabel, InputGroup, Row } from 'react-bootstrap';
import { BiSearch } from 'react-icons/bi';

import BookCard from '../../../components/BookCard';
import Pagination from '../../../components/Pagination';
import booksService from '../../../services/booksService';
import errorsService from '../../../services/errorsService';
import routes from '../../../common/routes';
import { Genre } from '../../../models/Genre';
import useTheme from '../../../hooks/useTheme';

const BooksList = (): JSX.Element => {
  const { title, genre, author, page } = useParams();
  const navigate = useNavigate();
  const { theme } = useTheme();
  const [booksSearchData, setBooksSearchData] = useState<any>({});
  const [searchTerms, setSearchTerms] = useState<{ [key: string]: string }>({});

  const updateData = (e: any) => {
    setSearchTerms({
      ...searchTerms,
      [e.target.name]: e.target.value
    });
  };

  useEffect(() => {
    const urlParams: any = { title: title, genre: genre, author: author };
    const params = new URLSearchParams();

    for (const key in urlParams) {
      if (!urlParams[key]) {
        continue;
      }

      params.append(key, urlParams[key]);
    }

    const pageNumber = Number(page ?? 1);
    const searchTermsQuery = params.toString();

    booksService
      .search(pageNumber, searchTermsQuery)
      .subscribe({
        next: value => setBooksSearchData(value.data),
        error: errorsService.handle
      });
  }, [title, genre, author, page]);

  const changePage = (page?: number) => {
    if (searchTerms.title && searchTerms.genre && searchTerms.author) {
      navigate(routes.booksByTitleGenreAndAuthorSearch.getRoute(searchTerms.title, searchTerms.genre, searchTerms.author, page));
    } else if (searchTerms.title && searchTerms.genre) {
      navigate(routes.booksByTitleAndGenreSearch.getRoute(searchTerms.title, searchTerms.genre, page));
    } else if (searchTerms.title && searchTerms.author) {
      navigate(routes.booksByTitleAndAuthorSearch.getRoute(searchTerms.title, searchTerms.author, page));
    } else if (searchTerms.genre && searchTerms.author) {
      navigate(routes.booksByGenreAndAuthorSearch.getRoute(searchTerms.genre, searchTerms.author, page));
    } else if (searchTerms.title) {
      navigate(routes.booksByTitleSearch.getRoute(searchTerms.title, page));
    } else if (searchTerms.genre) {
      navigate(routes.booksByGenreSearch.getRoute(searchTerms.genre, page));
    } else if (searchTerms.author) {
      navigate(routes.booksByAuthorSearch.getRoute(searchTerms.author, page));
    } else {
      navigate(routes.booksSearch.getRoute(page));
    }
  };

  const handleSearch = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    changePage();
  };

  return (
    <Container style={{ paddingTop: '6rem' }}>
      <Row>
        <Col lg={3}>
          <Form onSubmit={handleSearch}>
            <FormLabel
              htmlFor='title'
              className={theme ? 'text-dark-primary' : 'text-light-primary'}>
              Title:
            </FormLabel>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                id='title'
                name='title'
                placeholder='Search by title'
                defaultValue={title}
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <FormLabel
              htmlFor='author'
              className={theme ? 'text-dark-primary' : 'text-light-primary'}>
              Author:
            </FormLabel>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                id='author'
                name='author'
                placeholder='Search by author'
                defaultValue={author}
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              />
            </InputGroup>
            <FormLabel
              htmlFor='genre'
              className={theme ? 'text-dark-primary' : 'text-light-primary'}>
              Genre:
            </FormLabel>
            <InputGroup className='mb-3'>
              <InputGroup.Text
                className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
                <BiSearch size='2rem' />
              </InputGroup.Text>
              <FormControl
                id='genre'
                name='genre'
                as='select'
                defaultValue={genre}
                className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
                onChange={updateData}
              >
                <option value='' disabled selected hidden></option>
                {Genre.values.map((genre, index) => {
                  return <option key={index} value={genre.value}>{genre.name}</option>;
                })}
              </FormControl>
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
            {booksSearchData.models?.length !== 0 ? (
              booksSearchData.models?.map((item: any, i: number) => (<BookCard data={item} key={i} />))
            ) : (
              <h2 className={theme ? 'text-light' : 'text-black'}>Nothing found!</h2>
            )}
          </Row>
          <Pagination
            page={booksSearchData?.page}
            totalPages={booksSearchData?.totalPages}
            onPageSelected={changePage}
          />
        </Col>
      </Row>
    </Container>
  );
};

export default BooksList;