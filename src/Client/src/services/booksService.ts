import apiService from './apiService';
import { ENDPOINTS } from '../common/constants';

const booksService = {
  search: (searchTerms: string) => {
    return apiService.get(ENDPOINTS.BOOKS_PATH + `?title=${searchTerms}`);
  },
  create: (data: {
    title: string,
    price: number,
    quantity: number,
    imageUrl: string,
    description: string,
    genre: number,
    author: string
  }) => {
    return apiService.post(ENDPOINTS.BOOKS_PATH, data);
  },
  edit: (id: number, data: {
    title: string,
    price: number,
    quantity: number,
    imageUrl: string,
    description: string,
    genre: number,
    author: string
  }) => {
    return apiService.put(ENDPOINTS.BOOKS_PATH + id, data);
  },
  details: (id: number) => {
    return apiService.get(ENDPOINTS.BOOKS_PATH + id);
  },
  delete: (id: number) => {
    return apiService.delete(ENDPOINTS.BOOKS_PATH + id);
  }
};

export default booksService;