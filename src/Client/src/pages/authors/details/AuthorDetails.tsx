import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { Button, Col, Container, Row } from 'react-bootstrap';

import authorsService from '../../../services/authorsService';
import errorsService from '../../../services/errorsService';
import usersService from '../../../services/usersService';
import routes from '../../../common/routes';
import useTheme from '../../../hooks/useTheme';

const AuthorDetails = (): JSX.Element => {
  const { id } = useParams();

  const navigate = useNavigate();
  const { theme } = useTheme();
  const [authorData, setAuthorData] = useState<any>({});

  useEffect(() => {
    authorsService
      .details(Number(id))
      .subscribe({
        next: value => setAuthorData(value.data),
        error: errorsService.handle
      });
  }, [id]);

  const deleteAuthor = () => {
    authorsService
      .delete(Number(id))
      .subscribe({
        next: () => navigate(routes.home.getRoute()),
        error: errorsService.handle
      });
  };

  const navigateToAuthorBooks = () => {
    navigate(routes.booksByAuthorSearch.getRoute(authorData.name));
  };

  return (
    <Container className='py-5'>
      <Row className='justify-content-center mt-5'>
        <Col xs={10} md={7} lg={7} className={`${theme ? 'text-light' : 'text-black'}`}>
          <h1>{authorData.name}</h1>
          <p className='mt-3 h5' style={{ opacity: '0.8', fontWeight: '400' }}>
            {authorData.description}
          </p>
          <Button
            onClick={navigateToAuthorBooks}
            style={{ marginRight: 15 }}
            className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} border-0 mt-lg-3`}>
            More by {authorData.name}
          </Button>
          {usersService.isAdministrator() ? (
            <>
              <Button
                variant='warning'
                onClick={() => navigate(routes.authorEdit.getRoute(Number(id)))}
                className='mt-lg-3'
                style={{ marginRight: 15 }}
              >
                Edit
              </Button>
              <Button
                variant='danger'
                className='mt-lg-3'
                onClick={() => deleteAuthor()}
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

export default AuthorDetails;