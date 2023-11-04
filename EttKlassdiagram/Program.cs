using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace EttKlassdiagram;

public class BANKKONTO
{
        
        private string Namn;
        private int Saldo;
        private int Månadssparande;
        private List<Aktiepost> Aktieposter = new List<Aktiepost>();
    
        

    public static void Main(string[] args)
    {
        Console.Title = "Generisk Samlingsklass - Emil Kjellemar";


        Console.WriteLine("Välkommen! Skapa ett nytt bankkonto."); // Ber användaren göra ett nytt bankkonto

        Console.Write("Ange ditt namn:");
        string namn = Console.ReadLine(); // Lagrar användarens namn i en string "namn"

        Console.Write("Ange ditt saldo:");
        int saldo = int.Parse(Console.ReadLine()); // Lagrar användarens saldo i ent int "saldo"

        BANKKONTO konto = new BANKKONTO(namn, saldo); // Skapar ett nytt bankkonto (ett objekt)


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bankkontot är skapat!");


        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Ange beloppet du vill sätta in på ditt bankkonto:"); // Ber användaren skriva in ett belopp som hen vill sätta in på deras konto
        int insättningBelopp = int.Parse(Console.ReadLine()); // Lagrar insättningsbeloppet i en int "insättningsBelopp"
        konto.Sätta_In(insättningBelopp); // Anropar metoden "Sätta_In" på användarens bankkonto "konto" objekt & används för att sätta in pengar på bankkontot
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Insättning klar.");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Ange beloppet du vill ta ut från ditt bankkonto:"); // Ber användaren skriva in ett belopp som hen vill ta ut från deras konto
        int uttagsBelopp = int.Parse(Console.ReadLine()); // Lagrar uttagsbeloppet i en int "uttagsBelopp"
        konto.Ta_Ut(uttagsBelopp); // Anropar metoden "Ta_Ut" på användarens bankkonto "konto" objekt & används för att ta ut pengar från bankkontot
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Ange ett belopp du vill månadsspara:"); // Ber användaren skriva in ett belopp som hen vill månadsspara
        int sparande = int.Parse(Console.ReadLine()); // Lagrar beloppet i en int "sparande"
        konto.Sätt_Månadsspar(sparande); // Anropar metoden "Sätt_Månadsspar" på användarens bankkonto "konto" objekt & används för att sätta värdet för månadssparande på bankkontot


        Console.WriteLine("Ange tre st aktier:");
        for (int i = 0; i < 3; i++)
        {
            
            Console.WriteLine($"Aktie {i + 1}: ");
            Console.Write("Namn: ");
            string ett_namn = Console.ReadLine();

            Console.Write("Värde: ");
            int ett_värde = int.Parse(Console.ReadLine());
    
            Console.Write("Antal aktier: ");
            int ett_antalaktier = int.Parse(Console.ReadLine());

            Aktiepost aktiepost = new Aktiepost(ett_namn, ett_värde, ett_antalaktier);
            konto.Aktieposter.Add(aktiepost);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAktier registrerade!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }   

        
        Console.WriteLine();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\n  Information om bankkontot:\n"); 
        Console.WriteLine(konto.ToString()); // Anropar metoden "ToString()" och skriver ut all information relaterat till användarens bankkonto
        
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n  Information om aktierna:");
        konto.SkrivUtAktiePoster();
        Console.ForegroundColor = ConsoleColor.White;
        
        
        


        Console.ReadKey();
        
    }

    // Konstruktor som initierar namn och saldo, övriga värden sätts till noll
    public BANKKONTO(string ett_namn, int ett_saldo)
    {
        
        Namn = ett_namn;
        Saldo = ett_saldo;
        Månadssparande = 0;
        

    }

    // Metod för att ta ut pengar från bankkontot
    public void Ta_Ut(int sum)
    {
        if (sum <= Saldo)
        {
            Saldo -= sum;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uttag klar.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Uttaget avbröts. Otillräckligt saldo!");
            Console.ForegroundColor = ConsoleColor.White;  
        }
        
    }

    
    // Metod för att sätta in pengar på bankkontot
    public void Sätta_In(int sum)
    {
        Saldo += sum;
    }

    // Metod för att skriva in värdet för månadssparande
    public void Sätt_Månadsspar(int sparande)
    {
        Månadssparande = sparande;
    }

    
    // Metod för att skriva ut all info 
    public override string ToString()
    {
        return "  Kontoinnehavare: " + Namn + "\n  Saldo: " + Saldo + " KR" + "\n  Månadssparande: " + Månadssparande + " KR";
    }

   
    //public void LäggTillAktier(Aktiepost aktiepost)
    //{
        //Aktieposter.Add(aktiepost);
    //}
    
    // Metod för att skriva ut aktier
    public void SkrivUtAktiePoster()
    {

        foreach (Aktiepost aktie in Aktieposter)
        {
            Console.WriteLine(aktie.ToString());  

        }
            
        
    }

}

class Aktiepost
{
    private string Namn;
    private int Värde_Vid_Köp;
    private int Värde;
    private int Datum_För_Köp;
    private int Antal_Aktier;
    

    public Aktiepost(string ett_namn, int ett_värde, int ett_antalaktier)
    {
        Namn = ett_namn;
        Värde = ett_värde;
        Antal_Aktier = ett_antalaktier;

        Random random = new Random();
        Värde_Vid_Köp = random.Next(1, 1000);
        Datum_För_Köp = 0;

    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return "\n  Aktiepost: " + Namn + "\n  Antal aktier: " + Antal_Aktier + "\n  Värde: " + Värde + "\n  Datum för köp: " + Datum_För_Köp + "\n  Värde vid köp: " + Värde_Vid_Köp;
    }

}
  