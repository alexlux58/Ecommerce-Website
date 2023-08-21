import { useState } from "react";
import "./Login.css";
import { Link } from "react-router-dom";
import "./constant";

function Login() {
  const [isChecked, setIsChecked] = useState(false); // Default to checked

  const handleCheckboxChange = (event) => {
    setIsChecked(event.target.checked);
  };
  return (
    <div className="background">
      <div className="shape"></div>
      <div className="shape"></div>
      <form>
        <h3>Login Here</h3>

        <label htmlFor="username">Username</label>
        <input type="text" placeholder="Email or Phone" id="username" />

        <label htmlFor="password">Password</label>
        <input type="password" placeholder="Password" id="password" />

        <Link to="login">
          <button type="button">Log In</button>
        </Link>
        <Link to="/registration">
          <button type="button" className="register-button">
            Register
          </button>
        </Link>
        <div className="d-flex justify-content-around align-items-center mb-4">
          {/* <!-- Checkbox --> */}
          <div className="form-check-row">
            <div className="form-check">
              <input
                className="form-check-input"
                type="checkbox"
                value=""
                id="form1Example3"
                checked={isChecked}
                onChange={handleCheckboxChange}
              />
              <label className="form-check-label" htmlFor="form1Example3">
                Remember me
              </label>
            </div>
            <a className="forgot-password" href="#!">
              Forgot password?
            </a>
          </div>
        </div>

        <div className="social">
          <div className="go">
            <a
              href="https://www.google.com/"
              className="fab fa-google"
              cursor="pointer"
            >
              Google
            </a>
          </div>
          <div className="fb">
            <a
              href="https://www.facebook.com/"
              className="fab fa-facebook"
              cursor="pointer"
            >
              Facebook
            </a>
          </div>
        </div>
      </form>
    </div>
  );
}

export default Login;
