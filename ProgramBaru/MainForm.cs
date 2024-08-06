namespace ProgramBaru

{
    public partial class MainForm : Form
    {
        /* 
          Membuat variable bersifat private, statik, dan readonly (gak bisa diedit atau const)
          Variable tersebut membuat objek class "HttpClient" library yang disediin oleh C#
          (https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-8.0
        */
        private static readonly HttpClient client = new HttpClient();

        //Constructor (akan dijalankan sekali saja)
        public MainForm()
        {
            /* 
               Menginisialisasi / siapin komponen di aplikasi kita
               Contohnya, nyiapin tombol-tombol, input, teks, dll & naruh ditempatnya
            */
            InitializeComponent();

            // Menetapkan window aplikasi kita biar ada di tengah layar (biar gak nyasar)
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /* 
           Asynchronous / tdk sinkron artinya bisa menjalankan yang kode lain jika satu kode
           masih belum selesai. Atau dengan sengaja, bisa menunggu sebuah kode selesai dulu baru 
           jalanin yang selanjutnya, biar nunggu datanya ada dulu baru jalan. Tanpa async, tidak
           kode yang akan menunggu tunggu dan tetap jalan sesuai urutan 
           (gak ngurus & sak karepe dewe).
        */

        // Fungsi yang otomatis akan dipanggil jika kita klik tombolnya
        private async void button1_Click(object sender, EventArgs e)
        {
            // Mengambil data dari textbox "inputUrl" yang kita buat di Form Designer
            string url = inputUrl.Text;
            // Mengambil data dari textbox "fileNameInput" yang kita buat di Form Designer
            string filePath = fileNameInput.Text;

            // Pertama, mencoba / menjalankan kode:
            try
            {
                // Menunggu file selesai dulu
                await DownloadFileAsync(url, filePath);
                // Jika selesai, tampilkan dialog notifikasi bahwa selesai.
                MessageBox.Show($"Download selesai! File disimpan dengan nama {filePath}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Jika gagal / menagkap error yang akan datang:
            catch (Exception ex) // Menggunakan parameter yang menangkap error tersebut
            {
                // Jika gagal, tampilkan dialog notifikasi bahwa gagal, serta alasan mengapa gagal.
                MessageBox.Show($"Download gagal \n\nPenyebab: {ex.Message}", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Membuat method tidak sinkron yang kita dapat pakai utk mendownload file dengan memasukan beberapa argumen (url, lokasi path)
        private static async Task DownloadFileAsync(string url, string filePath)
        {
            /*
              Membuat variable "Response" dimana menggunakan variable client yang kita buat paling atas tadi.
              Terus variable itu manggil method yang namanya "GetAsync" dimana melakukan proses download dengan
              http method "GET" dan kita menyertakan argument disini yang berfungsi untuk membaca response
              biar tau downloadtan kita sukses ato enggak, daripada nunggu semuanya kedownload utk lihat sukses 
              ato nggak
            */
            using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                // Memastikan code http sukses (200). Kalo enggak 200, nti downloadnya dibatalin terus kita keluarin error gagal.
                response.EnsureSuccessStatusCode();

                // Mengambil tipe data dari header "Content-Disposition" jika ada
                string fileName = null;
                if (response.Content.Headers.ContentDisposition != null) // jika tidak null / tidak kosong
                {
                    // Memasukan data ke variable "Filename" dan menghapus tanda kutip (") yang ada di header "Content-Disposition" agar tidak double kutipnya nanti.
                    fileName = response.Content.Headers.ContentDisposition.FileName.Trim('"');
                }
                else // klo ga ada, kita pakai header "Content-Type" dan mencocokannya di method "GetExtensionFromContentType" utk mengubahnya menjadi filetype yg bener
                {
                    // Baca header "Content-Type"
                    var contentType = response.Content.Headers.ContentType.MediaType; 

                    // Manggil method "GetExtensionFromContentType" dengan header "Content-Type" yang kita simpen diatas tadi
                    var extension = GetExtensionFromContentType(contentType);

                    // Memasukan data ke variable "Filename" dengan data yg didapat dari proses yg kita lakukan diatas tadi.
                    fileName = Path.GetFileNameWithoutExtension(filePath) + extension;
                }

                // Menggabukan direktori "variable filePath dengan nama file"
                var fullPath = Path.Combine(Path.GetDirectoryName(filePath), fileName);

                /* 
                  Membuat variable "stream" dimana dia yang membaca data file yang didapatin
                  dari hasil downloadtan tadi terus sementara disimpen di memory / RAM / variabel
                */
                using (var stream = await response.Content.ReadAsStreamAsync())

                // Membuat objek "FileStream" yang memasukan argument:

                //                                     Lokasi dmn kita akan save             Mode File               Hak akses agar program kita bisa edit          Hak Akses Agar program lain tdk bisa mengeditnya     Ukuran Buffer      Apakah tdk sinkron / asynchronous?
                using (var fileStream = new System.IO.FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None, 8192, true))
                {
                    await stream.CopyToAsync(fileStream);
                    /*
                      Menempatkan "data file" yang ada di variable "stream" terus dijadiin
                      Menempatkan "data file" yang ada di variable "stream" terus dijadiin
                      file asli / beneran menggunakan method objek FileStream. 

                      Disini FileStream ini cuman ngebaca data yang kita simpen di variable "stream" 
                      tadi terus itu diubah dan dijadiin file asli 
                      (sebelumnya itu, data yg ada di variabel "stream" itu isinya teks-teks yg ga jelas)
                      Terus data yg ga jelas itu tadi dimasukin ke lokasi file yang kita mauiin, diproses & simpan
                      jadi file beneran dengan file ekstensi yang sesuai.
                    */
                }
            }
        }
        private static string GetExtensionFromContentType(string contentType)
        {
            // Deklarasi objek "Dictonary" yang pasangannya string dengan string
            // Dictionary itu cuman array yang berpasangan dengan 2 data. Contohnya {"nama": "zahran"}
            // "nama" adalah data ke1, "zahran" adalah data ke2
            var contentTypes = new Dictionary<string, string>
            {
                { "image/jpeg", ".jpg" },
                { "image/png", ".png" },
                { "application/pdf", ".pdf" },
                { "text/html", ".html" },
                { "application/zip", ".zip" },
                { "application/rar", ".rar" }
                // Dapat ditambahkan lebih banyak lagi
            };

            // Mengambil data dari Dictionary yang kita buat tadi dan mengembalikan value file ekstensi yg benar. Jika tidak ada di Dictionary, akan keluar kosongan.
            return contentTypes.TryGetValue(contentType, out var extension) ? extension : string.Empty;
        }

    }
}
