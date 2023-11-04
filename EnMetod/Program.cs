namespace EnMetod;

class Program
{

     static void Main(string[] args)
    {
        Console.Title = "En Metod - Emil Kjellemar";


        Console.WriteLine("Skriv in grader i Fahrenheit: "); //användaren skriver in temperatur i fahrenheit 
        int fahrenheitInput = int.Parse(Console.ReadLine()); 

        decimal celsius = FahrToCel(fahrenheitInput); //konverterar en temp i fahrenheit som användaren angett och lagrat i fahrenheitInput, till Celsius genom att använda metoden FahrToCel. Det resulterade Celsius värdet tilldelas till variabeln celsius

        Console.ForegroundColor = ConsoleColor.DarkGreen; //ändrar färg på texten i konsollen

        Console.WriteLine($"Temperaturen i Celsius är: {celsius} grader"); //skriver ut celsius-värdet

        decimal slumpadCelsius = FahrToCel(); //anropar metoden för att slumpa en temp i fahrenheit & konverterar den till celsius
        
        Console.WriteLine($"\nSlumpad temperatur konverterat från Fahrenheit till Celsius är: {slumpadCelsius} grader"); //skriver ut det slumpade celsius-värdet 
  
        
       Console.ReadKey(); //väntar på att användaren ska trycka på en tangent innan programmet avslutas
    }


    // Metod för att konvertera en temp i fahrenheit till celsius
    static decimal FahrToCel(int fahrs)
    {
       decimal celsius = (decimal)(fahrs - 32) * 5 / 9; //formel för konvertering
       return celsius; // returnera resultatet
    }


    // Metod för att slumpa en temp i fahrenheit, konvertera den till celsius och returnera resultatet
    static decimal FahrToCel()
    {   

        Random random = new Random(); 
        int slumpadFahrenheit = random.Next(-100, 100); //Slumpa ett värde mellan -100 och 99 i fahrenheit
        decimal celsius = FahrToCel(slumpadFahrenheit); //Anropa den tidigare definierade metoden för att konvertera slumpad fahrenheit till celsius
        return celsius; //Returnera det slumpade celsius-värdet



    }


}
