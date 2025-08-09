const apiBase = import.meta.env.VITE_API_BASE_URL as string;

export async function deepDive(token: string, artistId: string): Promise<string[]> {
  const res = await fetch(`${apiBase}/deepdive?artistId=${artistId}`, {
    headers: { Authorization: `Bearer ${token}` }
  });
  if (!res.ok) throw new Error(`Deep-dive failed (${res.status})`);
  const data = await res.json();
  return data.uris ?? [];
}
