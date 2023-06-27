import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { BiSearch } from 'react-icons/bi';
import { Col, Container, FormControl, InputGroup, Row } from 'react-bootstrap';

import ordersService from '../../../services/ordersService';
import errorsService from '../../../services/errorsService';
import OrderCard from '../../../components/OrderCard';
import Pagination from '../../../components/Pagination';
import routes from '../../../common/routes';
import useTheme from '../../../hooks/useTheme';

const OrdersSearch = (): JSX.Element => {
  const { page } = useParams();
  const navigate = useNavigate();
  const { theme } = useTheme();
  const [searchInput, setSearchInput] = useState<string>('');
  const [ordersSearchData, setOrdersSearchData] = useState<any>({});

  useEffect(() => {
    ordersService
      .search(Number(page ?? 1), searchInput)
      .subscribe({
        next: value => setOrdersSearchData(value.data),
        error: errorsService.handle
      });
  }, [page, searchInput]);

  const changePage = (page: number) => {
    navigate(routes.ordersSearch.getRoute(page));
  };

  return (
    <Container className='py-5'>
      <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto text-center'>
        <h1 className={theme ? 'text-light my-5' : 'text-black my-5'}>Search orders</h1>
        <InputGroup className='mb-3'>
          <InputGroup.Text className={theme ? 'bg-black text-dark-primary' : 'bg-light text-light-primary'}>
            <BiSearch size='2rem' />
          </InputGroup.Text>
          <FormControl
            placeholder='Search by customer name'
            value={searchInput}
            onChange={(e) => setSearchInput(e.target.value)}
            className={theme ? 'bg-light-black text-light' : 'bg-light text-black'}
          />
        </InputGroup>
      </Col>
      <Row className={`justify-content-center mt-5 ${theme ? 'text-light' : 'text-black'}`}>
        {ordersSearchData.models?.map((order: any, index: number) => {
          return (
            <OrderCard
              key={index}
              id={order.id}
              date={new Date(order.date).toLocaleString()}
              status={order.status}
              customerName={order.customerName}
            />
          );
        })}
      </Row>
      <Col xs={10} md={7} lg={6} xl={4} className='mb-3 mx-auto'>
        <Pagination
          page={ordersSearchData.page}
          totalPages={ordersSearchData.totalPages}
          onPageSelected={changePage}
        />
      </Col>
    </Container>
  );
};

export default OrdersSearch;