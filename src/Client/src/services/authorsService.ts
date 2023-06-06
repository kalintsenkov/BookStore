import apiService from './apiService';
import { ENDPOINTS } from '../common/constants';

const authorsService = {
  details: (id: number) => {
    return apiService.get(ENDPOINTS.AUTHORS_PATH + id);
  },
  delete: (id: number) => {
    return apiService.delete(ENDPOINTS.AUTHORS_PATH + id);
  }
};

export default authorsService;