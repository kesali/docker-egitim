import { useEffect, useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import './App.css';
import axios from 'axios';

function App() {
  const [weatherForecast, setWeatherForecast] = useState([])
  const [summary, setSummary] = useState('');
  const [temperature, setTemperature] = useState(0);

  useEffect(()  => {
    axios.get("http://localhost:8080/weatherforecast").then(data=>
    {
      setWeatherForecast(data.data);})
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        {weatherForecast.map(forecast=>(<p key={forecast.date}>{forecast.summary} /  {forecast.temperatureC}°C</p>))}
        <Form onSubmit={(target)=>{
          target.preventDefault()
          axios.post("http://localhost:8080/weatherforecast", {summary, temperatureC: temperature}).then(data=>{
            setWeatherForecast([...weatherForecast, data.data])
          })
        }}>
        <Form.Group className="mb-3" controlId="summary">
          <Form.Label>Summary</Form.Label>
          <Form.Control placeholder="Enter summary" onChange={(e)=>setSummary(e.target.value)} value={summary}/>
        </Form.Group> 

        <Form.Group className="mb-3" controlId="temperature">
          <Form.Label>Temperature</Form.Label>
          <Form.Control placeholder="What is the weather like" onChange={(e)=>setTemperature(e.target.value)} value={temperature}/>
        </Form.Group>
        <Button variant="primary" type="submit">
          Save
        </Button>
      </Form>
      </header>
    </div>
  );
}

export default App;
