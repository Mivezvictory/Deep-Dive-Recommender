import { Button, Stack, Typography } from '@mui/material';
import { useAuth } from '../providers/AuthProvider';

export default function LoginPageAI() {
  const { login } = useAuth();
  return (
    <Stack alignItems="center" justifyContent="center" spacing={3} sx={{ minHeight: '70vh', textAlign: 'center' }}>
      <Typography variant="h3" fontWeight={700}>Deep-Dive Recommender</Typography>
      <Typography color="text.secondary" maxWidth={520}>
        Explore an artist’s catalog—top hits and hidden gems—curated into a smooth listening journey.
      </Typography>
      <Button variant="contained" size="large" onClick={login} sx={{ textTransform: 'none' }}>
        Sign in with Spotify
      </Button>
    </Stack>
  );
}
