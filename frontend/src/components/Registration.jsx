// import { useState } from "react";
import "./Login.css"; // Reusing the same CSS
import { Link } from "react-router-dom";

function Registration() {
  return (
    <div className="background">
      <div className="shape"></div>
      <div className="shape"></div>
      <form>
        <h3>Register Here</h3>

        <label htmlFor="fullname">Full Name</label>
        <input type="text" placeholder="Full Name" id="fullname" />

        <label htmlFor="email">Email</label>
        <input type="text" placeholder="Email" id="email" />

        <label htmlFor="password">Password</label>
        <input type="password" placeholder="Password" id="password" />

        <label htmlFor="confirm-password">Confirm Password</label>
        <input
          type="password"
          placeholder="Confirm Password"
          id="confirm-password"
        />

        <Link to="/">
          <button type="button" className="register-button">
            Register
          </button>
        </Link>

        <div className="d-flex justify-content-center align-items-center mt-4">
          <Link to="/" className="login-link">
            Already have an account? Log In
          </Link>
        </div>
      </form>
    </div>
  );
}

export default Registration;
