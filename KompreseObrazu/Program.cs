using System.Globalization;

namespace Komprese
{
    public class KompreseObrazu{

        public static void Main (String [] args){
        
        

        //Cesta k testovacímu souboru
        String testFilePath = @"/home/teodor/github-classroom/Vitkovicka-stredni-prumyslova-skola/cv-komprese-obrazu-v2-TeodorPlachy/KompreseObrazu/CSV/obr1-10.csv";
        
        //vytvoření instance třídy Obrazek
        Obrazek inputCSV = new Obrazek(testFilePath);

        
        
        //Test metody, která spočítá počet řádků vstupního obrázku
        Console.WriteLine("Počet vertikálních řádků {0}",inputCSV.CountLines(testFilePath));
        
        //Test metody, která spočítá počet symbolů vstupního obrázku v prvním řádku
        Console.WriteLine("Počet horizontální řádků {0}",inputCSV.CountSymbolInLine(testFilePath));

        inputCSV.vypisImg();

        List<int> unikatniBarvy = inputCSV.PaletaBarevObrazku();

        Console.WriteLine("_________________________");

        Console.WriteLine("Unikátní barvy: ");

        foreach(int element in unikatniBarvy){
            Console.Write($"{element}, ");
        }
        Console.WriteLine();
        Console.WriteLine("Počet barev: ");
        int [,] PocetBarev = inputCSV.pocetBarev();
        
        for(int i = 0; i < PocetBarev.GetLength(1); i++){

            Console.WriteLine("barva {0} se objevila {1}x", PocetBarev[0,i], PocetBarev[1,i]);

        }

    }

    }
    
    
}