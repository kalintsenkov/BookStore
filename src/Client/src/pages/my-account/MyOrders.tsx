import { useNavigate } from 'react-router-dom';

import Heading from '../../components/Heading';
import OrderCard from '../../components/OrderCard';

const MyOrders = (props): JSX.Element => {
  const navigate = useNavigate();

  return (
    <>
      <Heading heading='My Orders' size='h3' />
      {props.orders.map((order, index) => {
        return (
          <OrderCard key={index}
                     id={order.id}
                     date={new Date(order.date).toLocaleString()}
                     status={order.status} />
        );
      })}
    </>
  );
};

export default MyOrders;