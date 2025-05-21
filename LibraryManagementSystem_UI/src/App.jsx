import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import PrivateRoute from "./routes/PrivateRoute";
import GuestRoute from "./routes/GuestRoute";
import Navbar from "./pages/Navbar";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Home from "./pages/Home";
import Profile from "./pages/Profile"
import Books from "./pages/Books";
import BookDetail from "./pages/BookDetail";

function App() {
  return (
    <Router>
      <div className="flex flex-col min-h-screen">
        <Navbar />
        <div className="flex-grow mt-20">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<GuestRoute><Login /></GuestRoute>} />
            <Route path="/register" element={<GuestRoute><Register /></GuestRoute>} />
            <Route path="/profile" element={<PrivateRoute><Profile /></PrivateRoute>} />
            <Route path="/books" element={<PrivateRoute><Books /></PrivateRoute>} />
            <Route path="/books/:id" element={<PrivateRoute><BookDetail /></PrivateRoute>} />
            {/* <Route path="*" element={<NotFound />} /> */}
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
