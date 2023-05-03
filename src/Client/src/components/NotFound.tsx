import { Container } from 'react-bootstrap';

import { useThemeHook } from '../providers/ThemeProvider';

const NotFound = () => {
  const [theme] = useThemeHook();

  return (
    <Container className='py-5'>
      <h1 className={`${theme ? 'text-light' : 'text-light-primary'} my-5 text-center`}>
        There's nothing here: 404!
      </h1>
    </Container>
  );
};

export default NotFound;