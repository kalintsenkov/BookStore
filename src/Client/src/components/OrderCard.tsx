import { Link } from 'react-router-dom';

import { Badge, Button, Card, Col, Row } from 'react-bootstrap';

import useTheme from '../hooks/useTheme';
import routes from '../common/routes';

interface IOrderCardProps {
  id: number;
  date: string;
  status: string;
  customerName?: string;
}

const OrderCard = (props: IOrderCardProps) => {
  const { theme } = useTheme();

  const getStatusBackground = (): string => {
    if (props.status === 'Pending') {
      return 'warning';
    } else if (props.status === 'Cancelled') {
      return 'danger';
    } else if (props.status === 'Completed') {
      return 'success';
    } else {
      return '';
    }
  };

  return (
    <Link to={routes.orderDetails.getRoute(props.id)} className='nav-link'>
      <Card className={`${theme ? 'bg-light-black text-light' : 'bg-light text-black'} mb-3`}
            border={theme ? 'warning' : 'primary'}>
        <Card.Header>
          <span>Order ID: <b>{props.id}</b></span>
          <span className='float-end'>Date: <b>{props.date}</b></span>
        </Card.Header>
        <Row className='p-2'>
          <Col>
            <Card.Body>
              {props.customerName ? (
                <Card.Text>
                  Customer: <b>{props.customerName}</b>
                </Card.Text>
              ) : (
                <></>
              )}
              <Card.Footer className='p-0 border-0 bg-transparent'>
                <Row className='justify-content-center'>
                  <Col className='py-2'>
                    <Badge pill bg={getStatusBackground()}>
                      Status: {props.status}
                    </Badge>
                  </Col>
                  <Col className='py-2'>
                    <Button
                      className={`${theme ? 'bg-dark-primary text-black' : 'bg-light-primary'} float-end border-0`}>
                      See details
                    </Button>
                  </Col>
                </Row>
              </Card.Footer>
            </Card.Body>
          </Col>
        </Row>
      </Card>
    </Link>
  );
};

export default OrderCard;