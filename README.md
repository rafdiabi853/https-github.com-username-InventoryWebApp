# 📦 Inventory Web App

Aplikasi web manajemen inventaris berbasis **ASP.NET Web Forms (C#)** dan **SQL Server** untuk mengelola data barang secara efisien dan terstruktur.

---

## 🚀 Fitur Utama

- **Dashboard Ringkasan Statis:** Menampilkan total item, total stok keseluruhan, dan peringatan otomatis untuk stok menipis/habis (< 5 unit).
- **Manajemen Data Barang (CRUD):**
  - **Tambah Barang:** Input kode barang, nama, kategori, jumlah stok, dan harga.
  - **Lihat & Cari Barang:** Pencarian cepat data barang berdasarkan nama atau kode barang.
  - **Ubah & Hapus Data:** Pembaruan dan penghapusan data barang langsung dari tabel inventaris.
- **Sistem Autentikasi:** Fitur Login dan Register pengguna.

---

## 🛠️ Teknologi yang Digunakan

- **Language:** C#
- **Framework:** ASP.NET Web Forms (.NET Framework)
- **Database:** Microsoft SQL Server
- **UI/UX:** HTML5, CSS3, Bootstrap 5

---

## 📁 Struktur Project

```text
InventoryWebApp/
├── DataBarang.aspx         # Halaman utama kelola data barang
├── DataBarang.aspx.cs      # Logic C# (CRUD & statistik dashboard)
├── Login.aspx              # Halaman login
├── Register.aspx           # Halaman pendaftaran akun
└── Web.config              # Konfigurasi aplikasi & database connection string
