import { useEffect, useState, useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { getBooks } from "../services/bookService";
import { useNavigate } from "react-router-dom";

const Books = () => {
  const { role } = useContext(AuthContext);
  const [books, setBooks] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  const isPrivileged = role === "Admin" || role === "Employee";

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const res = await getBooks(isPrivileged);
        setBooks(res.data);
      } catch (error) {
        console.error("Kitaplar alınamadı:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchBooks();
  }, [role]);

  if (loading) return <div className="text-center mt-10">Yükleniyor...</div>;

  return (
    <div className="max-w-6xl mx-auto mt-10 p-6 bg-white shadow rounded">
      <h1 className="text-3xl font-bold mb-6">Kitaplar</h1>
      {books.length === 0 ? (
        <p className="text-gray-600">Hiç kitap bulunamadı.</p>
      ) : (
        <>
          <table className="w-full table-auto border-collapse">
            <thead>
              <tr className="bg-gray-100 text-left">
                <th className="p-3 border-b text-center">Başlık</th>
                <th className="p-3 border-b text-center">Yazar</th>
                <th className="p-3 border-b text-center">Kategori</th>
                <th className="p-3 border-b text-center">Yayınevi</th>
                <th className="p-3 border-b text-center">ISBN</th>
                <th className="p-3 border-b text-center">Yayın Tarihi</th>
                {isPrivileged && (
                  <th className="p-3 border-b text-center">Silinme Durumu</th>
                )}
              </tr>
            </thead>
            <tbody>
              {books.map((book) => (
                <tr
                  key={book.id}
                  onClick={() => navigate(`/books/${book.id}`)}
                  className="cursor-pointer hover:bg-gray-100"
                >
                  <td className="px-4 py-2 border text-center">{book.title}</td>
                  <td className="px-4 py-2 border text-center">
                    {book.author?.name || "-"}
                  </td>
                  <td className="px-4 py-2 border text-center">
                    {book.category?.name || "-"}
                  </td>
                  <td className="px-4 py-2 border text-center">
                    {book.publisher?.name || "-"}
                  </td>
                  <td className="px-4 py-2 border text-center">{book.isbn}</td>
                  <td className="px-4 py-2 border text-center">
                    {new Date(book.publicationDate).toLocaleDateString("tr-TR")}
                  </td>
                  {isPrivileged && (
                    <td className="p-3 border-b text-center">
                      {book.isDeleted ? "Silindi" : "Silinmedi"}
                    </td>
                  )}
                </tr>
              ))}
            </tbody>
          </table>
          <p className="text-gray-600 mt-4">{books.length} kitap listeleniyor.</p>
        </>
      )}
    </div>
  );
};

export default Books;
