import type { ReactNode } from 'react';
import { AppBar, Box, IconButton, Toolbar, Typography } from '@mui/material';
import Brightness4 from '@mui/icons-material/Brightness4';
import Brightness7 from '@mui/icons-material/Brightness7';
import { useThemeMode } from '../providers/ThemeModeProvider';
import { useAuth } from '../providers/AuthProvider';

export default function AppLayout({ children }: { children: ReactNode }) {
  const { mode, toggle } = useThemeMode();
  const { isAuthed, logout } = useAuth();

  return (
    <Box sx={{ minHeight: '100vh', display: 'flex', flexDirection: 'column' }}>
      <AppBar position="static" color="primary">
        <Toolbar sx={{ justifyContent: 'space-between' }}>
          <Typography variant="h6">Deep-Dive Recommender</Typography>
          <Box>
            {isAuthed && (
              <IconButton onClick={logout} color="inherit" sx={{ mr: 1 }} aria-label="Sign out">
                <Typography variant="body2">Sign out</Typography>
              </IconButton>
            )}
            <IconButton onClick={toggle} color="inherit" aria-label="Toggle theme">
              {mode === 'dark' ? <Brightness7 /> : <Brightness4 />}
            </IconButton>
          </Box>
        </Toolbar>
      </AppBar>

      <Box component="main" sx={{ flex: 1, p: 2, bgcolor: 'background.default' }}>
        {children}
      </Box>

      <Box component="footer" sx={{ p: 2, textAlign: 'center', bgcolor: 'background.paper' }}>
        Powered by Spotify Web API
      </Box>
    </Box>
  );
}
