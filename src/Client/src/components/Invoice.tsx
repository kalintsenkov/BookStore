import './Invoice.css';
import companyLogo from '../images/company-logo.png';

interface IInvoiceProps {
  id: number;
  date: string;
  customerName: string;
  orderedBooks: {
    bookTitle: string;
    bookPrice: number;
    quantity: number;
  }[];
}

const Invoice = (props: IInvoiceProps): JSX.Element => {
  const totalPrice = () => {
    const initialValue = 0;
    return props.orderedBooks.reduce(
      (sum: number, item: any) => sum + item.quantity * item.bookPrice,
      initialValue
    );
  };

  return (
    <div className='invoice-box'>
      <table>
        <tr className='top'>
          <td colSpan={2}>
            <table>
              <tr>
                <td className='title'>
                  <img src={companyLogo} alt='Company logo' />
                </td>

                <td>
                  Invoice #: {props.id}<br />
                  Created: {props.date}<br />
                </td>
              </tr>
            </table>
          </td>
        </tr>

        <tr className='information'>
          <td colSpan={2}>
            <table>
              <tr>
                <td>
                  Sparksuite, Inc.<br />
                  12345 Sunny Road<br />
                  Sunnyville, TX 12345
                </td>

                <td>
                  {props.customerName}<br />
                </td>
              </tr>
            </table>
          </td>
        </tr>

        <tr className='heading'>
          <td>Item</td>
          <td>Price</td>
        </tr>

        {props.orderedBooks.map((item, index) => (
          <tr key={index} className={`item ${props.orderedBooks.length === index + 1 ? 'last' : ''}`}>
            <td>{item.bookTitle}</td>
            <td>${(item.bookPrice * item.quantity).toFixed(2)}</td>
          </tr>
        ))}

        <tr className='total'>
          <td></td>
          <td>Total: ${totalPrice().toFixed(2)}</td>
        </tr>
      </table>
    </div>
  );
};

export default Invoice;