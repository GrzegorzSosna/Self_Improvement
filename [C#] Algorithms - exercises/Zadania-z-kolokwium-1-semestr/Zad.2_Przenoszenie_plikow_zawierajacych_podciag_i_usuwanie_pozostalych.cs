using System;
using System.IO;

namespace Kolokwium
{
    class Program
    {
        static void PrzenoszenieUsuwaniePlikow(string folderZrodlowy, string folderDocelowy)
        {
            string[] pliki = Directory.GetFiles(folderZrodlowy);

            foreach (string plik in pliki)
            {
                FileInfo nowyPlik = new FileInfo(plik);
                if (nowyPlik.Name.Contains("Maskowane")) 
                {
                    File.Move(folderZrodlowy + @"\" + nowyPlik.Name, folderDocelowy + @"\" + nowyPlik.Name);
                }
                else
                    File.Delete(folderZrodlowy + @"\" + nowyPlik.Name);
            }
        }
            
        static void Main(string[] args)
        {
            string folderZrodlowy = @"C:\TestA";
            string folderDocelowy = @"C:\TestB";

            PrzenoszenieUsuwaniePlikow(folderZrodlowy, folderDocelowy);
        }
    }
}
