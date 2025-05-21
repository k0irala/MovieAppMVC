# 🎬 **Movie App - User Role Based Movie Management System**

## 🔍 **Overview**
**Movie App** is a role-based web application built with **ASP.NET Core MVC**. It allows users to securely log in, view, and manage movie records based on their roles using session-based authentication.

---

## 🚀 **Key Features**

### 👤 **User Authentication & Authorization**
- **Login system** using session-based security.
- **Role-based access control** (e.g., `Admin`, `User`).
- **Logout button** appears only when the user is logged in.

### 🎞️ **Movie Management**
- **Users** can:
  - View movie listings
  - Add new movies *(if authorized)*

- **Admins** can:
  - Edit and delete movies
  - Manage user accounts

### 🔒 **Session Handling**
- All pages are **protected with session validation**.
- Unauthorized access is redirected to a custom **Access Denied** page.

### 👁️ **UI Enhancements**
- **"Show Password"** toggle using eye icon 👁️.
- **Dynamic navigation bar** changes based on login status and user role.
- **Clean, responsive UI** with Bootstrap and Font Awesome.

### 🧭 **Navigation & UX**
- Dynamic navbar:
  - 🎥 **"Movie App" branding** appears only when logged in.
  - 🚪 **"Logout" button** appears on the far right (hidden on login page).
- Friendly redirects and informative error messages.

---

## 🛠️ **Tech Stack**

- **Frontend:** HTML, Razor, Bootstrap 5, Font Awesome  
- **Backend:** ASP.NET Core MVC  
- **Session Storage:** ASP.NET Core Session Middleware  
- **Security:** Custom session validation filter

---

## 📦 **Future Improvements**

- ⭐ Movie ratings and reviews  
- 🖼️ Poster image uploads  
- 🔎 Search & filter features  
- ⚙️ Role management via Admin panel

---
