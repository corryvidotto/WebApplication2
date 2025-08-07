import * as React from 'react';
import './App.css';
import { useEffect, useState } from 'react';
import axios from 'axios';

const App = () =>{
/*function App() {*/
  const [resourcebooks, setResourceBooks] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7292/api/Books') // Adjust port as needed
      .then(response => setResourceBooks(response.data))
      .catch(error => console.error(error));
  }, []);

  return (
    <div class='container'>
      <span className='ResourceBookListHeader'>Resource Books List</span>
      <p className='ResourceBookListInfo'>This file is in the<strong> study-resource-client </strong>folder and uses the <strong>WebApplication2</strong> .NET Core Web API</p>
      <p className='ResourceBookList'>
      <ul className="wideList">
        {resourcebooks.map(resourcebook => (
          <li key={resourcebook.id}>{resourcebook.author}</li>
        ))}
      </ul>
      </p>
    </div>
  );
}

export default App;
