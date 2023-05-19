import { useThemeHook } from '../providers/ThemeProvider';

interface IHeadingProps {
  size?: string;
  heading: string;
}

const Heading = (props: IHeadingProps) => {
  const [theme] = useThemeHook();

  return (
    <h1
      className={`text-center border-bottom py-2 ${props?.size} ${theme ? 'text-dark-primary' : 'text-light-primary'}`}>
      {props.heading}
    </h1>
  );
};

export default Heading;