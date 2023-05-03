import React, { createContext, useContext, useEffect, useState } from 'react';

type IThemeContext = [boolean, React.Dispatch<React.SetStateAction<boolean>>];

const ThemeContext = createContext<IThemeContext>([false, () => false]);

const ThemeProvider = (props) => {
  const [theme, setTheme] = useState<boolean>(JSON.parse(localStorage.getItem('theme')) || false);

  useEffect(() => {
    localStorage.setItem('theme', JSON.stringify(theme));
  }, [theme]);

  const setThemeMode = mode => setTheme(mode);

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