import AppLayout from './components/AppLayout';
import { useRoutesElement } from './app/routes';

export function App() {
  const element = useRoutesElement();
  return <AppLayout>{element}</AppLayout>;
}

