# Thermal Printer Application

Aplikasi Windows Forms sederhana untuk mengendalikan thermal printer dengan protokol ESC/POS. Dibangun menggunakan C# .NET 8.0 dan Visual Studio 2022.

## Spesifikasi Printer yang Didukung

* **Tipe Printer**: Thermal Printer
* **Kecepatan Cetak**: 50-80 mm/detik
* **Kerapatan Cetak**: 8 titik/mm, 384 titik/garis
* **Lebar Cetak**: 48 mm
* **Lebar Kertas**: 57 mm
* **Lingkar Kertas Max**: 40 mm
* **Ketebalan Kertas Max**: 60-80 μm
* **Dimensi Produk (P×L×T)**: 75 × 103 × 45 mm
* **Karakter Cetak**: ANK 8×16, 9×17, 9×24, 12×24, GBK 24×24
* **Karakter Garis**: ANK 48, 42, 32, GBK 24, 16
* **Cetak Barcode**:
   * **1D**: UPC-A, UPC-E, EAN-13, EAN-8, JAN-13, ISBN, ISSN, CODE 39/93/128, CODABAR, ITF25
   * **2D**: QR CODE
* **Antarmuka**: USB 2.0 + Bluetooth
* **Daya**: 1500mAH 7.4V
* **Potong Kertas**: Manual
* **Sistem**: ESC/POS
* **Temperatur**: 10-50°C

## Fitur Aplikasi

- Mendukung koneksi printer melalui USB, COM port, dan Bluetooth (implementasi dasar)
- Deteksi otomatis printer yang terhubung
- Cetak teks dengan berbagai format (bold, large, alignment)
- Cetak barcode 1D (CODE 39, CODE 128, EAN-13, UPC-A)
- Cetak QR Code
- Perintah feed dan cut paper

## Persyaratan Sistem

- Windows OS (Windows 10 atau yang lebih baru)
- .NET 8.0 Runtime 
- Visual Studio 2022 (untuk pengembangan)
- Printer termal yang mendukung protokol ESC/POS

## Cara Menginstal dan Menjalankan

### Menggunakan Source Code
1. Clone repository ini
2. Buka file solution ThermalPrinterApp.sln dengan Visual Studio 2022
3. Restore NuGet packages jika diminta
4. Build solution (Ctrl+Shift+B)
5. Jalankan aplikasi (F5)

### Menggunakan File Executable
1. Download file release terbaru
2. Ekstrak ke folder pilihan Anda
3. Jalankan ThermalPrinterApp.exe

## Struktur Kode

Aplikasi ini dirancang dengan pemisahan kode logika dan desain UI:

- **MainForm.cs** - Berisi logika aplikasi dan metode untuk mencetak
- **MainForm.Designer.cs** - Berisi kode untuk tampilan UI
- **RawPrinterHelper.cs** - Kelas pembantu untuk komunikasi langsung dengan printer
- **Program.cs** - Entry point aplikasi

## Cara Penggunaan

### Pengaturan Printer
1. Pilih printer dari dropdown list
2. Pilih metode koneksi (USB, Bluetooth, COM Port)
3. Klik **Test Connection** untuk memastikan printer terhubung dengan baik

### Cetak Teks
1. Masukkan teks yang ingin dicetak pada kotak teks
2. Pilih style teks (Bold, Large) dan alignment (Left, Center, Right)
3. Klik **Print Text** untuk mencetak teks

### Cetak Barcode/QR Code
1. Masukkan data barcode pada kotak teks Barcode/QR
2. Pilih tipe barcode (QR Code, CODE 39, CODE 128, EAN-13, UPC-A)
3. Klik **Print Barcode/QR** untuk mencetak barcode

### Cetak Semua
1. Klik **Print All** untuk mencetak teks dan barcode/QR secara bersamaan

### Feed & Cut Paper
1. Klik **Feed & Cut Paper** untuk mengeluarkan kertas dan memotong (untuk printer yang mendukung)

## Catatan Pengembangan

- Aplikasi ini menggunakan protokol ESC/POS yang kompatibel dengan sebagian besar thermal printer
- Implementasi Bluetooth masih dasar dan mungkin memerlukan kustomisasi lebih lanjut
- Kode disusun dengan pemisahan tanggung jawab (separation of concerns)
- RawPrinterHelper menggunakan P/Invoke untuk mengirim data langsung ke printer

## Pengembangan Lebih Lanjut

Anda dapat mengembangkan aplikasi ini dengan:
1. Menambahkan desain template struk/invoice
2. Mengimplementasikan preview hasil cetak
3. Menambahkan penyimpanan dan pemanggilan template 
4. Mendukung koneksi jaringan (TCP/IP)
5. Menambahkan pengaturan kerapatan cetak (DPI)
6. Mengimplementasikan pencetakan gambar

## Lisensi

Proyek ini dilisensikan di bawah lisensi MIT. Lihat file LICENSE untuk detailnya.

## Kontribusi

Kontribusi untuk pengembangan aplikasi ini sangat diterima. Silakan fork repository, lakukan perubahan, dan kirim pull request.
