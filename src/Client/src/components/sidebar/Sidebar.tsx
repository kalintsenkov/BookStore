import React from 'react';

const Sidebar = (): JSX.Element => {
  return (
    <div className='iq-sidebar'>
      <div className='iq-sidebar-logo d-flex justify-content-between'>
        <a href='index.html' className='header-logo'>
          <img src='images/logo.png' className='img-fluid rounded-normal' alt='' />
          <div className='logo-title'>
            <span className='text-primary text-uppercase'>Booksto</span>
          </div>
        </a>
        <div className='iq-menu-bt-sidebar'>
          <div className='iq-menu-bt align-self-center'>
            <div className='wrapper-menu'>
              <div className='main-circle'>
                <i className='las la-bars'></i>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id='sidebar-scrollbar'>
        <nav className='iq-sidebar-menu'>
          <ul id='iq-sidebar-toggle' className='iq-menu'>
            <li className='active active-menu'>
              <a
                href='src/components/App#dashboard'
                className='iq-waves-effect'
                data-toggle='collapse'
                aria-expanded='true'
              >
                <span className='ripple rippleEffect'></span>
                <i className='las la-home iq-arrow-left'></i>
                <span>Shop</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul
                id='dashboard'
                className='iq-submenu collapse show'
                data-parent='#iq-sidebar-toggle'
              >
                <li>
                  <a href='index.html'>
                    <i className='las la-house-damage'></i>Home Page
                  </a>
                </li>
                <li>
                  <a href='category.html'>
                    <i className='ri-function-line'></i>Category Page
                  </a>
                </li>
                <li>
                  <a href='book-page.html'>
                    <i className='ri-book-line'></i>Book Page
                  </a>
                </li>
                <li>
                  <a href='book-pdf.html'>
                    <i className='ri-file-pdf-line'></i>Book PDF
                  </a>
                </li>
                <li className='active'>
                  <a href='Checkout.html'>
                    <i className='ri-checkbox-multiple-blank-line'></i>Checkout
                  </a>
                </li>
                <li>
                  <a href='wishlist.html'>
                    <i className='ri-heart-line'></i>wishlist
                  </a>
                </li>
              </ul>
            </li>
            <li>
              <a
                href='src/components/App#admin'
                className='iq-waves-effect'
                data-toggle='collapse'
                aria-expanded='false'
              >
                <span className='ripple rippleEffect'></span>
                <i className='ri-admin-line'></i>
                <span>Admin</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul id='admin' className='iq-submenu collapse' data-parent='#iq-sidebar-toggle'>
                <li>
                  <a href='admin-dashboard.html'>
                    <i className='ri-dashboard-line'></i>Dashboard
                  </a>
                </li>
                <li>
                  <a href='admin-category.html'>
                    <i className='ri-list-check-2'></i>Category Lists
                  </a>
                </li>
                <li>
                  <a href='admin-author.html'>
                    <i className='ri-file-user-line'></i>Author
                  </a>
                </li>
                <li>
                  <a href='admin-books.html'>
                    <i className='ri-book-2-line'></i>Books
                  </a>
                </li>
              </ul>
            </li>
            <li>
              <a
                href='src/components/App#userinfo'
                className='iq-waves-effect'
                data-toggle='collapse'
                aria-expanded='false'
              >
                <span className='ripple rippleEffect'></span>
                <i className='las la-user-tie iq-arrow-left'></i>
                <span>User</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul id='userinfo' className='iq-submenu collapse' data-parent='#iq-sidebar-toggle'>
                <li>
                  <a href='profile.html'>
                    <i className='las la-id-card-alt'></i>User Profile
                  </a>
                </li>
                <li>
                  <a href='profile-edit.html'>
                    <i className='las la-edit'></i>User Edit
                  </a>
                </li>
                <li>
                  <a href='add-user.html'>
                    <i className='las la-plus-circle'></i>User Add
                  </a>
                </li>
                <li>
                  <a href='user-list.html'>
                    <i className='las la-th-list'></i>User List
                  </a>
                </li>
              </ul>
            </li>
            <li>
              <a
                href='src/components/App#ui-elements'
                className='iq-waves-effect collapsed'
                data-toggle='collapse'
                aria-expanded='false'
              >
                <i className='lab la-elementor iq-arrow-left'></i>
                <span>UI Elements</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul
                id='ui-elements'
                className='iq-submenu collapse'
                data-parent='#iq-sidebar-toggle'
              >
                <li className='elements'>
                  <a
                    href='src/components/App#sub-menu'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-play-circle-line'></i>
                    <span>UI Kit</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='sub-menu' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='ui-colors.html'>
                        <i className='las la-palette'></i>colors
                      </a>
                    </li>
                    <li>
                      <a href='ui-typography.html'>
                        <i className='las la-keyboard'></i>Typography
                      </a>
                    </li>
                    <li>
                      <a href='ui-alerts.html'>
                        <i className='las la-tag'></i>Alerts
                      </a>
                    </li>
                    <li>
                      <a href='ui-badges.html'>
                        <i className='lab la-atlassian'></i>Badges
                      </a>
                    </li>
                    <li>
                      <a href='ui-breadcrumb.html'>
                        <i className='las la-bars'></i>Breadcrumb
                      </a>
                    </li>
                    <li>
                      <a href='ui-buttons.html'>
                        <i className='las la-tablet'></i>Buttons
                      </a>
                    </li>
                    <li>
                      <a href='ui-cards.html'>
                        <i className='las la-credit-card'></i>Cards
                      </a>
                    </li>
                    <li>
                      <a href='ui-carousel.html'>
                        <i className='las la-film'></i>Carousel
                      </a>
                    </li>
                    <li>
                      <a href='ui-embed-video.html'>
                        <i className='las la-video'></i>Video
                      </a>
                    </li>
                    <li>
                      <a href='ui-grid.html'>
                        <i className='las la-border-all'></i>Grid
                      </a>
                    </li>
                    <li>
                      <a href='ui-images.html'>
                        <i className='las la-images'></i>Images
                      </a>
                    </li>
                    <li>
                      <a href='ui-list-group.html'>
                        <i className='las la-list'></i>list Group
                      </a>
                    </li>
                    <li>
                      <a href='ui-media-object.html'>
                        <i className='las la-ad'></i>Media
                      </a>
                    </li>
                    <li>
                      <a href='ui-modal.html'>
                        <i className='las la-columns'></i>Modal
                      </a>
                    </li>
                    <li>
                      <a href='ui-notifications.html'>
                        <i className='las la-bell'></i>Notifications
                      </a>
                    </li>
                    <li>
                      <a href='ui-pagination.html'>
                        <i className='las la-ellipsis-h'></i>Pagination
                      </a>
                    </li>
                    <li>
                      <a href='ui-popovers.html'>
                        <i className='las la-eraser'></i>Popovers
                      </a>
                    </li>
                    <li>
                      <a href='ui-progressbars.html'>
                        <i className='las la-hdd'></i>Progressbars
                      </a>
                    </li>
                    <li>
                      <a href='ui-tabs.html'>
                        <i className='las la-database'></i>Tabs
                      </a>
                    </li>
                    <li>
                      <a href='ui-tooltips.html'>
                        <i className='las la-magnet'></i>Tooltips
                      </a>
                    </li>
                  </ul>
                </li>
                <li className='form'>
                  <a
                    href='src/components/App#forms'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='lab la-wpforms'></i>
                    <span>Forms</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='forms' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='form-layout.html'>
                        <i className='las la-book'></i>Form Elements
                      </a>
                    </li>
                    <li>
                      <a href='form-validation.html'>
                        <i className='las la-edit'></i>Form Validation
                      </a>
                    </li>
                    <li>
                      <a href='form-switch.html'>
                        <i className='las la-toggle-off'></i>Form Switch
                      </a>
                    </li>
                    <li>
                      <a href='form-chechbox.html'>
                        <i className='las la-check-square'></i>Form Checkbox
                      </a>
                    </li>
                    <li>
                      <a href='form-radio.html'>
                        <i className='ri-radio-button-line'></i>Form Radio
                      </a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a
                    href='src/components/App#wizard-form'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-archive-drawer-line'></i>
                    <span>Forms Wizard</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='wizard-form' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='form-wizard.html'>
                        <i className='ri-clockwise-line'></i>Simple Wizard
                      </a>
                    </li>
                    <li>
                      <a href='form-wizard-validate.html'>
                        <i className='ri-clockwise-2-line'></i>Validate Wizard
                      </a>
                    </li>
                    <li>
                      <a href='form-wizard-vertical.html'>
                        <i className='ri-anticlockwise-line'></i>Vertical Wizard
                      </a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a
                    href='src/components/App#tables'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-table-line'></i>
                    <span>Table</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='tables' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='tables-basic.html'>
                        <i className='ri-table-line'></i>Basic Tables
                      </a>
                    </li>
                    <li>
                      <a href='data-table.html'>
                        <i className='ri-database-line'></i>Data Table
                      </a>
                    </li>
                    <li>
                      <a href='table-editable.html'>
                        <i className='ri-refund-line'></i>Editable Table
                      </a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a
                    href='src/components/App#charts'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-pie-chart-box-line'></i>
                    <span>Charts</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='charts' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='chart-morris.html'>
                        <i className='ri-file-chart-line'></i>Morris Chart
                      </a>
                    </li>
                    <li>
                      <a href='chart-high.html'>
                        <i className='ri-bar-chart-line'></i>High Charts
                      </a>
                    </li>
                    <li>
                      <a href='chart-am.html'>
                        <i className='ri-folder-chart-line'></i>Am Charts
                      </a>
                    </li>
                    <li>
                      <a href='chart-apex.html'>
                        <i className='ri-folder-chart-2-line'></i>Apex Chart
                      </a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a
                    href='src/components/App#icons'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-list-check'></i>
                    <span>Icons</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='icons' className='iq-submenu collapse' data-parent='#ui-elements'>
                    <li>
                      <a href='icon-dripicons.html'>
                        <i className='ri-stack-line'></i>Dripicons
                      </a>
                    </li>
                    <li>
                      <a href='icon-fontawesome-5.html'>
                        <i className='ri-facebook-fill'></i>Font Awesome 5
                      </a>
                    </li>
                    <li>
                      <a href='icon-lineawesome.html'>
                        <i className='ri-keynote-line'></i>line Awesome
                      </a>
                    </li>
                    <li>
                      <a href='icon-remixicon.html'>
                        <i className='ri-remixicon-line'></i>Remixicon
                      </a>
                    </li>
                    <li>
                      <a href='icon-unicons.html'>
                        <i className='ri-underline'></i>unicons
                      </a>
                    </li>
                  </ul>
                </li>
              </ul>
            </li>
            <li>
              <a
                href='src/components/App#pages'
                className='iq-waves-effect collapsed'
                data-toggle='collapse'
                aria-expanded='false'
              >
                <i className='las la-file-alt iq-arrow-left'></i>
                <span>Pages</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul id='pages' className='iq-submenu collapse' data-parent='#iq-sidebar-toggle'>
                <li>
                  <a
                    href='src/components/App#authentication'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-pages-line'></i>
                    <span>Authentication</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='authentication' className='iq-submenu collapse' data-parent='#pages'>
                    <li>
                      <a href='sign-in.html'>
                        <i className='las la-sign-in-alt'></i>Login
                      </a>
                    </li>
                    <li>
                      <a href='sign-up.html'>
                        <i className='ri-login-circle-line'></i>Register
                      </a>
                    </li>
                    <li>
                      <a href='pages-recoverpw.html'>
                        <i className='ri-record-mail-line'></i>Recover Password
                      </a>
                    </li>
                    <li>
                      <a href='pages-confirm-mail.html'>
                        <i className='ri-file-code-line'></i>Confirm Mail
                      </a>
                    </li>
                    <li>
                      <a href='pages-lock-screen.html'>
                        <i className='ri-lock-line'></i>Lock Screen
                      </a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a
                    href='src/components/App#extra-pages'
                    className='iq-waves-effect collapsed'
                    data-toggle='collapse'
                    aria-expanded='false'
                  >
                    <i className='ri-pantone-line'></i>
                    <span>Extra Pages</span>
                    <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                  </a>
                  <ul id='extra-pages' className='iq-submenu collapse' data-parent='#pages'>
                    <li>
                      <a href='pages-timeline.html'>
                        <i className='ri-map-pin-time-line'></i>Timeline
                      </a>
                    </li>
                    <li>
                      <a href='pages-invoice.html'>
                        <i className='ri-question-answer-line'></i>Invoice
                      </a>
                    </li>
                    <li>
                      <a href='blank-page.html'>
                        <i className='ri-invision-line'></i>Blank Page
                      </a>
                    </li>
                    <li>
                      <a href='pages-error.html'>
                        <i className='ri-error-warning-line'></i>Error 404
                      </a>
                    </li>
                    <li>
                      <a href='pages-error-500.html'>
                        <i className='ri-error-warning-line'></i>Error 500
                      </a>
                    </li>
                    <li>
                      <a href='pages-pricing.html'>
                        <i className='ri-price-tag-line'></i>Pricing
                      </a>
                    </li>
                    <li>
                      <a href='pages-pricing-one.html'>
                        <i className='ri-price-tag-2-line'></i>Pricing 1
                      </a>
                    </li>
                    <li>
                      <a href='pages-maintenance.html'>
                        <i className='ri-archive-line'></i>Maintenance
                      </a>
                    </li>
                    <li>
                      <a href='pages-comingsoon.html'>
                        <i className='ri-mastercard-line'></i>Coming Soon
                      </a>
                    </li>
                    <li>
                      <a href='pages-faq.html'>
                        <i className='ri-compasses-line'></i>Faq
                      </a>
                    </li>
                  </ul>
                </li>
              </ul>
            </li>
            <li>
              <a
                href='src/components/App#menu-level'
                className='iq-waves-effect collapsed'
                data-toggle='collapse'
                aria-expanded='false'
              >
                <i className='ri-record-circle-line iq-arrow-left'></i>
                <span>Menu Level</span>
                <i className='ri-arrow-right-s-line iq-arrow-right'></i>
              </a>
              <ul
                id='menu-level'
                className='iq-submenu collapse'
                data-parent='#iq-sidebar-toggle'
              >
                <li>
                  <a href='src/components/App#'>
                    <i className='ri-record-circle-line'></i>Menu 1
                  </a>
                </li>
                <li>
                  <a href='src/components/App#'>
                    <i className='ri-record-circle-line'></i>Menu 2
                  </a>
                  <ul>
                    <li className='menu-level'>
                      <a
                        href='src/components/App#sub-menus'
                        className='iq-waves-effect collapsed'
                        data-toggle='collapse'
                        aria-expanded='false'
                      >
                        <i className='ri-play-circle-line'></i>
                        <span>Sub-menu</span>
                        <i className='ri-arrow-right-s-line iq-arrow-right'></i>
                      </a>
                      <ul id='sub-menus' className='iq-submenu iq-submenu-data collapse'>
                        <li>
                          <a href='src/components/App#'>
                            <i className='ri-record-circle-line'></i>Sub-menu 1
                          </a>
                        </li>
                        <li>
                          <a href='src/components/App#'>
                            <i className='ri-record-circle-line'></i>Sub-menu 2
                          </a>
                        </li>
                        <li>
                          <a href='src/components/App#'>
                            <i className='ri-record-circle-line'></i>Sub-menu 3
                          </a>
                        </li>
                      </ul>
                    </li>
                  </ul>
                </li>
                <li>
                  <a href='src/components/App#'>
                    <i className='ri-record-circle-line'></i>Menu 3
                  </a>
                </li>
                <li>
                  <a href='src/components/App#'>
                    <i className='ri-record-circle-line'></i>Menu 4
                  </a>
                </li>
              </ul>
            </li>
          </ul>
        </nav>
        <div id='sidebar-bottom' className='p-3 position-relative'>
          <div className='iq-card'>
            <div className='iq-card-body'>
              <div className='sidebarbottom-content'>
                <div className='image'>
                  <img src='images/page-img/side-bkg.png' alt='' />
                </div>
                <button type='submit' className='btn w-100 btn-primary mt-4 view-more'>
                  Become Membership
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;