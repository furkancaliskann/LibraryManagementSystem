import React, { useEffect, useState, useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../services/api"; // senin api axios config dosyan

const reservationStatusMap = {
  0: "Beklemede",
  1: "Tamamlandı",
  2: "İptal Edildi"
};

const Reservations = () => {
  const { role } = useContext(AuthContext);
  const [reservations, setReservations] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Sadece admin veya employee ise erişime izin ver
  useEffect(() => {
    if (role !== "Admin" && role !== "Employee") {
      setError("Bu sayfaya erişim yetkiniz yok.");
      setLoading(false);
      return;
    }

    const fetchReservations = async () => {
      try {
        setLoading(true);
        const response = await api.get("/reservations?includeDeleted=false");
        setReservations(response.data.data); // backend zaten User ve Book bilgilerini içermeli
        setLoading(false);
      } catch (err) {
        setError("Rezervasyonlar yüklenirken hata oluştu.");
        setLoading(false);
      }
    };

    fetchReservations();
  }, [role]);

  if (loading) return <p>Yükleniyor...</p>;
  if (error) return <p className="text-red-600">{error}</p>;

  return (
    <div className="max-w-6xl mx-auto p-6">
      <h1 className="text-3xl font-bold mb-6">Rezervasyonlar</h1>
      {reservations.length === 0 ? (
        <p>Henüz rezervasyon bulunmamaktadır.</p>
      ) : (
        <table className="w-full border-collapse border border-gray-300">
          <thead>
            <tr>
              <th className="border border-gray-300 p-2 text-center">Kullanıcı</th>
              <th className="border border-gray-300 p-2 text-center">Kitap</th>
              <th className="border border-gray-300 p-2 text-center">Rezervasyon Tarihi</th>
              <th className="border border-gray-300 p-2 text-center">Durum</th>
            </tr>
          </thead>
          <tbody>
            {reservations.map((res) => (
              <tr key={res.id}>
                <td className="border border-gray-300 p-2 text-center">
                  {res.user?.name} {res.user?.surname}
                </td>
                <td className="border border-gray-300 p-2 text-center">
                  {res.bookCopy?.book?.title}
                </td>
                <td className="border border-gray-300 p-2 text-center">
                  {new Date(res.reservationDate).toLocaleDateString()}
                </td>
                <td className="border border-gray-300 p-2 text-center">
                  {reservationStatusMap[res.status] || "Bilinmiyor"}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default Reservations;
