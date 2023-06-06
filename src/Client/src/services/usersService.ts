import apiService from './apiService';
import jwtService from './jwtService';
import { ENDPOINTS, ROLES } from '../common/constants';

const loginPath = ENDPOINTS.IDENTITY_PATH + 'login';
const registerPath = ENDPOINTS.IDENTITY_PATH + 'register';

const usersService = {
  login: (credentials: {
    email: string,
    password: string
  }) => {
    return apiService.post(loginPath, credentials);
  },
  register: (credentials: {
    fullName: string,
    email: string,
    password: string,
    confirmPassword: string
  }) => {
    return apiService.post(registerPath, credentials);
  },
  logout: () => {
    jwtService.removeToken();
  },
  isAdministrator(): boolean {
    const role = this.getRole();

    if (!role) {
      return false;
    }

    return role === ROLES.ADMINISTRATOR;
  },
  getRole: (): string | null => {
    const decoded = jwtService.decode();

    if (!decoded) {
      return null;
    }

    return decoded.role;
  },
  isAuthenticated: (): boolean => {
    return jwtService.getToken() != null;
  }
};

export default usersService;