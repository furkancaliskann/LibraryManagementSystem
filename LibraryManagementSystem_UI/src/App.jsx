import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import Home from "./pages/Home";
import PrivateRoute from "./routes/PrivateRoute";
import GuestRoute from "./routes/GuestRoute";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" 
        element={
          <GuestRoute>
            <LoginPage />
          </GuestRoute>
        } 
        />

        <Route path="/register"
        element={
        <GuestRoute>
          <RegisterPage />
        </GuestRoute>
        } 
        />
        
        <Route
          path="/home"
          element={
            <PrivateRoute>
              <Home />
            </PrivateRoute>
          }
        />
      </Routes>
    </Router>
  );
}

export default App;
