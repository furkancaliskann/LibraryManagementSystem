import React, { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";

const Navbar = () => {
  const { isLoggedIn, role, logout } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
  };

  return (
    <nav className="fixed top-0 left-0 w-full bg-white shadow-md py-4 z-50">
      <div className="max-w-screen-xl mx-auto px-4 flex justify-between items-center">

        {/* Sol grup */}
        <div className="flex items-center ml-6 space-x-6">
          <Link to="/" className="text-2xl font-extrabold text-gray-900">
            E-Kütüphane
          </Link>
          {isLoggedIn && (
            <Link
              to="/books"
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 ml-4"
            >
              Kitaplar
            </Link>
          )}
          {isLoggedIn && (
            <Link
              to="/authors"
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 ml-4"
            >
              Yazarlar
            </Link>
          )}
          {isLoggedIn && (
            <Link
              to="/categories"
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 ml-4"
            >
              Kategoriler
            </Link>
          )}
          {isLoggedIn && (
            <Link
              to="/publishers"
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 ml-4"
            >
              Yayıncılar
            </Link>
          )}

          {/* Yeni Rezervasyonlar butonu - sadece admin veya employee rolü varsa */}
          {isLoggedIn && (role === "Admin" || role === "Employee") && (
            <Link
              to="/reservations"
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 ml-4"
            >
              Rezervasyonlar
            </Link>
          )}
        </div>

        {/* Sağ grup */}
        <div className="flex items-center mr-6 space-x-4">
          {isLoggedIn ? (
            <>
              <Link
                to="/profile"
                className="bg-purple-600 text-white px-4 py-2 rounded hover:bg-purple-700"
              >
                Profil
              </Link>
              <button
                onClick={handleLogout}
                className="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600"
              >
                Çıkış Yap
              </button>
            </>
          ) : (
            <>
              <Link
                to="/login"
                className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
              >
                Giriş Yap
              </Link>
              <Link
                to="/register"
                className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
              >
                Kayıt Ol
              </Link>
            </>
          )}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
