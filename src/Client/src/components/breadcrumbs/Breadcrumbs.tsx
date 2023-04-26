import React from 'react';

const Breadcrumbs = (): JSX.Element => {
  return (
    <div className='navbar-breadcrumb'>
      <h5 className='mb-0'>Checkout</h5>
      <nav aria-label='breadcrumb'>
        <ul className='breadcrumb'>
          <li className='breadcrumb-item'>
            <a href='index.html'>Home</a>
          </li>
          <li className='breadcrumb-item active' aria-current='page'>
            Checkout
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Breadcrumbs;