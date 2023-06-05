import { useEffect, useState } from 'react';
import { Col, Container, FormControl, InputGroup, Row } from 'react-bootstrap';

import { BiSearch } from 'react-icons/bi';

import { useThemeHook } from '../../providers/ThemeProvider';
import BookCard from '../../components/BookCard';
import apiService from '../../services/apiService';
import errorsService from '../../services/errorsService';

const Home = () => {
  const [theme] = useThemeHook();
  const [searchInput, setSearchInput] = useState<string>('');
  const [booksData, setBooksData] = useState<any[]>([]);

  useEffect(() => {
    apiService
      .get(`https://localhost:5001/books?title=${searchInput}`)
      .subscribe({
        next: value => setBooksData(value.data.models),
        error: errorsService.handle
      });
  }, [searchInput]);

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
          {booksData.map((item: any, i: number) => (
            <BookCard data={item} key={i} />
          ))}
        </Row>
      </Row>
    </Container>
  );
};

export default Home;