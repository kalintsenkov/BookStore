import { Navigate, Outlet } from 'react-router-dom';
import routes from '../common/routes';

interface IProtectedRouteProps {
  isAllowed: boolean;
  redirectPath?: string;
  children: JSX.Element;
}

const ProtectedRoute = ({
                          isAllowed,
                          redirectPath = routes.login.getRoute(),
                          children
                        }: IProtectedRouteProps): JSX.Element => {
  if (!isAllowed) {
    return <Navigate to={redirectPath} replace />;
  }

  return children ? children : <Outlet />;
};

export default ProtectedRoute;