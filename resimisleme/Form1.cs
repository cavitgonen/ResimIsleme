using ImageMagick;
using Pdf2Image;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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


            if (!chckkucult.Checked && !chckHeicJpg.Checked && !chckPDF.Checked && !radioButton45Sag.Checked && !radioButton45Sol.Checked)
            {
                MessageBox.Show("Lütfen bir işlem seçiniz!");
                return;
            }

            openFileDialog1.FileName = string.Empty;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (DialogResult.Cancel == dr)
            {
                return;
            }
            txtList.Text = "İşlem yapılıyor!";
            await Task.Delay(1000);
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.heic;*.pdf|Tüm Dosyalar|*.*";
            openFileDialog1.Title = "Resim Dosyası Seçiniz";

            var SecilenFile = openFileDialog1.FileName;
            var SecilenFiles = openFileDialog1.FileNames;
            SecilenKlasor = Path.GetDirectoryName(SecilenFile);
            await islemyap(SecilenFiles, SecilenKlasor);
            await Task.Delay(1000);
            txtList.Text = "İşlem tamamlandı!";
        }

        [Obsolete]
        private async Task islemyap(string[] files, string klasor)
        {
            txtList.Text = "";
            if (chckkucult.Checked)
            {
                islem("kucult", files, klasor);
            }
            else if (chckHeicJpg.Checked)
            {
                islem(klasor);
            }
            else
            {

                if (chckPDF.Checked)
                {
                    string outputDir = Path.Combine(klasor, "jpg");
                    if (!Directory.Exists(outputDir))
                        Directory.CreateDirectory(outputDir);

                    foreach (string file in files)
                    {
                        if (!file.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                            continue;

                        try
                        {
                            // Belleğe tüm sayfaları ALMADAN diske yazdırır:
                            PdfSplitter.WriteImages(
                                file,
                                outputDir,
                                PdfSplitter.Scale.High,                 // kalite/dpi ayarı
                                PdfSplitter.CompressionLevel.Medium     // dosya boyutu/kalite dengesi
                            );
                        }
                        catch (Exception ex)
                        {
                            // İsteğe bağlı loglayın
                            Console.WriteLine($"PDF dönüştürme hatası: {Path.GetFileName(file)} -> {ex.Message}");
                        }

                        // Çok uzun işlerde atık topla (zorunlu değil ama faydalı olabilir)
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }


            }

            if (radioButton45Sag.Checked)
            {
                islem("sagacevir", files, klasor);
            }
            if (radioButton45Sol.Checked)
            {
                islem("solacevir", files, klasor);
            }
        }
        private void islem(string islem, string[] files, string klasor)
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

                foreach (string file in files)
                {
                    //File.Move(file, file.Replace(".jpeg", ".jpg"));
                    string tempFileName = Path.Combine(folderPath, "temp_" + Path.GetFileName(file));

                    using (Bitmap bitmap = new Bitmap(file))
                    {
                        if (islem == "kucult")
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
            catch { txtList.Text = "Hata Oluştu!"; }
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

                // Çıktı klasörünü oluştur
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
