using System;
using System.IO;
class MainClass
{
	public static void PocetniEkranILogovanje(){
		Console.Clear();
		//Intro:
		Console.WriteLine(@"         ______                     _      __                                  ____");
		Console.WriteLine(@"        |      |                   / \    /  \                                |    |");
		Console.WriteLine(@"        |      |                  /   \  /    \                         ____  |    |");
		Console.WriteLine(@"        |      |                 /     \/      \                       |    | |    |");
		Console.WriteLine(@"        |      |  _________     /               \                      |____| |    |");
		Console.WriteLine(@"        |      | |         |   /                 \         ____  ____   ____  |    |");
		Console.WriteLine(@"        |      | |_________|  /                   \       /    \|    | |    | |    |");
		Console.WriteLine(@"        |      |             /                     \     /  ___      | |    | |    |");
		Console.WriteLine(@" _____  |      |            /                       \   |  /   \     | |    | |    |");
		Console.WriteLine(@"|     |_|      |           /      /\         /\      \  |  \___/     | |    | |    |______________");
		Console.WriteLine(@"\              /          |      /  \       /  \      |  \           | |    | |                   |");
		Console.WriteLine(@" \____________/           |_____/    \_____/    \_____|   \____/|____| |____| |___________________|");
		Console.WriteLine();
		Console.WriteLine("                                 J-MaiL - simulator mejl klijenta");
		Console.WriteLine("                                 © 2021 JML. Sva kriva zaštićena.");
		Console.WriteLine("===================================================================================================");
		//Provera i logovanje:
		string nazivFajla = "korisnici.txt";
		if(File.Exists(nazivFajla)){
			Console.WriteLine("Dobrodošli! Ulogujte se (1), napravite novi nalog (2) ili izađite iz programa (3)");
			do{
				if(Console.ReadLine() == "1"){
					UlogujSe();
				}
				else if (Console.ReadLine() == "2"){
					NapraviNoviNalog();
				}
				else if (Console.ReadLine() == "3"){
					Console.WriteLine("Hvala Vam što ste koristili naš program. Doviđenja!");
				}
				else {
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}while(Console.ReadLine() != "1" && Console.ReadLine() != "2" && Console.ReadLine() != "3");
			
		}
		else{
			Console.WriteLine("Čestitamo! Vi ste naš prvi korisnik. Napravite nalog (1) ili izađite iz programa (2).");
			do{
				if(Console.ReadLine() == "1"){
					NapraviNoviNalog();
				}
				else if (Console.ReadLine() == "2"){
					Console.WriteLine("Hvala Vam što ste koristili naš program. Doviđenja!");
				}
				else {
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}while(Console.ReadLine() != "1" && Console.ReadLine() != "2");
			
		}
	}
	public static void UlogujSe(){
		//napraviti metodu
	}
	public static void NapraviNoviNalog(){
		//napraviti metodu
	}
  public static void Main () 
  {
    PocetniEkranILogovanje();
  }
}