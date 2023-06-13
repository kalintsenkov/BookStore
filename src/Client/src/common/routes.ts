const routes = {
  home: {
    path: '',
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
  authorsSearch: {
    path: '/authors/page/:page',
    getRoute: (page: number = 1) => `/authors/page/${page}`
  },
  authorDetails: {
    path: '/author/details/:id',
    getRoute: (id: number) => `/author/details/${id}`
  },
  authorEdit: {
    path: '/author/edit/:id',
    getRoute: (id: number) => `/author/edit/${id}`
  },
  authorCreate: {
    path: '/author/create',
    getRoute: () => '/author/create'
  },
  booksSearch: {
    path: '/books/page/:page',
    getRoute: (page: number = 1) => `/books/page/${page}`
  },
  booksByTitleSearch: {
    path: '/books/title/:title/page/:page',
    getRoute: (title: string, page: number = 1) => `/books/title/${title}/page/${page}`
  },
  booksByGenreSearch: {
    path: '/books/genre/:genre/page/:page',
    getRoute: (genre: string, page: number = 1) => `/books/genre/${genre}/page/${page}`
  },
  booksByAuthorSearch: {
    path: '/books/author/:author/page/:page',
    getRoute: (author: string, page: number = 1) => `/books/author/${author}/page/${page}`
  },
  booksByTitleAndGenreSearch: {
    path: '/books/title/:title/genre/:genre/page/:page',
    getRoute: (title: string, genre: string, page: number = 1) => `/books/title/${title}/genre/${genre}/page/${page}`
  },
  booksByGenreAndAuthorSearch: {
    path: '/books/genre/:genre/author/:author/page/:page',
    getRoute: (genre: string, author: string, page: number = 1) => `/books/genre/${genre}/author/${author}/page/${page}`
  },
  booksByTitleAndAuthorSearch: {
    path: '/books/title/:title/author/:author/page/:page',
    getRoute: (title: string, author: string, page: number = 1) => `/books/title/${title}/author/${author}/page/${page}`
  },
  booksByTitleGenreAndAuthorSearch: {
    path: '/books/title/:title/genre/:genre/author/:author/page/:page',
    getRoute: (title: string, genre: string, author: string, page: number = 1) => `/books/title/${title}/genre/${genre}/author/${author}/page/${page}`
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
    path: '/orders/page/:page',
    getRoute: (page: number = 1) => `/orders/page/${page}`
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
  },
  administration: {
    path: '/administration',
    getRoute: () => '/administration'
  }
};

export default routes;