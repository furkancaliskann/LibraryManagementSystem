import { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";

const GuestRoute = ({ children }) => {
  const { isLoggedIn } = useContext(AuthContext);

  if (isLoggedIn === null) {
    return <div className="text-center mt-10">Yükleniyor...</div>; // loading durumu
  }

  return !isLoggedIn ? children : <Navigate to="/" />;
};

export default GuestRoute;
