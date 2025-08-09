import type { ReactNode } from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import Brightness7Icon from '@mui/icons-material/Brightness7';
import Brightness4Icon from '@mui/icons-material/Brightness4';

export function Layout({
  mode,
  toggleTheme,
  children
}: {
  mode: 'light' | 'dark';
  toggleTheme: () => void;
  children: ReactNode;
}) {
  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <AppBar position="static" color="primary" enableColorOnDark>
        <Toolbar sx={{ justifyContent: 'space-between' }}>
          <Typography variant="h6">Deep-Dive Recommender</Typography>
          <IconButton onClick={toggleTheme} color="inherit">
            {mode === 'dark' ? <Brightness7Icon /> : <Brightness4Icon />}
          </IconButton>
        </Toolbar>
      </AppBar>

      <Box component="main" sx={{ flexGrow: 1, p: 2, bgcolor: 'background.default' }}>
        {children}
      </Box>

      <Box
        component="footer"
        sx={{
          p: 2,
          textAlign: 'center',
          bgcolor: 'background.paper',
          mt: 'auto',
        }}
      >
        Powered by Spotify Web API
      </Box>
    </Box>
  );
}
