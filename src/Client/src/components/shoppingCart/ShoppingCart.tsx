import React from 'react';

const ShoppingCart = (): JSX.Element => {
  return (
    <>
      <a href='src/components/App#'
         className='search-toggle iq-waves-effect text-gray rounded'>
        <i className='ri-shopping-cart-2-line'></i>
        <span className='badge badge-danger count-cart rounded-circle'>4</span>
      </a>
      <div className='iq-sub-dropdown'>
        <div className='iq-card shadow-none m-0'>
          <div className='iq-card-body p-0 toggle-cart-info'>
            <div className='bg-primary p-3'>
              <h5 className='mb-0 text-white'>
                All Carts
                <small className='badge  badge-light float-right pt-1'>4</small>
              </h5>
            </div>
            <a href='src/components/App#' className='iq-sub-card'>
              <div className='media align-items-center'>
                <div className=''>
                  <img className='rounded' src='images/cart/01.jpg' alt='' />
                </div>
                <div className='media-body ml-3'>
                  <h6 className='mb-0 '>Night People book</h6>
                  <p className='mb-0'>$32</p>
                </div>
                <div className='float-right font-size-24 text-danger'>
                  <i className='ri-close-fill'></i>
                </div>
              </div>
            </a>
            <a href='src/components/App#' className='iq-sub-card'>
              <div className='media align-items-center'>
                <div className=''>
                  <img className='rounded' src='images/cart/02.jpg' alt='' />
                </div>
                <div className='media-body ml-3'>
                  <h6 className='mb-0 '>The Sin Eater Book</h6>
                  <p className='mb-0'>$40</p>
                </div>
                <div className='float-right font-size-24 text-danger'>
                  <i className='ri-close-fill'></i>
                </div>
              </div>
            </a>
            <a href='src/components/App#' className='iq-sub-card'>
              <div className='media align-items-center'>
                <div className=''>
                  <img className='rounded' src='images/cart/03.jpg' alt='' />
                </div>
                <div className='media-body ml-3'>
                  <h6 className='mb-0 '>the Orange Tree</h6>
                  <p className='mb-0'>$30</p>
                </div>
                <div className='float-right font-size-24 text-danger'>
                  <i className='ri-close-fill'></i>
                </div>
              </div>
            </a>
            <a href='src/components/App#' className='iq-sub-card'>
              <div className='media align-items-center'>
                <div className=''>
                  <img className='rounded' src='images/cart/04.jpg' alt='' />
                </div>
                <div className='media-body ml-3'>
                  <h6 className='mb-0 '>Harsh Reality book</h6>
                  <p className='mb-0'>$25</p>
                </div>
                <div className='float-right font-size-24 text-danger'>
                  <i className='ri-close-fill'></i>
                </div>
              </div>
            </a>
            <div className='d-flex align-items-center text-center p-3'>
              <a className='btn btn-primary mr-2 iq-sign-btn'
                 href='src/components/App#' role='button'>
                View Cart
              </a>
              <a className='btn btn-primary iq-sign-btn' href='src/components/App#'
                 role='button'>
                Shop now
              </a>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default ShoppingCart;