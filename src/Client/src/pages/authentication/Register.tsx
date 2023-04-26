import { Link } from 'react-router-dom';

const Register = (): JSX.Element => {
  return (
    <section className='sign-in-page'>
      <div className='container p-0'>
        <div className='row no-gutters'>
          <div className='col-sm-12 align-self-center page-content rounded'>
            <div className='row m-0'>
              <div className='col-sm-12 sign-in-page-data'>
                <div className='sign-in-from bg-primary rounded'>
                  <h3 className='mb-0 text-center text-white'>Sign Up</h3>
                  <form className='mt-4 form-text'>
                    <div className='form-group'>
                      <label htmlFor='exampleInputEmail1'>Full Name</label>
                      <input type='email' className='form-control mb-0' id='exampleInputEmail1'
                             placeholder='Your Full Name' />
                    </div>
                    <div className='form-group'>
                      <label htmlFor='exampleInputEmail2'>Email address</label>
                      <input type='email' className='form-control mb-0' id='exampleInputEmail2'
                             placeholder='Enter email' />
                    </div>
                    <div className='form-group'>
                      <label htmlFor='exampleInputPassword1'>Password</label>
                      <input type='password' className='form-control mb-0'
                             id='exampleInputPassword1' placeholder='Password' />
                    </div>
                    <div className='d-inline-block w-100'>
                      <div className='custom-control custom-checkbox d-inline-block mt-2 pt-1'>
                        <input type='checkbox' className='custom-control-input'
                               id='customCheck1' />
                        <label className='custom-control-label' htmlFor='customCheck1'>I
                          accept <a href='#' className='text-light'>Terms and
                            Conditions</a></label>
                      </div>
                    </div>
                    <div className='sign-info text-center'>
                      <button type='submit' className='btn btn-white d-block w-100 mb-2'>Sign Up
                      </button>
                      <span className='text-dark d-inline-block line-height-2'>Already Have Account?
                                                <Link to='/login' className='text-white'> Log In</Link>
                                            </span>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Register;