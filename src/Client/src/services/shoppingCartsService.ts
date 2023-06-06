import apiService from './apiService';
import { ENDPOINTS } from '../common/constants';

const shoppingCartsService = {
  mine: () => {
    return apiService.get(ENDPOINTS.SHOPPING_CARTS_PATH + 'mine');
  },
  addBook: (data: {
    bookId: number,
    quantity: number
  }) => {
    return apiService.post(ENDPOINTS.SHOPPING_CARTS_PATH + 'addBook', data);
  },
  editQuantity: (data: {
    bookId: number,
    quantity: number
  }) => {
    return apiService.put(ENDPOINTS.SHOPPING_CARTS_PATH + 'editQuantity', data);
  },
  removeBook: (bookId: number) => {
    return apiService.delete(ENDPOINTS.SHOPPING_CARTS_PATH + 'removeBook', {
      data: {
        bookId
      }
    });
  }
};

export default shoppingCartsService;