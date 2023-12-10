using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Arv_klassdiagram
{

	// Abstrakt grundklass för alla djur
	public abstract class animal
	{
		
		protected int Age;
		protected string Name;
		protected bool Hungry;
		protected string Favourite_food;
		protected bool HasPlayed;
		
		
		// Konstruktor som sätter egenskaper för ett djur
		protected animal(int _Age, string _Name)
		{
			Age = _Age; 
			Name = _Name; 
			Hungry = false; 
			Favourite_food = "Köttbullar";
		}

		// Metod för att generera ett slumpat tal mellan 1 och 3
		protected int GetRandomNumber()
		{
			Random random = new Random();
			return random.Next(1,3);
		}

		// Metod för att skriva ut resultatet av det slumpmässiga numret
		protected void PrintRandomResult(int resultat)
		{
			
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\nNu kommer programmet att slumpa ett tal..\nIfall det slumpade talet blir 1, så kommer djuret få äta.\nBlir det 2 så får djuret inte mat och fortsätter att vara hungrig..");
			
			Console.WriteLine($"\nSlumpar talet...\nResultat: {resultat}\n");
		}


	
		// Virtuell metod för att låta djuret äta
		public virtual void eat(string food)
			
		{	

			
			
			int resultat = GetRandomNumber();
			PrintRandomResult(resultat);

			

			if (resultat == 1)
			{	
				Hungry = false;
				

				if (food == Favourite_food)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine($"\n{Name} tuggar glatt i sig " + Favourite_food + " och är nöjd..");
				}

				
			}
			else 
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine($"\n{Name} är hungrig och ute på jakt medans han drömmer om " + Favourite_food+ "..");
				Hungry = true;
				Console.ForegroundColor = ConsoleColor.White;
			} 
			
		}

		// Metod för att få åldern på djuret
		public int GetAge()
		{
			// Returnerar åldern
			return Age;
		}

		// Metod för att få namnet på djuret
		public string GetName()
		{
			// Returnerar namnet
			return Name;
		}

		// Virtuell metod för att interagera med djuret (standardmetoden)
		public virtual void interact()
		{			
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine($"\n{Name} viftar glatt på svansen när du klappar han på huvudet");
				Hungry = true;

				if (Hungry)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine($"\nEftersom {Name} har lekt med dig så blev han nu väldigt hungrig..");
					Console.WriteLine($"Hungerstatus: {Name} är hungrig..");
					Console.ForegroundColor = ConsoleColor.White;	
					
				}
		}

		// Virtuell metod för att interagera med djuret genom att kasta boll (överlagradade metoden)
		public virtual void interact(bool throwBall)
		{

			if (throwBall)  
			{
				
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine($"\n..Jocke kastar bollen till {Name}..");
				
					if (throwBall)
					{
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						
						if (Hungry && Age >= 12)
						{
							Console.WriteLine($"\nEftersom {Name} är {Age} år gammal så blir han ofta väldigt trött när han är hungrig. Så {Name} orkar inte jaga efter bollen just nu..\n");
						}

						else
						{
							Console.WriteLine($"\n{Name} springer glatt och jagar efter bollen..\n");
							Console.ForegroundColor = ConsoleColor.White;
						}
						
						Hungry = true; // Sätter djurets hungerstatus till true efter att djuret lekt	

						if (Hungry)
						{
							Console.ForegroundColor = ConsoleColor.DarkMagenta;
							Console.WriteLine($"\nEftersom {Name} har lekt med dig så blev han nu väldigt hungrig..");
							Console.WriteLine($"Hungerstatus: {Name} är hungrig..");
							Console.ForegroundColor = ConsoleColor.White;					
						}	
						
					}
            
					else
					{
						interact(); // Kallar bas "interact" klassen
					}
								
			}

			else
			{
				interact(); // Anropar meddelandet från originalmetoden "Interact()"	
			}

		}
		  
		public override string ToString()
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			return $"Djur: {GetType().Name}\nNamn: {Name}\nÅlder: {Age} år \nFavoritmat: {Favourite_food}\n";
			// Skapar en relevant utskrift när vi skriver ut "djur" objekten
		}

	}

	
	// Klass som representerar en katt och som ärver från animal
	class cat : animal
	{
		public cat(int _Age, string _Name) : base(_Age, _Name)
			
		{	
			Favourite_food = "Lax"; // Sätter djurets favoritmat
		}		
		
		
		public override void interact()
		{
			base.interact(); // Kallar på bas interact metoden
		}	

		// Överlagrad eat metod för katt 
		public override void eat(string food)
		{
			base.eat(food);	
		}

	}

	// Subklass för ett lejon
	class lion : animal
	{

		// Konstruktor för lejon som anropar basklassens konstruktor och sätter favoritmat
		public lion(int _Age, string _Name) : base(_Age, _Name)
		{
			Favourite_food = "Kött";
		}

        public override void eat(string food)
        {
            base.eat(food);
        }

		// Överlagrad interact metod för lejon som tar emot en bool variabel
        public override void interact(bool throwBall)
		{
			base.interact(throwBall);	
		}	

    }
	
	// Subklass för hund
	class dog : animal
	{
		// Konstruktor för hund som anropar basklassens konstruktor och ärver favoritmat
		public dog(int _Age, string _Name) : base(_Age, _Name)
		{
			
		}

		public override void eat (string food)
		{
			
			int resultat = GetRandomNumber();
			PrintRandomResult(resultat);

			if (resultat == 1)
			{
				if (food == Favourite_food)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine($"\n{Name} njuter av sin favoritmat {Favourite_food}");
				}
			}

			else
			{
				Console.WriteLine($"\n{Name} är fortfarande hungrig och nosar efter mat.");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public override void interact()
		{
			base.interact();		
		}	

	}

	// Subklass för valp som ärver från hund
	class puppy : dog
	{
		private int months;

		public puppy(int _Age, string _Name, int _Months) : base(_Age, _Name)
		{
			/*Skapa en konstruktorn som har värden Age och String som argument
		 	Dessutom ska ytterligare ett värde läggas till och skickas med när objektet skapas
		 	Det är värdet månader. Och det ska inte skickas till base eftersom det inte finns
		 	i basklassen. Värdet för age (i år) sätts till noll (0)*/
			
			
			months = _Months;
		}

		public override void eat (string food)
		{
			
			int resultat = GetRandomNumber();
			PrintRandomResult(resultat);


			if (resultat == 1)
			{
				if (food == Favourite_food)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine($"{Name} njuter av sin favoritmat {Favourite_food}");
				}
				
			}

			else
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine($"{Name} är fortfarande hungrig och nosar efter mat.");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public override void interact()
		{
			base.interact();
			
		}	

	}

	// Subklass för bäver
	class beaver : animal
	{
		public beaver(int _Age, string _Name) : base(_Age, _Name)
		{
			Favourite_food = "Bark";
		}

		public override void eat (string food)
		{
			
			int resultat = GetRandomNumber();
			PrintRandomResult(resultat);

			if (resultat == 1)
			{
				if (food == Favourite_food)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine($"\n{Name} simmar omkring och plaskar med sin svans medans han tuggar i sig lite {Favourite_food}");
				}
			}

			else
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine($"\n{Name} är hungrig så han simmar ut från sin bäverdamm för att leta upp lite mat..");
				Console.ForegroundColor = ConsoleColor.White;
			}

		}

		public override void interact(bool throwBall)
		{
			base.interact(throwBall);
		}	

	}
	

	// Klassen som "äger" djuren och lagrar dom i en array
	class petowner
	{
		private string name;
		
		private animal[] djur = new animal[4];
		// Skapar en ny array "djur" av typen "animal".
		
		public petowner()
		{
			
			//Skapar nya djur objekt som jag samtidigt lägger in i en array "djur".
			djur[0] = new cat(4, "Messi");
			djur[1] = new dog(7, "Festis");
			djur[2] = new lion(12, "Simba");
			djur[3] = new beaver(37, "Lars");
			
		} 

		// Metod för att köra huvudmenyn och interaktionerna med djuren
		public void Run()
		{

			bool exitMenu = false;

			while (!exitMenu)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\nVälj ett alternativ:\n");
				Console.WriteLine("1. Skriv ut alla djur");
				Console.WriteLine("2. Mata ett djur");
				Console.WriteLine("3. Lek med ett djur");
				Console.WriteLine("4. Avsluta\n");

				
				string userChoice = Console.ReadLine();
				Console.WriteLine("\nSvar: " + userChoice);

				// Skapar en switch meny så användaren kan välja att göra lite olika saker med programmet
				switch (userChoice)
				{
					case "1":
						print_animals();
						break;

					case "2":
						feed();
						break;

					case "3":
						play();
						break;

					case "4":
						exitMenu = true;
						break;

					default:
						Console.WriteLine("Ogiltigt val. Försök igen..");
						break;				

				} 

			}
			
		}
		
		// Metod för att skriva ut all djur i arraryen
		public void print_animals()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nLista över alla djur:\n");
			Console.ForegroundColor = ConsoleColor.White;

			for (int i = 0; i < djur.Length; i++)
			{
				animal currentAnimal = djur[i];

				if (currentAnimal != null)
				{
						Console.WriteLine(currentAnimal);
				}
			}
		}

		// Metod för att leka med ett djur
		public void play()
		{	
			
			Console.WriteLine("\nVälj ett av djuren att leka med:\n");
			Console.WriteLine("1. Cat");
			Console.WriteLine("2. Dog");
			Console.WriteLine("3. Lion");
			Console.WriteLine("4. Beaver\n");


			string lekVal = Console.ReadLine();
			Console.WriteLine("\nSvar: " + lekVal);

			// Skapar en switch meny så användaren kan välja vilket djur man ska leka med
			switch (lekVal)
			{
				case "1":
					djur[0].interact();
					break;

				case "2":
					djur[1].interact();
					break;

				case "3":
					djur[2].interact(true);
					break;

				case "4":
					djur[3].interact(true);
					break;	

				default:
					Console.WriteLine("Ogiltigt val. Försök igen..");
					break;		

			}
			
		}


		// Metod för att mata djuren
		public void feed()
		{	
			Console.WriteLine("\nVälj ett av djuren att mata:\n");
			Console.WriteLine("1. Cat");
			Console.WriteLine("2. Dog");
			Console.WriteLine("3. Lion");
			Console.WriteLine("4. Beaver\n");
			

			string matVal = Console.ReadLine();
			Console.WriteLine("\nSvar: " + matVal);

			// Skapar en switch meny så användaren kan välja vilket djur man ska mata
			switch (matVal)
			{
				case "1":
					djur[0].eat("Lax");
					break;

				case "2":
					djur[1].eat("Köttbullar");
					break;

				case "3":
					djur[2].eat("Kött");
					break;

				case "4":
					djur[3].eat("Bark");
					break;	

				default:
					Console.WriteLine("Ogiltigt val. Försök igen..");
					break;		
					
			}	
		}
	}

	// Huvudklassen som innehåller programmet och ingångspunkten
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Title = "Uppdrag 3 - Emil Kjellemar";
			Console.WriteLine("...Välkommen!...");

			
		
			petowner Jocke = new petowner(); // Skapar en instans av petowner klassen med namn Jocke

			Jocke.Run(); // Startar programmet genom att köra metoden Run() från petowner objektet

			// Väntar på att användaren ska trycka på valfri tangent innan programmet stängs
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
