import { Box, Container, Button, Typography, CssBaseline } from '@mui/material';

export function LoginPage() {
  const apiBase = import.meta.env.VITE_API_BASE_URL;
  const handleLogin = () => {
    //window.location.href = `${apiBase}/spotify-auth`;
  };

  return (
    <Box
        sx={{
        position: 'relative', // changed from 'relative' to 'fixed'
        left: 0,
        top: 0,
        width: '100vw',
        height: '100vh',
        backgroundImage: "url('/images/bg-image.jpg')",
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
        backgroundAttachment: 'fixed',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        overflow: 'hidden',
        zIndex: 0, // ensure background stays behind overlay and card
      }}
    >
      <CssBaseline />

      {/* Semi-transparent overlay */}
      <Box
        sx={{
          position: 'absolute',
          inset: 0,
          backgroundColor: 'rgba(0, 0, 0, 0.4)',
          zIndex: 1,
        }}
      />

      {/* Sign-in Card Container */}
      <Container
        component="main"
        maxWidth="xs"
        disableGutters
        sx={{
          zIndex: 2,
          height: '80vh',
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          bgcolor: 'rgba(34, 41, 43, 0.6)',//rgba(96, 119, 127, 0.6)',
          color: 'white',
          p: 4,
          borderRadius: 2,
          boxShadow: 1,
        }}
      >
        <Box
          component="img"
          src="/icon.svg"
          alt="Deep-Dive Logo"
          sx={{ width: { xs: 80, sm: 128 }, mb: 3 }}
        />
        <Typography variant="h3" fontWeight={700}>Deep-Dive Recommender</Typography>nder
        <Button
          fullWidth
          variant="contained"
          onClick={handleLogin}
          sx={{
            mt: 1,
            backgroundColor: '#1DB954',
            color: 'black',
            py: 1.5,
            '&:hover': { backgroundColor: '#1ED760' },
          }}
        >
          Sign in with Spotify
        </Button>
        <Typography variant="caption" sx={{ mt: 2, color: 'white' }}>
          Powered by Spotify Web API
        </Typography>
      </Container>
    </Box>
  );
}
