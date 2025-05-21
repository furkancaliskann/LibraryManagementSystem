import { useEffect, useState } from "react";
import { parseJwt } from "../utils/jwtUtils";
import { getUserById, updateUser } from "../services/userService";

const Profile = () => {
  const [user, setUser] = useState(null);
  const [editableFields, setEditableFields] = useState({});
  const [editedUser, setEditedUser] = useState({});
  const [hasChanges, setHasChanges] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    const decoded = parseJwt(token);
    const userId = decoded?.nameid;

    if (userId) {
      getUserById(userId).then((res) => {
        const userData = res.data;
        setUser(userData);
        setEditedUser({
          Name: userData.name,
          Surname: userData.surname,
          Email: userData.email,
          Phone: userData.phone,
          Address: userData.address || "",
          CurrentPassword: "",
          NewPassword: ""
        });
      });
    }
  }, []);

  const toggleEdit = (field) => {
    setEditableFields((prev) => ({
      ...prev,
      [field]: !prev[field],
    }));
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedUser((prev) => ({ ...prev, [name]: value }));
    setHasChanges(true);
  };

  const handleUpdate = async () => {
    if (!editedUser.CurrentPassword) {
      alert("Lütfen mevcut şifrenizi girin.");
      return;
    }

    try {
      await updateUser(editedUser);
      alert("Bilgiler başarıyla güncellendi.");
      setHasChanges(false);
    } catch (err) {
      console.error(err);
      alert("Güncelleme başarısız oldu.");
    }
  };

  if (!user) return <div>Yükleniyor...</div>;

  return (
    <div className="max-w-xl mx-auto p-6 bg-white shadow rounded-xl mt-10 space-y-6">
      <h1 className="text-2xl font-bold mb-4">Profil Bilgileri</h1>

      {["Name", "Surname", "Email", "Phone", "Address"].map((field) => (
        <div key={field} className="flex items-center justify-between">
          <label className="w-24 font-medium">{field}:</label>
          <input
            type="text"
            name={field}
            value={editedUser[field] || ""}
            onChange={handleChange}
            disabled={!editableFields[field]}
            className={`border p-2 rounded w-full ml-2 ${
              editableFields[field] ? "bg-white" : "bg-gray-100"
            }`}
          />
          <button
            onClick={() => toggleEdit(field)}
            className="ml-2 text-blue-600 hover:underline"
          >
            {editableFields[field] ? "Kapat" : "Düzenle"}
          </button>
        </div>
      ))}

      <div className="flex items-center justify-between">
        <label className="w-24 font-medium">Mevcut Şifre:</label>
        <input
          type="password"
          name="CurrentPassword"
          value={editedUser.CurrentPassword}
          onChange={handleChange}
          className="border p-2 rounded w-full ml-2 bg-white"
          required
        />
      </div>

      <div className="flex items-center justify-between">
        <label className="w-24 font-medium">Yeni Şifre: (Opsiyonel)</label>
        <input
          type="password"
          name="NewPassword"
          value={editedUser.NewPassword}
          onChange={handleChange}
          className="border p-2 rounded w-full ml-2 bg-white"
        />
      </div>

      <button
        onClick={handleUpdate}
        disabled={!hasChanges}
        className={`mt-4 w-full p-2 rounded text-white ${
          hasChanges ? "bg-blue-600 hover:bg-blue-700" : "bg-gray-400 cursor-not-allowed"
        }`}
      >
        Güncelle
      </button>
    </div>
  );
};

export default Profile;
