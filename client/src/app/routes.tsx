import { useAuth } from '../providers/AuthProvider';
import { LoginPage } from '../pages/LoginPage';
import ExplorePage from '../pages/ExplorePage';
import AppLayout from '../components/AppLayout';

export function useRoutesElement() {
  const { isAuthed } = useAuth();
  return isAuthed ? <AppLayout><ExplorePage /></AppLayout> : <LoginPage />;
}
