import React, { useContext } from "react";
import { AuthContext } from "../context/AuthContext";

const Home = () => {
  const { isLoggedIn, user, role } = useContext(AuthContext);

  return (
    <div
      className="flex flex-col items-center justify-center bg-gray-50 px-4 pt-20"
      style={{ height: "calc(100vh - 80px)" }}
    >
      <h1 className="text-4xl font-bold mb-4 text-center">
        Kütüphane Yönetim Sistemi
      </h1>

      <p className="mb-4 text-lg text-center max-w-xl">
        {isLoggedIn && user ? (
          <>
            Merhaba <span className="font-semibold">{user.name} {user.surname}</span>, hoş geldin!
            <br />
            Rolün: <span className="italic text-gray-700">{role}</span>
          </>
        ) : (
          <>Giriş yapmak için sağ üstteki butonları kullanabilirsiniz.</>
        )}
      </p>

      <p className="text-md text-center max-w-xl text-gray-600">
        Kütüphane kitaplarını, ödünç alma ve iade işlemlerini kolayca yönetebilirsiniz.
      </p>
    </div>
  );
};

export default Home;
