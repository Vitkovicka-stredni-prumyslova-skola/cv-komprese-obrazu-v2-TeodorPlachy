
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Komprese
{
  public class Obrazek{
    /// <summary>
    /// Privátní statické dvourozměrné pole, které obsahuje jednotlivé symboly obrázku reprezentující barvu pixelu
    /// </summary>
    private int [,] obrazek = null;

    /// <summary>
    /// Konstruktor, který vytvoří instanci obrázku.
    /// </summary>
    /// <param name="filePath">Cesta k obrázku</param>
    public Obrazek(string filePath){
        readImg(filePath);
    }
    /// <summary>
    /// Metoda spočítá vertikální velikost obrazu na základě počtu řádků ve vstupním CSV souboru
    /// </summary>
    /// <param name="filePath">Řetězec reprezentuje cestu k souboru</param>
    /// <returns>Vrací celé číslo reprezentující počet řádků vstupního obrazu</returns>
    public int CountLines(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            int i = 0;
            while (sr.ReadLine() != null) { i++; }
            return i;
        }
    }

    /// <summary>
    /// Metoda spočítá horizontální velikost obrazu na základě počtu symbolů v jednom řádku ve vstupním CSV souboru
    /// </summary>
    /// <param name="filePath">Řetězec reprezentuje cestu k souboru</param>
    /// <returns>Vrací celé číslo reprezentující počet symbolů v jednom řádku vstupního obrazu</returns>
    public int CountSymbolInLine(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            int i = 0;
            String [] line  = sr.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in line)
            { 
                i++; 
            }
            return i;
        }
        
    }
    /// <summary>
    /// Načte vstupní obrázek, který převede na statické dvourozměrné pole o horizontální velikosti vypočtené z počtu symbolů na prvním řádku a 
    /// vertikální velikosti vypočítáné z počtu řádků.
    /// </summary>
    /// <param name="filePath">Cesta ke vstupnímu obrázku</param>
    private void readImg(String filePath){

        StreamReader sr = null;
        String [] line = null;
        String row;
        obrazek = new int [CountSymbolInLine(filePath), CountLines(filePath)];
        
        try
        {
            
            using (sr = new StreamReader(filePath))
            {     
                int j = 0;

                while ((row = sr.ReadLine()) != null)
                {   
                    line = row.Split(";", StringSplitOptions.RemoveEmptyEntries);
                                   
                    for (int i = 0; i < obrazek.GetLength(0); i++)
                    {
                        obrazek [i,j] = Int32.Parse(line[i]);
                    }
                    j++;                    
                }
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Soubor nelze načíst:");
            Console.WriteLine(e.Message);
        }
    
        
    }
    /// <summary>
    /// Metoda vytiskne jednotlivé pixely obrázku
    /// </summary>
    public void vypisImg(){
        for (int j = 0; j < obrazek.GetLength(1); j++)
        {
            for (int i = 0; i < obrazek.GetLength(0); i++)
            {
                Console.Write("{0}, ",obrazek[i, j]);
            }
            Console.WriteLine();
        }
    }
  }  
}