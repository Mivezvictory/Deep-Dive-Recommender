import { createTheme } from '@mui/material/styles';

export const getDesignTokens = (mode: 'light' | 'dark') => ({
  palette: {
    mode,
    ...(mode === 'light'
      ? {
          // palette values for light mode
          primary: { main: '#1DB954' },
          background: { default: '#fafafa', paper: '#fff' },
        }
      : {
          // palette values for dark mode
          primary: { main: '#1DB954' },
          background: { default: '#121212', paper: '#1e1e1e' },
        }),
  },
});

export const lightTheme = createTheme(getDesignTokens('light'));
export const darkTheme  = createTheme(getDesignTokens('dark'));