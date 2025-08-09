import React, { useState, useMemo } from 'react';
import ReactDOM from 'react-dom/client';
import { ThemeProvider, CssBaseline } from '@mui/material';
import { lightTheme, darkTheme } from './themes/theme';
import { Layout } from './components/Layout';
import App from './App';

const Root = () => {
  const [mode, setMode] = useState<'light' | 'dark'>(
    () => (localStorage.getItem('theme') as 'light' | 'dark') ?? 'light'
  );

  // Persist and memoize
  useMemo(() => localStorage.setItem('theme', mode), [mode]);
  const theme = useMemo(() => (mode === 'light' ? lightTheme : darkTheme), [mode]);

  const toggleTheme = () => setMode(prev => (prev === 'light' ? 'dark' : 'light'));

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Layout mode={mode} toggleTheme={toggleTheme}>
        <App />
      </Layout>
    </ThemeProvider>
  );
};

ReactDOM.createRoot(document.getElementById('root')!).render(<Root />);
