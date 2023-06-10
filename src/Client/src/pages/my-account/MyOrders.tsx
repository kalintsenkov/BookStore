import Heading from '../../components/Heading';
import OrderCard from '../../components/OrderCard';

const MyOrders = (props: any): JSX.Element => {
  return (
    <>
      <Heading heading='My Orders' size='h3' />
      {props.orders.map((order: any, index: number) => {
        return (
          <OrderCard
            key={index}
            id={order.id}
            date={new Date(order.date).toLocaleString()}
            status={order.status}
          />
        );
      })}
    </>
  );
};

export default MyOrders;