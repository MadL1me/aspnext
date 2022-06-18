import React from 'react';
import logo from '../../resources/TupTup.png'
import './App.css';

function App() {
  
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          target="_blank"
          href={process.env.REACT_APP_API_URL + "/swagger"}
          rel="noopener noreferrer"
        >
          your backend api: {process.env.REACT_APP_API_URL}/swagger
        </a>
      </header>
    </div>
  );
}

export default App;
