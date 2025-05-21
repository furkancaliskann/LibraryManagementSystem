import { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";

const PrivateRoute = ({ children }) => {
  const { isLoggedIn } = useContext(AuthContext);

  if (isLoggedIn === null) {
    return <div className="text-center mt-10">Yükleniyor...</div>; // loading durumu
  }

  return isLoggedIn ? children : <Navigate to="/login"/>;
};

export default PrivateRoute;
