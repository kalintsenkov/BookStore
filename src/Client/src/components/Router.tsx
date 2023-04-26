import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import Sidebar from './sidebar/Sidebar';
import Navbar from './navbar/Navbar';
import Footer from './footer/Footer';
import Home from '../pages/home/Home';
import Login from '../pages/authentication/Login';
import Register from '../pages/authentication/Register';

const AppRouter = (): JSX.Element => {
  return (
    <Router>
      <div className='wrapper'>
        <Sidebar />
        <Navbar />
        <div id='content-page' className='content-page'>
          <div className='container-fluid'>
            <Routes>
              <Route path='/' element={<Home />} />
              <Route path='/login' element={<Login />} />
              <Route path='/register' element={<Register />} />
            </Routes>
          </div>
        </div>
        <Footer />
      </div>
    </Router>
  );
};

export default AppRouter;