using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Proje1
{
    public class Menu
    {
        List<Sabitler> telefonRehberi = new List<Sabitler>();

        public Menu()
        {
            telefonRehberi.Add(new Sabitler("Simge", "Subaşı", "05321865496"));
            telefonRehberi.Add(new Sabitler("Ezgi", "Subaşı", "05336698745"));
            telefonRehberi.Add(new Sabitler("Fatih", "Koç", "05396587412"));
            telefonRehberi.Add(new Sabitler("Sude", "Koç", "05383621548"));
            telefonRehberi.Add(new Sabitler("Dilek", "Korkut", "05365698742"));
        }

        public void yeniNumaraKaydet()
        {
            Console.Write("Lütfen kişi adını giriniz: "); String name = Console.ReadLine(); name = name.ToLower();
            Console.Write("Lütfen kişi soyadını giriniz: "); String surName = Console.ReadLine(); surName = surName.ToLower();
            Console.Write("Lütfen kişi numarasını giriniz: "); String number = Console.ReadLine();
            Sabitler sabitler = new Sabitler(name, surName, number);
            telefonRehberi.Add(sabitler);
            Console.WriteLine(name + " " + surName + " adlı kişi telefon rehberine başarıyla eklendi.");
        }

        public void numaraSil()
        {
            head:
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string delName = Console.ReadLine().ToLower();

            bool silindi = false;
            bool bulundu = false;
            while (!silindi)
            {
                for (int i = 0; i < telefonRehberi.Count; i++)
                {
                    if (telefonRehberi[i].Name.ToLower().Equals(delName) || telefonRehberi[i].SurName.ToLower().Equals(delName))
                    {
                        Console.WriteLine(telefonRehberi[i].Name + " " + telefonRehberi[i].SurName + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                        string cevap = Console.ReadLine().ToLower();
                        silindi = true;
                        while (silindi)
                        {
                            if (cevap == "y")
                            {
                                Console.WriteLine(telefonRehberi[i].Name + " " + telefonRehberi[i].SurName + " isimli kişi rehberden silindi..");
                                telefonRehberi.RemoveAt(i);
                                silindi = true;
                                bulundu = true;
                                break;
                            }
                            else if (cevap == "n")
                            {
                                Console.WriteLine("Herhangi bir işlem yapılmadı...");
                                silindi = true;
                                bulundu = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz değer girdiniz. Lütfen tekrar deneyiniz.");
                                cevap = Console.ReadLine().ToLower();                
                            }
                        }                       
                    }

                }
                if (!bulundu)
                {                   
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.Lütfen bir seçim yapınız.");
                    back:
                    Console.WriteLine("* Silme işlemini sonlandırmak için    : (1)\n* Yeniden denemek için              : (2)");
                    int deger = int.Parse(Console.ReadLine());

                    if (deger == 1)
                    {
                        break;
                    }
                    else if(deger == 2)
                    {
                        goto head;                      
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz değer girdiniz.");
                        goto back;
                    }
                }
            }
        }

        public void numaraGuncelle()
        {
            head:
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string delName = Console.ReadLine().ToLower();

            bool guncellendi = false;
            bool bulundu = false;
            while (!guncellendi)
            {
                for (int i = 0; i < telefonRehberi.Count; i++)
                {
                    if (telefonRehberi[i].Name.ToLower().Equals(delName) || telefonRehberi[i].SurName.ToLower().Equals(delName))
                    {
                        Console.WriteLine("Güncellemek istediğiniz kişiye ait bilgiler: {0} {1} - {2}",telefonRehberi[i].Name, telefonRehberi[i].SurName, telefonRehberi[i].Number);

                        Console.Write("Lütfen kişi adını giriniz: "); String name = Console.ReadLine(); name = name.ToLower();                    
                        Console.Write("Lütfen kişi soyadını giriniz: "); String surName = Console.ReadLine(); surName = surName.ToLower();
                        Console.Write("Lütfen kişi numarasını giriniz: "); String number = Console.ReadLine();
                        telefonRehberi[i].Name = name;
                        telefonRehberi[i].SurName = surName;
                        telefonRehberi[i].Number = number;
                        guncellendi = true;
                        bulundu = true;
                        Console.WriteLine("Guncelleme islemi basariyla tamamlandi..");
                    }
                }
                if (!bulundu)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.Lütfen bir seçim yapınız.");
                    back:
                    Console.WriteLine("* Guncelleme işlemini sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                    int deger = int.Parse(Console.ReadLine());

                    if (deger == 1)
                    {
                        break;
                    }
                    else if (deger == 2)
                    {
                        goto head;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz değer girdiniz.");
                        goto back;
                    }
                }
            }
        }

        public void rehberiListele()
        {
            back:
            Console.WriteLine("* A-Z'ye sıralamak için : (1)\n* Z-A'ya sıralamak için : (2)");
            int deger = int.Parse(Console.ReadLine());
            var sortedPersons = telefonRehberi.OrderBy(value => value.Name);
            var sortedPersons2 = telefonRehberi.OrderBy(value => value.Name).Reverse();
            if (deger == 1)
            {
                foreach (var person in sortedPersons)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Kişi adı: " + person.Name);
                    Console.WriteLine("Kişi soyadı: " + person.SurName);
                    Console.WriteLine("Kişi numarası: " + person.Number);
                    Console.WriteLine("----------------------------------------");
                }
                
            }
            else if (deger == 2)
            {
                foreach (var person in sortedPersons2)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Kişi adı: " + person.Name);
                    Console.WriteLine("Kişi soyadı: " + person.SurName);
                    Console.WriteLine("Kişi numarası: " + person.Number);
                    Console.WriteLine("----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz değer girdiniz.");
                goto back;
            }    
        }

        public void rehberdeAramaYap()
        {
            bool bulundu = false;
            Console.WriteLine("Lütfen aramak istediğiniz kişinin adını veya soyadını giriniz: "); string nameOrSurname = Console.ReadLine().ToLower();
            for (int i = 0; i < telefonRehberi.Count; i++)
            {
                if (telefonRehberi[i].Name.ToLower().Equals(nameOrSurname) || telefonRehberi[i].SurName.ToLower().Equals(nameOrSurname))
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Kişinin adı: " + telefonRehberi[i].Name);
                    Console.WriteLine("Kişinin adı: " + telefonRehberi[i].SurName);
                    Console.WriteLine("Kişinin adı: " + telefonRehberi[i].Number);
                    Console.WriteLine("----------------------------------------");
                    bulundu = true;
                }
                if (!bulundu)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
                    break;
                }
            }
        }
    }
}
