import { useEffect, useState } from 'react';
import { Navigate } from 'react-router-dom';
import { validateToken } from "../services/authService";

const GuestRoute = ({ children }) => {
  const [isValid, setIsValid] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");

    if (!token) {
        setIsValid(false);
        return;
    }

    const checkToken = async () => {
        try {
          const result = await validateToken();
          setIsValid(result);
  
          console.log("Private route result:", result);
  
          if (!result) localStorage.removeItem("token");
        } catch {
          localStorage.removeItem("token");
          setIsValid(false);
        }
      };
  
      checkToken();
  }, []);

  if (isValid === null) {
    return <div>Loading...</div>;
  }

  if (isValid) {
    return <Navigate to="/home" replace />;
  }

  return children;
};

export default GuestRoute;
