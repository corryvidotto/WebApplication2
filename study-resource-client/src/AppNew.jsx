import React, { useState } from "react";
import "./App.css";

function App() {
  const [searchQuery, setSearchQuery] = useState("");
  const [ResourceBookData, setResourceBookData] = useState(null);
  const [error, setError] = useState("");

  const handleInputChange = (e) => {
    setSearchQuery(e.target.value);
  };

  const handleSearch = async (e) => {
    e.preventDefault();
    setResourceBookData(null);
    setError("");

    try {
      const response = await fetch(`https://localhost:7292/api/Books?author=${encodeURIComponent(searchQuery)}`);

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      setResourceBookData(data);
    } catch (err) {
      setError("Resource Book's author not found or server error.");
      console.error(err);
    }
  };

  return (
    <div className="app-container">
      <form onSubmit={handleSearch} className="search-form">
        <h1>Search Resource Book's Author</h1>
        <input
          type="text"
          value={searchQuery}
          onChange={handleInputChange}
          placeholder="Enter an author's first and last name (e.g., Sebastian Raschka and Vahid Mirjalili)"
          className="search-input"
          required
        />
        <button type="submit" className="search-button">Search</button>
      </form>

      {ResourceBookData && (
        <div className="result-box">
          <h2>Author Found:</h2>
          <p><strong>Author:</strong> {ResourceBookData.author}</p>
        </div>
      )}

      {error && <p className="error-text">{error}</p>}
    </div>
  );
}

export default App;