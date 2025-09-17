using ImageMagick;
using Pdf2Image;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoder = System.Drawing.Imaging.Encoder;

namespace resimkucult
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.WriteAllBytes(Application.StartupPath + @"\gsdll64.dll", Properties.Resources.gsdll64);
            File.WriteAllBytes(Application.StartupPath + @"\gswin64c.exe", Properties.Resources.gswin64c);
        }
        FileInfo dosya;

        public string newFileName { get; private set; }
        public int newWidth { get; private set; }
        public int newHeight { get; private set; }
        public string SecilenPath { get; private set; }
        public string SecilenKlasor { get; private set; }

        [Obsolete]
        private async void btnkucult_Click(object sender, EventArgs e)
        {
            if (!chckBmptoJpg.Checked && !chckkucult.Checked && !chckHeicJpg.Checked && !chckPDF.Checked && !radioButton45Sag.Checked && !radioButton45Sol.Checked)
            {
                MessageBox.Show("Lütfen bir işlem seçiniz!");
                return;
            }

            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (DialogResult.Cancel == dr)
            {
                return;
            }
            txtList.Text = "İşlem yapılıyor!";
            await Task.Delay(1000);

            var SecilenDirectory = folderBrowserDialog1.SelectedPath;
            await islemyap(SecilenDirectory);
            await Task.Delay(1000);
            txtList.Text = "İşlem tamamlandı!";
        }

        private readonly SemaphoreSlim _pdfSemaphore = new SemaphoreSlim(1, 1);

        [Obsolete]
        private async Task RunProcessAsync(string fileName, string arguments)
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (var p = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                var tcs = new TaskCompletionSource<int>();
                p.OutputDataReceived += (s, e) => { if (!string.IsNullOrEmpty(e.Data)) Log($"[{fileName}] {e.Data}"); };
                p.ErrorDataReceived += (s, e) => { if (!string.IsNullOrEmpty(e.Data)) Log($"[{fileName} ERR] {e.Data}"); };

                if (!p.Start())
                    throw new InvalidOperationException($"{fileName} başlatılamadı.");

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                p.Exited += (s, e) => tcs.TrySetResult(p.ExitCode);
                int exit = await tcs.Task;

                if (exit != 0)
                    throw new Exception($"{fileName} çıkış kodu: {exit}");
            }
        }

        [Obsolete]
        private async Task ConvertPdfWithGhostscriptAsync(string pdfPath, string outputRoot, int dpi = 200, int quality = 85)
        {
            string nameNoExt = Path.GetFileNameWithoutExtension(pdfPath);
            string outPattern = Path.Combine(outputRoot, nameNoExt + "_p%03d.jpg");

            // -dJPEGQ=85 kalite, -r200 DPI, -sDEVICE=jpeg, -o out_p%03d.jpg
            string args = $"-dNOPAUSE -dBATCH -sDEVICE=jpeg -dJPEGQ={quality} -r{dpi} -o \"{outPattern}\" \"{pdfPath}\"";

            await RunProcessAsync("gswin64c", args);
        }
        private async Task islemyap(string rootFolder)
        {
            if (string.IsNullOrWhiteSpace(rootFolder) || !Directory.Exists(rootFolder))
            {
                MessageBox.Show("Geçerli bir klasör seçmedin.");
                return;
            }

            txtList.Text = "";
            Log($"Seçilen klasör: {rootFolder}");

            string parent = Path.GetDirectoryName(rootFolder);
            string folderName = Path.GetFileName(rootFolder);
            string outputRoot = Path.Combine(parent ?? "", folderName + "_jpg");

            // Kök + alt klasörler
            var tumKlasorler = Directory.EnumerateDirectories(rootFolder, "*", SearchOption.AllDirectories)
                                        .Prepend(rootFolder);

            foreach (var klasor in tumKlasorler)
            {
                Log($"▶ Klasör: {klasor}");

                if (chckPDF.Checked)
                {
                    Directory.CreateDirectory(outputRoot);

                    var pdfler = Directory.EnumerateFiles(klasor, "*.pdf", SearchOption.TopDirectoryOnly);
                    foreach (var pdf in pdfler)
                    {
                        try
                        {
                            // Önce ImageMagick dene, yoksa Ghostscript'e düş
                            try
                            {
                                await ConvertPdfWithGhostscriptAsync(pdf, outputRoot, dpi: 200, quality: 85);
                            }
                            catch (Exception)
                            {
                                //await ConvertPdfWithMagickAsync(pdf, outputRoot, dpi: 200, quality: 85);
                            }

                            Log($"  ✓ {Path.GetFileName(pdf)} dönüştürüldü.");
                        }
                        catch (Exception ex)
                        {
                            Log($"  ✗ {Path.GetFileName(pdf)} hata: {ex.Message}");
                        }
                    }
                }

                // Diğer işlemlerin (HEIC→JPG, BMP→JPG, küçültme, 45° çevir) aynen kalabilir
                try
                {
                    if (chckHeicJpg.Checked) await Task.Run(() => islem(klasor));
                    if (chckBmptoJpg.Checked) await Task.Run(() => islem("bmp", klasor));
                    if (chckkucult.Checked) await Task.Run(() => islem("kucult", klasor));
                    if (radioButton45Sag.Checked) await Task.Run(() => islem("sagacevir", klasor));
                    if (radioButton45Sol.Checked) await Task.Run(() => islem("solacevir", klasor));
                }
                catch (Exception ex2)
                {
                    Log(" - İşlem hatası: " + ex2.Message);
                }
            }

            Log("✅ Tamam: " + outputRoot);
        }

        // UI log helper
        private void Log(string msg)
        {
            if (txtList.InvokeRequired)
            {
                txtList.BeginInvoke(new Action(() =>
                {
                    txtList.AppendText(msg + Environment.NewLine);
                }));
            }
            else
            {
                txtList.AppendText(msg + Environment.NewLine);
            }
        }

        private void islem(string islem, string klasor)
        {
            try
            {
                int targetWidth = 1024;
                int targetHeight = 768;
                string folderPath = klasor; // Resim dosyalarının bulunduğu klasörün yolu
                                            // Klasördeki tüm jpg dosyalarını al
                                            //string[] files = Directory.GetFiles(folderPath, "*.*")
                                            //                       .Where(file => file.ToLower().EndsWith("jpeg") ||
                                            //                                      file.ToLower().EndsWith("jpg") ||
                                            //                                      file.ToLower().EndsWith("png"))
                                            //                       .ToArray();
                string[] seçilendosya = Directory.GetFiles(klasor);
                foreach (string file in seçilendosya)
                {
                    //File.Move(file, file.Replace(".jpeg", ".jpg"));
                    string tempFileName = Path.Combine(folderPath, "temp_" + Path.GetFileName(file));

                    using (Bitmap bitmap = new Bitmap(file))
                    {

                        if (islem == "bmp")
                        {

                            // Klasördeki tüm BMP dosyalarını al
                            string[] bmpDosyalar = Directory.GetFiles(klasor, "*.bmp", SearchOption.TopDirectoryOnly);

                            foreach (string bmpYolu in bmpDosyalar)
                            {
                                try
                                {
                                    // Dosya adı (uzantısız)
                                    string dosyaAdi = Path.GetFileNameWithoutExtension(bmpYolu);

                                    // Hedef jpg yolu
                                    Directory.CreateDirectory(klasor + @"\jpg");
                                    string jpgYolu = Path.Combine(klasor + @"\jpg", dosyaAdi + ".jpg");

                                    // BMP'yi yükle ve JPG olarak kaydet
                                    using (Image img = Image.FromFile(bmpYolu))
                                    {
                                        img.Save(jpgYolu, ImageFormat.Jpeg);
                                    }

                                    Console.WriteLine($"Dönüştürüldü: {bmpYolu} → {jpgYolu}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata ({bmpYolu}): {ex.Message}");
                                }
                            }
                        }
                        else if (islem == "kucult")
                        {
                            if (bitmap.Width > bitmap.Height) // Yatay form
                            {
                                newWidth = targetWidth;
                                newHeight = (int)(bitmap.Height * (float)targetWidth / bitmap.Width);
                            }
                            else // Dikey form
                            {
                                newHeight = targetHeight;
                                newWidth = (int)(bitmap.Width * (float)targetHeight / bitmap.Height);
                            }
                            // Yeni boyutları hesapla (%50 oranında küçültme)
                            //newWidth = (int)(bitmap.Width * 0.5);
                            //newHeight = (int)(bitmap.Height * 0.5);

                            bitmap.Save(tempFileName);
                        }
                        else
                        {
                            newWidth = (int)(bitmap.Width);
                            newHeight = (int)(bitmap.Height);
                        }

                        using (Bitmap newBitmap = new Bitmap(bitmap, newWidth, newHeight)) //boyut değiştir
                        {
                            if (islem == "sagacevir")
                            {
                                newBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            }
                            if (islem == "solacevir")
                            {
                                newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            }


                            ImageCodecInfo jpgEncoder;
                            EncoderParameters encoderParameters;
                            if (islem == "kucult")
                            {
                                jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                                encoderParameters = new EncoderParameters(1);
                                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 90L);
                                encoderParameters.Param[0] = qualityParam;
                            }
                            else
                            {
                                jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                                encoderParameters = new EncoderParameters(1);
                                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 90L);
                                encoderParameters.Param[0] = qualityParam;
                            }
                            newBitmap.SetResolution(100, 100);
                            newFileName = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(file) + ".jpg");
                            //newBitmap.SetResolution((float)newWidth, (float)newHeight); //çözünürlük değiştir
                            newBitmap.Save(tempFileName, jpgEncoder, encoderParameters);
                        }
                    }
                    // Orijinal dosyayı sil
                    File.Delete(file);

                    // Geçici dosyayı orijinal dosya adıyla yeniden adlandır
                    File.Move(tempFileName, newFileName);

                }
                txtList.Text = "İşlem Tamamlandı..";
            }
            catch { }
        }

        private void islem(string klasor)
        {
            try
            {
                string folderPath = klasor; // Resim dosyalarının bulunduğu klasörün yolu


                // HEIC dosyalarının bulunduğu klasör
                string inputFolder = klasor;
                // JPG'lerin kaydedileceği klasör
                string outputFolder = Path.Combine(inputFolder, "jpg");

                //// Çıktı klasörünü oluştur
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // HEIC dosyalarını bul
                string[] heicFiles = Directory.GetFiles(inputFolder, "*.heic", SearchOption.TopDirectoryOnly);

                if (heicFiles.Length == 0)
                {
                    Console.WriteLine("❌ HEIC dosyası bulunamadı.");
                    return;
                }

                foreach (var heicPath in heicFiles)
                {
                    try
                    {
                        using (MagickImage image = new MagickImage(heicPath))
                        {
                            image.Format = MagickFormat.Jpeg;
                            string fileName = Path.GetFileNameWithoutExtension(heicPath);
                            string outputPath = Path.Combine(outputFolder, fileName + ".jpg");

                            image.Write(outputPath);

                            Console.WriteLine($"✅ Dönüştürüldü: {fileName}.jpg");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Hata ({Path.GetFileName(heicPath)}): {ex.Message}");
                    }
                }

                Console.WriteLine("🎉 Tüm dönüştürmeler tamamlandı.");


                txtList.Text = "İşlem Tamamlandı..";
            }
            catch { txtList.Text = "Hata Oluştu!"; }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].MimeType == mimeType)
                {
                    return codecs[i];
                }
            }
            return null;
        }

        private void chckkucult_Click(object sender, EventArgs e)
        {

        }

        private void chckPDF_Click(object sender, EventArgs e)
        {
            chckkucult.Checked = false;
        }
    }
}
