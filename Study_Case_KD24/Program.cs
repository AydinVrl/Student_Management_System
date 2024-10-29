using System.Net.Http.Headers;
using System.Transactions;

namespace Aydin_Vural_KD_24
{
    internal class Program
    {
        private static List<string> isimler = new List<string>();
        private static List<string> soyisimler = new List<string>();
        private static List<int> ogrenciNolar = new List<int>();
        private static List<int> yaslar = new List<int>();
        private static List<double> notOrtalamalari = new List<double>();
        private static List<string> tumOgrenciler = new List<string>();
        static void Main(string[] args)
        {
       
            string islem;
            bool acikMi = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("/***** ÖĞRENCİ YÖNETİM SİSTEMİ *****/");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine("[1] - Tüm Öğrencileri Listele\n[2] - Yeni Öğrenci Ekle - Kaydet\n[3] - Öğrenci Sil\n[4] - Soyadına Göre Öğrenci Ara\n[5] - Çıkış");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Lütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                Console.ForegroundColor = ConsoleColor.White;
                islem = Console.ReadLine();
                switch (islem)
                {
                    case "1":
                        Console.Clear();
                        OgrencileriListele();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Adı: ");
                        isimler.Add(Console.ReadLine().Trim().ToUpper());

                        Console.Write("Soyadı: ");
                        soyisimler.Add(Console.ReadLine().Trim().ToUpper());

                        int ogrenciYasi = KullanicidanYasVeriAl();
                        yaslar.Add(ogrenciYasi);

                        int ogrenciNumarasi = OgrenciNumarasiKontrol();
                        ogrenciNolar.Add(ogrenciNumarasi);


                        double notOrt = NotOrtalamasiKontrol();
                        notOrtalamalari.Add(notOrt);

                        DosyaKaydet();

                        break;
                    case "3":
                        Console.Clear();
                        OgrenciSil();
                        break;
                    case "4":
                        Console.Clear();
                        SoyadinaGoreOgrenciAra();
                       
                        break;
                    case "5":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Çıkış Yapılıyor!..");

                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);                          
                            Console.Write("* ");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        acikMi = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hatalı giriş yaptınız!..");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (acikMi);






        }
        static int KullanicidanYasVeriAl()
        {
            int intSayi = 0;
            bool sayiMi;
            do
            {
                Console.Write("Yaşı: ");
                string strSayi = Console.ReadLine();
                sayiMi = int.TryParse(strSayi, out intSayi);

                if (!sayiMi)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş! Lütfen sadece sayı giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (intSayi < 0 || intSayi > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen doğru bir yaş aralığı giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!sayiMi || intSayi < 0 || intSayi > 100);

            return intSayi;
        }
        static int OgrenciNumarasiKontrol()
        {
            int sayi = 0;
            bool sayiMi;

            while (true)
            {
                Console.Write("Öğrenci numarasını giriniz: ");
                string strSayi = Console.ReadLine();
                sayiMi = int.TryParse(strSayi, out sayi);
                if (!sayiMi)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sadece sayı giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (strSayi.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Öğrenci numarası 4 haneli olmalıdır, lütfen doğru formatta giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (ogrenciNolar.Contains(sayi))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bu Öğrenci mevcut lütfen doğru numara giriniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }

            return sayi;
        }
        static int OgrenciNumarasiKontrol(string ogrenciNo)
        {
            int numara = 0;
            bool sayiMi;

            while (true)
            {            
                string strSayi = ogrenciNo;
                sayiMi = int.TryParse(strSayi, out numara);

                if (!sayiMi)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sadece sayı giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (strSayi.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Öğrenci numarası 4 haneli olmalıdır, lütfen doğru formatta giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            return numara;
        }
        static double NotOrtalamasiKontrol()
        {
            double not = 0;
            bool sayiMi = true;
            do
            {
                Console.Write("Not Ortalaması: ");
                string strSayi = Console.ReadLine();
                sayiMi = double.TryParse(strSayi, out not);
                if (!sayiMi)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sadece Sayı Giriniz!..");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!sayiMi);
            return not;
        }
        static void OgrencileriListele()
        {     
            string klasorYolu = @"C:\Users\Lenovo\Desktop\OgrenciListesi";
            string[] dosyalar = Directory.GetFiles(klasorYolu, "*.txt");

            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Öğrenci kaydı bulunamadı!..");
                Console.ForegroundColor= ConsoleColor.White;
                return;
            }
            foreach (string dosya in dosyalar)
            {
                string ogrenciBilgisi = File.ReadAllText(dosya);
                Console.WriteLine($"Öğrenci bilgisi:\n{ogrenciBilgisi}");

                Console.WriteLine(new string('*', 50));
            }
        }
        static void SoyadinaGoreOgrenciAra()
        {
            //List<string> soyisimler
            string klasorYolu = @"C:\Users\Lenovo\Desktop\OgrenciListesi";

            Console.Write("Aramak istediğiniz öğrencinin soyadını girin: ");
            string arananSoyad = Console.ReadLine().Trim().ToUpper();
            string[] dosyalar = Directory.GetFiles(klasorYolu, "*.txt");
            string bulunanDosya = "";

            foreach (string dosya in dosyalar)
            {
                //GetFileNameWithoutExtension => Dosya adını uzantısı olmadan alıyor.
                string dosyaAdi = Path.GetFileNameWithoutExtension(dosya);
                if (dosyaAdi.Contains(arananSoyad))
                {
                    bulunanDosya = dosya;
                    break;
                }
            }
            if (bulunanDosya != "")
            {
                string ogrenciBilgisi = File.ReadAllText(bulunanDosya);
                Console.WriteLine($"Öğrenci bilgisi:\n{ogrenciBilgisi}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{arananSoyad} soyadına sahip bir öğrenci dosyası bulunamadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void DosyaKaydet()
        {
            string klasorYolu = @"C:\Users\Lenovo\Desktop\OgrenciListesi";
            Directory.CreateDirectory(klasorYolu);

            for (int i = 0; i < ogrenciNolar.Count; i++)
            {
                string ogrenciBilgisi = $"{ogrenciNolar[i]}-{isimler[i]}-{soyisimler[i]}-{yaslar[i]}-{notOrtalamalari[i]}";
                string dosyaYolu = Path.Combine(klasorYolu, $"{ogrenciNolar[i]}-{isimler[i]}-{soyisimler[i]}.txt");
                File.WriteAllText(dosyaYolu, ogrenciBilgisi);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ogrenciNolar[i]} numaralı öğrenci başarıyla kaydedildi!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void OgrenciSil()
        {
            string klasorYolu = @"C:\Users\Lenovo\Desktop\OgrenciListesi";

            Console.Write("Silmek istediğiniz öğrencinin numarasını giriniz: ");
            string ogrNo = Console.ReadLine().Trim();
            OgrenciNumarasiKontrol(ogrNo);

            string[] dosyalar = Directory.GetFiles(klasorYolu, "*.txt");
            string bulunanDosya = "";

            foreach (string dosya in dosyalar)
            {
                //GetFileNameWithoutExtension => Dosya adını uzantısı olmadan alıyor.
                string dosyaAdi = Path.GetFileNameWithoutExtension(dosya);
                if (dosyaAdi.StartsWith(ogrNo))
                {
                    bulunanDosya = dosya;
                    break;
                }
            }
            if (bulunanDosya != "")
            {
                string ogrenciBilgisi = File.ReadAllText(bulunanDosya);
                Console.WriteLine($"Öğrenci bilgisi:\n{ogrenciBilgisi}");
                File.Delete(bulunanDosya);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{ogrNo} numaralı öğrenciye ait dosya başarıyla silindi.");
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ogrNo} numaralı öğrenciye ait bir dosya bulunamadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }

}

