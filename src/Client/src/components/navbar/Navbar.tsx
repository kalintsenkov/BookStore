import React from 'react';

import ShoppingCart from '../shoppingCart/ShoppingCart';
import Profile from '../profile/Profile';
import Breadcrumbs from '../breadcrumbs/Breadcrumbs';

const Navbar = (): JSX.Element => {
  return (
    <div className='iq-top-navbar'>
      <div className='iq-navbar-custom'>
        <nav className='navbar navbar-expand-lg navbar-light p-0'>
          <Breadcrumbs />
          <div className='collapse navbar-collapse' id='navbarSupportedContent'>
            <ul className='navbar-nav ml-auto navbar-list'>
              <li className='nav-item nav-icon dropdown'>
                <ShoppingCart />
              </li>
              <li className='line-height pt-3'>
                <Profile />
              </li>
            </ul>
          </div>
        </nav>
      </div>
    </div>
  );
};

export default Navbar;