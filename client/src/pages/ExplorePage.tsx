import { useState } from 'react';
import { Button, Card, CardActionArea, CardContent, CardMedia, Stack, TextField, Typography } from '@mui/material';
import { deepDive } from '../services/backend';
import { searchArtists, getTracksByIds } from '../services/spotify';
import { useAuth } from '../providers/AuthProvider';
import { ThemeProvider } from '@emotion/react';
import { theme } from '../stylings/theme'

export default function ExplorePage() {
  const { token } = useAuth();
  const [q, setQ] = useState('');
  const [artists, setArtists] = useState<any[]>([]);
  const [tracks, setTracks] = useState<any[]>([]);
  const [selected, setSelected] = useState<any>(null);

  const onSearch = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!token) return;
    const items = await searchArtists(token, q);
    setArtists(items);
  };

  const onDeepDive = async (artist: any) => {
    if (!token) return;
    setSelected(artist);
    const uris = await deepDive(token, artist.id);
    const ids = uris.map(u => getId(u)).filter(Boolean);
    if (!ids.length) { setTracks([]); return; }
    const t = await getTracksByIds(token, ids);
    setTracks(t);
  };

  return (
    <ThemeProvider theme={{theme}}>
      <Stack spacing={3}>
        <form onSubmit={onSearch}>
          <Stack direction="row" spacing={2}>
            <TextField fullWidth label="Search artist…" value={q} onChange={e => setQ(e.target.value)} />
            <Button type="submit" variant="outlined">Search</Button>
          </Stack>
        </form>

        <Stack spacing={2}>
          {artists.map(a => {
            const img = a.images?.[0]?.url;
            return (
              <Card key={a.id} variant="outlined">
                <CardActionArea onClick={() => onDeepDive(a)}>
                  <Stack direction="row" spacing={2} alignItems="center">
                    {img && <CardMedia component="img" image={img} alt={a.name} sx={{ width: 90, height: 90 }} />}
                    <CardContent sx={{ flex: 1 }}>
                      <Typography variant="h6">{a.name}</Typography>
                      {!!a.followers?.total && (
                        <Typography variant="body2" color="text.secondary">
                          {a.followers.total.toLocaleString()} followers
                        </Typography>
                      )}
                      <Typography variant="body2" color="primary">Click to build a deep-dive playlist</Typography>
                    </CardContent>
                  </Stack>
                </CardActionArea>
              </Card>
            );
          })}
        </Stack>

        {selected && (
          <Stack spacing={2}>
            <Typography variant="h5">Curated Picks for {selected.name}</Typography>
            {tracks.map(t => {
              const cover = t.album.images?.[0]?.url;
              const artists = t.artists.map((x: any) => x.name).join(', ');
              const href = t.external_urls?.spotify ?? `https://open.spotify.com/track/${t.id}`;
              return (
                <Card key={t.id} variant="outlined">
                  <Stack direction="row" spacing={2} alignItems="center">
                    {cover && <CardMedia component="img" image={cover} alt={t.name} sx={{ width: 90, height: 90 }} />}
                    <CardContent sx={{ flex: 1 }}>
                      <Typography fontWeight={600}>{t.name}</Typography>
                      <Typography variant="body2" color="text.secondary">
                        {artists} • {t.album.name}
                      </Typography>
                      <Button href={href} target="_blank" rel="noopener noreferrer" size="small" sx={{ mt: 1, textTransform: 'none' }}>
                        Open in Spotify
                      </Button>
                    </CardContent>
                  </Stack>
                </Card>
              );
            })}
          </Stack>
        )}
      </Stack>
    </ThemeProvider>
  );
}

function getId(uri: string) {
  if (!uri) return '';
  if (uri.startsWith('spotify:')) return uri.split(':').pop() ?? '';
  try { const u = new URL(uri); const parts = u.pathname.split('/').filter(Boolean); const i = parts.indexOf('track'); return i >= 0 ? parts[i+1] : ''; } catch { return uri; }
}
