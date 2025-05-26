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

  const handleSubmit = async (e) => {
    e.preventDefault();

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

  // AutoComplete map
  const autoCompleteMap = {
    Name: "given-name",
    Surname: "family-name",
    Email: "email",
    Phone: "tel",
    Address: "street-address",
  };

  return (
    <div className="max-w-xl mx-auto p-6 bg-white shadow rounded-xl mt-10 space-y-6">
      <h1 className="text-2xl font-bold mb-4">Profil Bilgileri</h1>

      <form onSubmit={handleSubmit} className="space-y-4" autoComplete="on">
        {["Name", "Surname", "Email", "Phone", "Address"].map((field) => (
          <div key={field} className="flex items-center justify-between">
            <label htmlFor={field} className="w-24 font-medium">{field}:</label>
            <input
              id={field}
              type="text"
              name={field}
              value={editedUser[field] || ""}
              onChange={handleChange}
              disabled={!editableFields[field]}
              autoComplete={autoCompleteMap[field]}
              className={`border p-2 rounded w-full ml-2 ${
                editableFields[field] ? "bg-white" : "bg-gray-100"
              }`}
            />
            <button
              type="button"
              onClick={() => toggleEdit(field)}
              className="ml-2 text-blue-600 hover:underline"
            >
              {editableFields[field] ? "Kapat" : "Düzenle"}
            </button>
          </div>
        ))}

        <div className="flex items-center justify-between">
          <label htmlFor="CurrentPassword" className="w-24 font-medium">Mevcut Şifre:</label>
          <input
            id="CurrentPassword"
            type="password"
            name="CurrentPassword"
            value={editedUser.CurrentPassword}
            onChange={handleChange}
            className="border p-2 rounded w-full ml-2 bg-white"
            required
            autoComplete="current-password"
          />
        </div>

        <div className="flex items-center justify-between">
          <label htmlFor="NewPassword" className="w-24 font-medium">Yeni Şifre:</label>
          <input
            id="NewPassword"
            type="password"
            name="NewPassword"
            value={editedUser.NewPassword}
            onChange={handleChange}
            className="border p-2 rounded w-full ml-2 bg-white"
            autoComplete="new-password"
          />
        </div>

        <button
          type="submit"
          disabled={!hasChanges}
          className={`mt-4 w-full p-2 rounded text-white ${
            hasChanges ? "bg-blue-600 hover:bg-blue-700" : "bg-gray-400 cursor-not-allowed"
          }`}
        >
          Güncelle
        </button>
      </form>
    </div>
  );
};

export default Profile;
