export const parseJwt = (token) => {
  try {
    if (!token) {
      throw new Error('Geçersiz token');
    }
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(
      atob(base64)
        .split('')
        .map(function (c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join('')
    );

    return JSON.parse(jsonPayload);
  } catch (e) {
    console.error('Token hatası:', e);
    return null; // Hatalı token için null döner
  }
};
