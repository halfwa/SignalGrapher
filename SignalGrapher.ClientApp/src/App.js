import './App.css';
import { BrowserRouter as Router, Routes, Route} from "react-router-dom"
import CreateOrdersForm from './components/pages/signals/CreateSignalForm';

function App() {

  return (  
    <Router>
        <Routes>
          <Route path="/" element={ <CreateOrdersForm/> }/>
          <Route path="*" element={ <h1>Not Found</h1> }/>
        </Routes>
    </Router>
  );
}

export default App;
  