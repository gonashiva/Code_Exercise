import React from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, password }) => (
  <li>
    <strong>Login:</strong> {login}, <strong>Password:</strong> {password}
  </li>
);

const LoginAttemptList = ({ attempts }) => (
  <div className="Attempt-List-Main">
    <p>Recent activity</p>
    <input type="input" placeholder="Filter..." />
    <ul className="Attempt-List">
      {attempts.map((attempt, index) => (
        <LoginAttempt
          key={index}
          login={attempt.login}
          password={attempt.password}
        />
      ))}
    </ul>
  </div>
);

export default LoginAttemptList;
