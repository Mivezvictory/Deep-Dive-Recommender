import { useAuth } from '../providers/AuthProvider';
import LoginPageAI from '../pages/LoginPageAI';
import { LoginPage } from '../pages/LoginPage';
import ExplorePage from '../pages/ExplorePage';

export function useRoutesElement() {
  const { isAuthed } = useAuth();
  return isAuthed ? <ExplorePage /> : <LoginPageAI />;
}
