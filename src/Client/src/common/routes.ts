const routes = {
  home: {
    path: '/:page?',
    getRoute: (page?: number) => `/${page ?? ''}`
  },
  login: {
    path: '/login',
    getRoute: () => '/login'
  },
  register: {
    path: '/register',
    getRoute: () => '/register'
  },
  authorDetails: {
    path: '/author/details/:id',
    getRoute: (id: number) => `/author/details/${id}`
  },
  bookDetails: {
    path: '/book/details/:id',
    getRoute: (id: number) => `/book/details/${id}`
  },
  bookEdit: {
    path: '/book/edit/:id',
    getRoute: (id: number) => `/book/edit/${id}`
  },
  bookCreate: {
    path: '/book/create',
    getRoute: () => '/book/create'
  },
  ordersSearch: {
    path: '/orders/:page?',
    getRoute: (page?: number) => `/orders/${page ?? ''}`
  },
  orderDetails: {
    path: '/order/details/:id',
    getRoute: (id: number) => `/order/details/${id}`
  },
  cart: {
    path: '/cart',
    getRoute: () => '/cart'
  },
  myAccount: {
    path: '/my-account',
    getRoute: () => '/my-account'
  }
};

export default routes;