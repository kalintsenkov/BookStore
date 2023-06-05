import { Link } from 'react-router-dom';

import { Badge, Card, Col, Row } from 'react-bootstrap';

import { useThemeHook } from '../providers/ThemeProvider';
import routes from '../common/routes';

interface IOrderCardProps {
  id: number;
  date: string;
  status: string;
}

const OrderCard = (props: IOrderCardProps) => {
  const [theme] = useThemeHook();

  return (
    <Link to={routes.orderDetails.getRoute(props.id)} className='nav-link'>
      <Card className={`${theme ? 'bg-light-black text-light' : 'bg-light text-black'} mb-3`}
            border={theme ? 'warning' : 'primary'}>
        <Card.Header>
          Date: <b>{props.date}</b>
          <small className='float-end'>Order ID: {props.id}</small>
        </Card.Header>
        <Row className='p-2'>
          <Col>
            <Card.Body>
              <Card.Text>
                <Badge pill bg='success'>
                  Status: {props.status}
                </Badge>
              </Card.Text>
            </Card.Body>
          </Col>
        </Row>
      </Card>
    </Link>
  );
};

export default OrderCard;