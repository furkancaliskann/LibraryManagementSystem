import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import { validateToken } from "../services/authService";

const PrivateRoute = ({ children }) => {
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
    return <div className="text-center mt-10">Yükleniyor...</div>; // loading durumu
  }

  return isValid ? children : <Navigate to="/login" replace />;
};

export default PrivateRoute;
