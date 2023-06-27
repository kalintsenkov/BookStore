import React, { createContext, useContext, useEffect, useState } from 'react';

interface IThemeProvider {
  children?: React.ReactNode;
}

type IThemeContext = [boolean, React.Dispatch<React.SetStateAction<boolean>>];

const ThemeContext = createContext<IThemeContext>([false, () => false]);

const ThemeProvider = (props: IThemeProvider) => {
  const [theme, setTheme] = useState<boolean>(JSON.parse(localStorage.getItem('theme')!) || false);

  useEffect(() => {
    localStorage.setItem('theme', JSON.stringify(theme));
  }, [theme]);

  const setThemeMode = (mode: any) => setTheme(mode);

  return (
    <ThemeContext.Provider value={[theme, setThemeMode]}>
      {props.children}
    </ThemeContext.Provider>
  );
};

const useThemeHook = () => {
  const [theme] = useContext(ThemeContext);
  return [theme];
};

export { ThemeProvider, ThemeContext, useThemeHook };