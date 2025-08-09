import { useAuth } from '../providers/AuthProvider';
import LoginPageAlt from '../pages/LoginPageAlt';
import { LoginPage } from '../pages/LoginPage';
import ExplorePage from '../pages/ExplorePage';

export function useRoutesElement() {
  const { isAuthed } = useAuth();
  return isAuthed ? <ExplorePage /> : <LoginPageAlt />;
}
