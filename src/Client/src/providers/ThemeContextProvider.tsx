import React, { createContext, useEffect, useState } from 'react';

interface IThemeContextProps {
  children?: React.ReactNode;
}

export const ThemeContext = createContext({
  theme: false,
  setTheme: (theme: boolean) => {}
});

const ThemeContextProvider = ({ children }: IThemeContextProps): JSX.Element => {
  const [theme, setTheme] = useState<boolean>(JSON.parse(localStorage.getItem('theme')!) || false);

  useEffect(() => {
    localStorage.setItem('theme', JSON.stringify(theme));
  }, [theme]);

  return (
    <ThemeContext.Provider
      value={{
        theme,
        setTheme
      }}>
      {children}
    </ThemeContext.Provider>
  );
};

export default ThemeContextProvider;