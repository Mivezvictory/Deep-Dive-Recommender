import { Button, Stack, Typography } from '@mui/material';
import { useAuth } from '../providers/AuthProvider';
import {ThemeProvider} from '@mui/material';
import {theme} from '../stylings/theme'
import {LOGIN_PAGE_STYLING} from '../stylings/theme'
import parse from 'html-react-parser';

export default function LoginPageAlt() {
  const { login } = useAuth();
  const highlightedText = "<span style='background-color: white;'>Explore an artist’s catalog—top hits and hidden gems—curated into a smooth listening journey.</span>";
  return (
    <ThemeProvider theme={theme}>
      <Stack alignItems="center" justifyContent="center" spacing={3} sx={LOGIN_PAGE_STYLING}>
        
          <Typography color="black" maxWidth={520}>
            {parse(highlightedText)}          
          </Typography>
          <Button variant="contained" size="large" onClick={login} sx={{ textTransform: 'none' }}>
              Sign in with Spotify
          </Button>
      </Stack>
    </ThemeProvider>
    
  );
}
