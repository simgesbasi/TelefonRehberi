using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu hareketler = new Menu();
           
            bool cikis = true;
            while (cikis)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("******************************************* \n(1) Yeni Numara Kaydetmek \n(2) Varolan Numarayı Silmek \n(3) Varolan Numarayı Güncelleme \n(4) Rehberi Listelemek \n(5) Rehberde Arama Yapmak");

                int girilenSayi = int.Parse(Console.ReadLine());

                switch (girilenSayi)
                {
                    case 1:
                        hareketler.yeniNumaraKaydet();
                        Console.WriteLine("*******************************************");
                        break;
                    case 2:
                        hareketler.numaraSil();
                        Console.WriteLine("*******************************************");
                        break;
                    case 3:
                        hareketler.numaraGuncelle();
                        Console.WriteLine("*******************************************");
                        break;
                    case 4:
                        hareketler.rehberiListele();
                        Console.WriteLine("*******************************************");
                        break;
                    case 5:
                        hareketler.rehberdeAramaYap();
                        Console.WriteLine("*******************************************");
                        break;
                    default:
                        Console.WriteLine("Gecersiz deger girildi. Cikis yapiliyor.");
                        cikis = false;
                        break;
                }
            }
            Console.ReadKey();
        }
    }





}
