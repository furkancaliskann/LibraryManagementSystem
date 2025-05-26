import { useEffect, useState, useContext } from "react";
import { getCategories, addCategory, deleteCategory } from "../services/categoryService";
import { AuthContext } from "../context/AuthContext";

const Categories = () => {
  const { role } = useContext(AuthContext);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [name, setName] = useState("");

  const isAdmin = role === "Admin";

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const res = await getCategories();
        setCategories(res.data || []);
      } catch (error) {
        console.error("Kategoriler alınamadı:", error);
        setCategories([]);
      } finally {
        setLoading(false);
      }
    };

    fetchCategories();
  }, [role]);

  const handleAdd = async (e) => {
    e.preventDefault();
    if (!name.trim()) return;

    try {
      await addCategory({ name });
      setName("");
      const res = await getCategories();
      setCategories(res.data || []);
    } catch (error) {
      console.error("Kategori eklenemedi:", error);
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Silmek istediğinize emin misiniz?")) return;

    try {
      await deleteCategory(id);
      setCategories(categories.filter((category) => category.id !== id));
    } catch (error) {
      console.error("Kategori silinemedi:", error);
    }
  };

  if (loading) return <div className="text-center mt-10">Yükleniyor...</div>;

  return (
    <div className="max-w-4xl mx-auto mt-10 p-6 bg-white shadow rounded">
      <h1 className="text-3xl font-bold mb-6">Kategoriler</h1>

      {categories.length === 0 ? (
        <p className="text-gray-600 mb-6">Hiç kategori bulunamadı.</p>
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
            {categories.map((category) => (
              <tr key={category.id} className="hover:bg-gray-50">
                <td className="px-4 py-2 border text-center">{category.id}</td>
                <td className="px-4 py-2 border text-center">{category.name}</td>
                {isAdmin && (
                  <td className="px-4 py-2 border text-center">
                    <button
                      onClick={() => handleDelete(category.id)}
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
            <label className="block mb-1 font-semibold">Kategori Adı</label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="w-full border px-3 py-2 rounded"
              required
              placeholder="Kategori adı giriniz"
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

export default Categories;
