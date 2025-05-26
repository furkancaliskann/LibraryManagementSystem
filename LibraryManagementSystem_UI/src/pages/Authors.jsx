import { useEffect, useState, useContext } from "react";
import { getAuthors, addAuthor, deleteAuthor } from "../services/authorService";
import { AuthContext } from "../context/AuthContext";

const Authors = () => {
  const { role } = useContext(AuthContext);
  const [authors, setAuthors] = useState([]);
  const [loading, setLoading] = useState(true);
  const [name, setName] = useState("");
  const [bio, setBio] = useState("");

  const isAdmin = role === "Admin";

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const res = await getAuthors();
        // Eğer servis res.data veriyorsa
        setAuthors(res.data || []);
      } catch (error) {
        console.error("Yazarlar alınamadı:", error);
        setAuthors([]);
      } finally {
        setLoading(false);
      }
    };

    fetchAuthors();
  }, [role]);

  const handleAdd = async (e) => {
    e.preventDefault();
    if (!name.trim()) return;

    try {
      await addAuthor({ name, bio });
      setName("");
      setBio("");
      // Yeniden listeyi çek
      const res = await getAuthors();
      setAuthors(res.data || []);
    } catch (error) {
      console.error("Yazar eklenemedi:", error);
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Silmek istediğinize emin misiniz?")) return;

    try {
      await deleteAuthor(id);
      setAuthors(authors.filter((author) => author.id !== id));
    } catch (error) {
      console.error("Yazar silinemedi:", error);
    }
  };

  if (loading) return <div className="text-center mt-10">Yükleniyor...</div>;

  return (
    <div className="max-w-4xl mx-auto mt-10 p-6 bg-white shadow rounded">
      <h1 className="text-3xl font-bold mb-6">Yazarlar</h1>

      {authors.length === 0 ? (
        <p className="text-gray-600 mb-6">Hiç yazar bulunamadı.</p>
      ) : (
        <table className="w-full table-auto border-collapse mb-6">
          <thead>
            <tr className="bg-gray-100 text-left">
              <th className="p-3 border-b text-center">ID</th>
              <th className="p-3 border-b text-center">İsim</th>
              <th className="p-3 border-b text-center">Biyografi</th>
              {isAdmin && <th className="p-3 border-b text-center">İşlem</th>}
            </tr>
          </thead>
          <tbody>
            {authors.map((author) => (
              <tr key={author.id} className="hover:bg-gray-50">
                <td className="px-4 py-2 border text-center">{author.id}</td>
                <td className="px-4 py-2 border text-center">{author.name}</td>
                <td className="px-4 py-2 border text-center">{author.bio || "-"}</td>
                {isAdmin && (
                  <td className="px-4 py-2 border text-center">
                    <button
                      onClick={() => handleDelete(author.id)}
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
            <label className="block mb-1 font-semibold">Yazar Adı</label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="w-full border px-3 py-2 rounded"
              required
              placeholder="Yazar adı giriniz"
            />
          </div>
          <div>
            <label className="block mb-1 font-semibold">Biyografi</label>
            <textarea
              value={bio}
              onChange={(e) => setBio(e.target.value)}
              className="w-full border px-3 py-2 rounded"
              placeholder="Biyografi giriniz (opsiyonel)"
              rows={3}
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

export default Authors;
