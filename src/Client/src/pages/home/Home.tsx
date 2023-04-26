const Home = (): JSX.Element => {
  return (
    <div className='row'>
      <div className='col-lg-12'>
        <div className='iq-card-transparent iq-card-block iq-card-stretch iq-card-height rounded'>
          <div className='newrealease-contens'>
            <ul id='newrealease-slider' className='list-inline p-0 m-0 d-flex align-items-center'>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/01.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/02.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/03.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/04.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/05.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/06.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/07.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/08.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
              <li className='item'>
                <a href='#'>
                  <img src='images/new_realeases/09.jpg' className='img-fluid w-100 rounded' alt='' />
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div className='col-lg-12'>
        <div className='iq-card iq-card-block iq-card-stretch iq-card-height'>
          <div className='iq-card-header d-flex justify-content-between align-items-center position-relative'>
            <div className='iq-header-title'>
              <h4 className='card-title mb-0'>Browse Books</h4>
            </div>
            <div className='iq-card-header-toolbar d-flex align-items-center'>
              <a href='category.html' className='btn btn-sm btn-primary view-more'>View More</a>
            </div>
          </div>
          <div className='iq-card-body'>
            <div className='row'>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/01.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Reading on the World</h6>
                          <p className='font-size-13 line-height mb-1'>Jhone Steben</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$100</span>
                          <h6><b>$89</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/02.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>The Catcher in the Rye</h6>
                          <p className='font-size-13 line-height mb-1'>Fritz Wold</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <h6><b>$99</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/03.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Little Black Book</h6>
                          <p className='font-size-13 line-height mb-1'>John Klok</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$150</span>
                          <h6><b>$129</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/04.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Take On The Risk</h6>
                          <p className='font-size-13 line-height mb-1'>George Strong</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$120</span>
                          <h6><b>$100</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/05.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Absteact On Background</h6>
                          <p className='font-size-13 line-height mb-1'>Ichae Semos</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$105</span>
                          <h6><b>$99</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/06.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Find The Wave Book</h6>
                          <p className='font-size-13 line-height mb-1'>Fidel Martin</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$110</span>
                          <h6><b>$100</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/07.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>See the More Story</h6>
                          <p className='font-size-13 line-height mb-1'>Jules Boutin</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$89</span>
                          <h6><b>$79</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/08.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>The Wikde Book</h6>
                          <p className='font-size-13 line-height mb-1'>Kusti Franti</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$99</span>
                          <h6><b>$89</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent mb-lg-0'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/09.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>Conversion Erik Routley</h6>
                          <p className='font-size-13 line-height mb-1'>Argele Intili</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$100</span>
                          <h6><b>$79</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent mb-md-0 mb-lg-0'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/10.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>The Leo Dominica</h6>
                          <p className='font-size-13 line-height mb-1'>Henry Jurk</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$120</span>
                          <h6><b>$99</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent mb-sm-0 mb-md-0 mb-lg-0'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/11.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>By The Editbeth Jat</h6>
                          <p className='font-size-13 line-height mb-1'>David King</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <h6><b>$149</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className='col-sm-6 col-md-4 col-lg-3'>
                <div
                  className='iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent mb-0 mb-sm-0 mb-md-0 mb-lg-0'>
                  <div className='iq-card-body p-0'>
                    <div className='d-flex align-items-center'>
                      <div className='col-6 p-0 position-relative image-overlap-shadow'>
                        <a href='#'><img className='img-fluid rounded w-100'
                                         src='images/browse-books/12.jpg'
                                         alt='' /></a>
                        <div className='view-book'>
                          <a href='book-page.html' className='btn btn-sm btn-white'>View
                            Book</a>
                        </div>
                      </div>
                      <div className='col-6'>
                        <div className='mb-2'>
                          <h6 className='mb-1'>The Crucial Decade</h6>
                          <p className='font-size-13 line-height mb-1'>Attilio Marzi</p>
                          <div className='d-block line-height'>
                                                   <span className='font-size-11 text-warning'>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                      <i className='fa fa-star'></i>
                                                   </span>
                          </div>
                        </div>
                        <div className='price d-flex align-items-center'>
                          <span className='pr-1 old-price'>$99</span>
                          <h6><b>$89</b></h6>
                        </div>
                        <div className='iq-product-action'>
                          <a href='#'><i
                            className='ri-shopping-cart-2-fill text-primary'></i></a>
                          <a href='#' className='ml-2'><i
                            className='ri-heart-fill text-danger'></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className='col-lg-6'>
        <div className='iq-card iq-card-block iq-card-stretch iq-card-height'>
          <div className='iq-card-header d-flex justify-content-between mb-0'>
            <div className='iq-header-title'>
              <h4 className='card-title'>Featured Books</h4>
            </div>
            <div className='iq-card-header-toolbar d-flex align-items-center'>
              <div className='dropdown'>
                                 <span className='dropdown-toggle p-0 text-body' id='dropdownMenuButton2'
                                       data-toggle='dropdown'>
                                 This Week<i className='ri-arrow-down-s-fill'></i>
                                 </span>
                <div className='dropdown-menu dropdown-menu-right shadow-none'
                     aria-labelledby='dropdownMenuButton2'>
                  <a className='dropdown-item' href='#'><i className='ri-eye-fill mr-2'></i>View</a>
                  <a className='dropdown-item' href='#'><i
                    className='ri-delete-bin-6-fill mr-2'></i>Delete</a>
                  <a className='dropdown-item' href='#'><i
                    className='ri-pencil-fill mr-2'></i>Edit</a>
                  <a className='dropdown-item' href='#'><i className='ri-printer-fill mr-2'></i>Print</a>
                  <a className='dropdown-item' href='#'><i className='ri-file-download-fill mr-2'></i>Download</a>
                </div>
              </div>
            </div>
          </div>
          <div className='iq-card-body'>
            <div className='row align-items-center'>
              <div className='col-sm-5 pr-0'>
                <a href='#'><img className='img-fluid rounded w-100'
                                 src='images/page-img/featured-book.png' alt='' /></a>
              </div>
              <div className='col-sm-7 mt-3 mt-sm-0'>
                <h4 className='mb-2'>Casey Christie night book into find...</h4>
                <p className='mb-2'>Author: Gheg origin</p>
                <div className='mb-2 d-block'>
                                    <span className='font-size-12 text-warning'>
                                       <i className='fa fa-star'></i>
                                       <i className='fa fa-star'></i>
                                       <i className='fa fa-star'></i>
                                       <i className='fa fa-star'></i>
                                       <i className='fa fa-star'></i>
                                    </span>
                </div>
                <span className='text-dark mb-3 d-block'>Lorem Ipsum is simply dummy test in find a of the printing and typeset ing industry into end.</span>
                <button type='submit' className='btn btn-primary learn-more'>Learn More</button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className='col-lg-6'>
        <div className='iq-card iq-card-block iq-card-stretch iq-card-height'>
          <div className='iq-card-header d-flex justify-content-between mb-0'>
            <div className='iq-header-title'>
              <h4 className='card-title'>Featured Writer</h4>
            </div>
            <div className='iq-card-header-toolbar d-flex align-items-center'>
              <div className='dropdown'>
                                 <span className='dropdown-toggle p-0 text-body' id='dropdownMenuButton3'
                                       data-toggle='dropdown'>
                                 This Week<i className='ri-arrow-down-s-fill'></i>
                                 </span>
                <div className='dropdown-menu dropdown-menu-right shadow-none'
                     aria-labelledby='dropdownMenuButton3'>
                  <a className='dropdown-item' href='#'><i className='ri-eye-fill mr-2'></i>View</a>
                  <a className='dropdown-item' href='#'><i
                    className='ri-delete-bin-6-fill mr-2'></i>Delete</a>
                  <a className='dropdown-item' href='#'><i
                    className='ri-pencil-fill mr-2'></i>Edit</a>
                  <a className='dropdown-item' href='#'><i className='ri-printer-fill mr-2'></i>Print</a>
                  <a className='dropdown-item' href='#'><i className='ri-file-download-fill mr-2'></i>Download</a>
                </div>
              </div>
            </div>
          </div>
          <div className='iq-card-body'>
            <ul className='list-inline row mb-0 align-items-center iq-scrollable-block'>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/01.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Brandon Guidelines</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/02.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Hugh Millie-Yate</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>432</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/03.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Nathaneal Down</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>5471</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/04.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Thomas R. Toe</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>8764</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/05.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Druid Wensleydale</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>8987</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/06.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Natalya Undgrowth</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/07.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Desmond Eagle</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>4324</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/08.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Lurch Schpellchek</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>012</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/09.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Natalya Undgrowth</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/10.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Natalya Undgrowth</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/11.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Natalya Undgrowth</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
              <li className='col-sm-6 d-flex mb-3 align-items-center'>
                <div className='icon iq-icon-box mr-3'>
                  <a href='#'><img className='img-fluid avatar-60 rounded-circle'
                                   src='images/user/01.jpg' alt='' /></a>
                </div>
                <div className='mt-1'>
                  <h6>Natalya Undgrowth</h6>
                  <p className='mb-0 text-primary'>Publish Books: <span
                    className='text-body'>2831</span></p>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div className='col-lg-12'>
        <div className='iq-card iq-card-block iq-card-stretch iq-card-height'>
          <div className='iq-card-header d-flex justify-content-between align-items-center position-relative'>
            <div className='iq-header-title'>
              <h4 className='card-title mb-0'>Favorite Reads</h4>
            </div>
            <div className='iq-card-header-toolbar d-flex align-items-center'>
              <a href='category.html' className='btn btn-sm btn-primary view-more'>View More</a>
            </div>
          </div>
          <div className='iq-card-body favorites-contens'>
            <ul id='favorites-slider' className='list-inline p-0 mb-0 row'>
              <li className='col-md-4'>
                <div className='d-flex align-items-center'>
                  <div className='col-5 p-0 position-relative'>
                    <a href='#'>
                      <img src='images/favorite/01.jpg' className='img-fluid rounded w-100'
                           alt='' />
                    </a>
                  </div>
                  <div className='col-7'>
                    <h5 className='mb-2'>Every Book is a new Wonderful Travel..</h5>
                    <p className='mb-2'>Author : Pedro Araez</p>
                    <div
                      className='d-flex justify-content-between align-items-center text-dark font-size-13'>
                      <span>Reading</span>
                      <span className='mr-4'>78%</span>
                    </div>
                    <div className='iq-progress-bar-linear d-inline-block w-100'>
                      <div className='iq-progress-bar iq-bg-primary'>
                        <span className='bg-primary' data-percent='78'></span>
                      </div>
                    </div>
                    <a href='#' className='text-dark'>Read Now<i
                      className='ri-arrow-right-s-line'></i></a>
                  </div>
                </div>
              </li>
              <li className='col-md-4'>
                <div className='d-flex align-items-center'>
                  <div className='col-5 p-0 position-relative'>
                    <a href='#'>
                      <img src='images/favorite/02.jpg' className='img-fluid rounded w-100'
                           alt='' />
                    </a>
                  </div>
                  <div className='col-7'>
                    <h5 className='mb-2'>Casey Christie night book into find...</h5>
                    <p className='mb-2'>Author : Michael klock</p>
                    <div
                      className='d-flex justify-content-between align-items-center text-dark font-size-13'>
                      <span>Reading</span>
                      <span className='mr-4'>78%</span>
                    </div>
                    <div className='iq-progress-bar-linear d-inline-block w-100'>
                      <div className='iq-progress-bar iq-bg-danger'>
                        <span className='bg-danger' data-percent='78'></span>
                      </div>
                    </div>
                    <a href='#' className='text-dark'>Read Now<i
                      className='ri-arrow-right-s-line'></i></a>
                  </div>
                </div>
              </li>
              <li className='col-md-4'>
                <div className='d-flex align-items-center'>
                  <div className='col-5 p-0 position-relative'>
                    <a href='#'>
                      <img src='images/favorite/03.jpg' className='img-fluid rounded w-100'
                           alt='' />
                    </a>
                  </div>
                  <div className='col-7'>
                    <h5 className='mb-2'>The Secret to English Busy People..</h5>
                    <p className='mb-2'>Author : Daniel Ace</p>
                    <div
                      className='d-flex justify-content-between align-items-center text-dark font-size-13'>
                      <span>Reading</span>
                      <span className='mr-4'>78%</span>
                    </div>
                    <div className='iq-progress-bar-linear d-inline-block w-100'>
                      <div className='iq-progress-bar iq-bg-info'>
                        <span className='bg-info' data-percent='78'></span>
                      </div>
                    </div>
                    <a href='#' className='text-dark'>Read Now<i
                      className='ri-arrow-right-s-line'></i></a>
                  </div>
                </div>
              </li>
              <li className='col-md-4'>
                <div className='d-flex align-items-center'>
                  <div className='col-5 p-0 position-relative'>
                    <a href='#'>
                      <img src='images/favorite/04.jpg' className='img-fluid rounded w-100'
                           alt='' />
                    </a>
                  </div>
                  <div className='col-7'>
                    <h5 className='mb-2'>The adventures of Robins books...</h5>
                    <p className='mb-2'>Author : Luka Afton</p>
                    <div
                      className='d-flex justify-content-between align-items-center text-dark font-size-13'>
                      <span>Reading</span>
                      <span className='mr-4'>78%</span>
                    </div>
                    <div className='iq-progress-bar-linear d-inline-block w-100'>
                      <div className='iq-progress-bar iq-bg-success'>
                        <span className='bg-success' data-percent='78'></span>
                      </div>
                    </div>
                    <a href='#' className='text-dark'>Read Now<i
                      className='ri-arrow-right-s-line'></i></a>
                  </div>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;