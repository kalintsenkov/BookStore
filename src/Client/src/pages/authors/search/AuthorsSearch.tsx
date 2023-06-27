import React, { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';

import { BiSearch } from 'react-icons/bi';
import { Col, Container, FormControl, InputGroup, Row, Table } from 'react-bootstrap';

import authorsService from '../../../services/authorsService';
import errorsService from '../../../services/errorsService';
import Pagination from '../../../components/Pagination';
import routes from '../../../common/routes';
import useTheme from '../../../hooks/useTheme';

const AuthorsSearch = (): JSX.Element => {
  const { page } = useParams();
  const navigate = useNavigate();
  const { theme } = useTheme();
  const [searchInput, setSearchInput] = useState<string>('');
  const [authorsSearchData, setAuthorsSearchData] = useState<any>({});

  useEffect(() => {
    authorsService
      .search(Number(page ?? 1), searchInput)
      .subscribe({
        next: value => setAuthorsSearchData(value.data),
        error: errorsService.handle
      });
  }, [page, searchInput]);

  const changePage = (page: number) => {
    navigate(routes.authorsSearch.getRoute(page));
  };

  return (
    <Container className='py-5'>
      <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto text-center'>
        <h1 className={theme ? 'text-light my-5' : 'text-black my-5'}>Search authors</h1>
        <InputGroup className='mb-3'>
          <InputGroup.Text className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
            <BiSearch size='2rem' />
          </InputGroup.Text>
          <FormControl
            placeholder='Search by name'
            value={searchInput}
            onChange={(e) => setSearchInput(e.target.value)}
            className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
          />
        </InputGroup>
      </Col>
      <Row className={`justify-content-center mt-5 ${theme ? 'text-light' : 'text-black'}`}>
        <Table responsive='sm' striped bordered hover variant={theme ? 'dark' : 'light'} className='mb-5'>
          <tbody>
          {authorsSearchData.models?.map((item: any, index: number) => {
            return (
              <tr key={index}>
                <td>{index + 1}.</td>
                <td>
                  <Link to={routes.authorDetails.getRoute(item.id)}>
                    <h6 style={{
                      whiteSpace: 'nowrap',
                      width: '14rem',
                      overflow: 'hidden'
                    }}>
                      {item.name}
                    </h6>
                  </Link>
                </td>
              </tr>
            );
          })}
          </tbody>
        </Table>
      </Row>
      <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto'>
        <Pagination
          page={authorsSearchData.page}
          totalPages={authorsSearchData.totalPages}
          onPageSelected={changePage}
        />
      </Col>
    </Container>
  );
};

export default AuthorsSearch;