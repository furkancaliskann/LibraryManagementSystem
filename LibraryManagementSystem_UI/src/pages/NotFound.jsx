import React from "react";
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <div className="flex flex-col items-center min-h-screen p-6 mt-50">
      <h1 className="text-6xl font-bold mb-4">404</h1>
      <h2 className="text-2xl font-semibold mb-6">Sayfa Bulunamadı</h2>
      <p className="mb-6 text-center max-w-md">
        Aradığınız sayfa mevcut değil veya yanlış URL girdiniz.
      </p>
      <Link
        to="/"
        className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-3 rounded font-medium"
      >
        Ana Sayfaya Dön
      </Link>
    </div>
  );
};

export default NotFound;
