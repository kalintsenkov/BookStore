const routes = {
  home: {
    path: '/',
    getRoute: () => '/'
  },
  login: {
    path: '/login',
    getRoute: () => '/login'
  },
  register: {
    path: '/register',
    getRoute: () => '/register'
  },
  bookDetails: {
    path: '/book/details/:id',
    getRoute: (id: number) => `/book/details/${id}`
  },
  bookEdit: {
    path: '/book/edit/:id',
    getRoute: (id: number) => `/book/edit/${id}`
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