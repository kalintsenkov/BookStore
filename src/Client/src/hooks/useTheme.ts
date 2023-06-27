import { useContext } from 'react';

import { ThemeContext } from '../providers/ThemeContextProvider';

const useTheme = () => {
  const { theme, setTheme } = useContext(ThemeContext);

  return { theme, setTheme };
};

export default useTheme;