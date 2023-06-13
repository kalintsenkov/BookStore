import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Button, Col, Container, Form, Row, Spinner } from 'react-bootstrap';

import { useThemeHook } from '../../../providers/ThemeProvider';
import authorsService from '../../../services/authorsService';
import errorsService from '../../../services/errorsService';
import routes from '../../../common/routes';

const AuthorCreate = (): JSX.Element => {
  const navigate = useNavigate();
  const [theme] = useThemeHook();
  const [loading, setLoading] = useState(false);
  const [name, setName] = useState<string>('');
  const [description, setDescription] = useState<string>('');

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (name && description) {
      setLoading(true);

      authorsService
        .create({
          name,
          description
        })
        .subscribe({
          next: res => {
            const id = Number(res.data);
            setLoading(false);
            navigate(routes.authorDetails.getRoute(id));
          },
          error: err => {
            setLoading(false);
            errorsService.handle(err);
          }
        });
    }
  };

  return (
    <Container className='py-5 mt-5'>
      <Row className='justify-content-center mt-5'>
        <Col xs={11} sm={10} md={8} lg={4}
             className={`p-4 rounded ${theme ? 'text-light bg-dark' : 'text-black bg-light'}`}>
          <h1 className={`text-center border-bottom pb-3 ${theme ? 'text-dark-primary' : 'text-light-primary'}`}>
            Create Author
          </h1>
          <Form onSubmit={(e) => handleSubmit(e)}>
            <Form.Group className='mb-3'>
              <Form.Label>Name</Form.Label>
              <Form.Control name='name'
                            type='text'
                            placeholder='Name'
                            required
                            value={name}
                            onChange={e => setName(e.target.value)} />
            </Form.Group>
            <Form.Group className='mb-3'>
              <Form.Label>Description</Form.Label>
              <Form.Control name='description'
                            as='textarea'
                            type='text'
                            placeholder='Description'
                            required
                            value={description}
                            onChange={e => setDescription(e.target.value)} />
            </Form.Group>
            <Button
              type='submit'
              className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} m-auto d-block`}
              disabled={loading}
              style={{ border: 0 }}
            >
              {loading ?
                <>
                  <Spinner
                    as='span'
                    animation='grow'
                    size='sm'
                    role='status'
                    aria-hidden='true'
                  />
                  &nbsp;Loading...
                </> : 'Create'
              }
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default AuthorCreate;