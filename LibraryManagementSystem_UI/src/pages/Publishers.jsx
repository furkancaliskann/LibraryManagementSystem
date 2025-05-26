import { useEffect, useState, useContext } from "react";
import { getPublishers, addPublisher, deletePublisher } from "../services/publisherService";
import { AuthContext } from "../context/AuthContext";

const Publishers = () => {
  const { role } = useContext(AuthContext);
  const isAdmin = role === "Admin";

  const [publishers, setPublishers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [name, setName] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await getPublishers();
        setPublishers(res.data || []);
      } catch (error) {
        console.error("Yayıncılar alınamadı:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleAdd = async (e) => {
    e.preventDefault();
    if (!name.trim()) return;

    try {
      await addPublisher({ name });
      setName("");
      const res = await getPublishers();
      setPublishers(res.data || []);
    } catch (error) {
      console.error("Yayıncı eklenemedi:", error);
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Silmek istediğinize emin misiniz?")) return;
    try {
      await deletePublisher(id);
      setPublishers(publishers.filter(p => p.id !== id));
    } catch (error) {
      console.error("Yayıncı silinemedi:", error);
    }
  };

  if (loading) return <div className="text-center mt-10">Yükleniyor...</div>;

  return (
    <div className="max-w-4xl mx-auto mt-10 p-6 bg-white shadow rounded">
      <h1 className="text-3xl font-bold mb-6">Yayıncılar</h1>

      {publishers.length === 0 ? (
        <p className="text-gray-600 mb-6">Hiç yayıncı bulunamadı.</p>
      ) : (
        <table className="w-full table-auto border-collapse mb-6">
          <thead>
            <tr className="bg-gray-100 text-left">
              <th className="p-3 border-b text-center">ID</th>
              <th className="p-3 border-b text-center">İsim</th>
              {isAdmin && <th className="p-3 border-b text-center">İşlem</th>}
            </tr>
          </thead>
          <tbody>
            {publishers.map((publisher) => (
              <tr key={publisher.id} className="hover:bg-gray-50">
                <td className="px-4 py-2 border text-center">{publisher.id}</td>
                <td className="px-4 py-2 border text-center">{publisher.name}</td>
                {isAdmin && (
                  <td className="px-4 py-2 border text-center">
                    <button
                      onClick={() => handleDelete(publisher.id)}
                      className="bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded"
                    >
                      Sil
                    </button>
                  </td>
                )}
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {isAdmin && (
        <form onSubmit={handleAdd} className="space-y-4 max-w-md">
          <div>
            <label className="block mb-1 font-semibold">Yayıncı Adı</label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="w-full border px-3 py-2 rounded"
              required
              placeholder="Yayıncı adı giriniz"
            />
          </div>
          <button
            type="submit"
            className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded"
          >
            Ekle
          </button>
        </form>
      )}
    </div>
  );
};

export default Publishers;
