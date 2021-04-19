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
		string unos;
		if(File.Exists(nazivFajla)){
			Console.WriteLine("Dobrodošli! Ulogujte se (1), napravite novi nalog (2) ili izađite iz programa (3)");
			do{
				unos = Console.ReadLine();
				if(unos == "1"){
					UlogujSe();
				}
				else if (unos == "2"){
					NapraviNalog();
				}
				else if (unos == "3"){
					Console.WriteLine("Hvala Vam što ste koristili naš program. Doviđenja!");
				}
				else {
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}while(unos != "1" && unos != "2" && unos != "3");
			
		}
		else{
			Console.WriteLine("Čestitamo! Vi ste naš prvi korisnik. Napravite nalog (1) ili izađite iz programa (2).");
			do{
				unos = Console.ReadLine();
				if(unos == "1"){
					NapraviNalog();
				}
				else if (unos == "2"){
					Console.WriteLine("Hvala Vam što ste koristili naš program. Doviđenja!");
				}
				else {
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}while(unos != "1" && unos != "2");
			
		}
	}
	public static void UlogujSe(){
		//napraviti metodu
	}
  
	public static void NapraviNalog()
  {
		bool Uslov;
		do
    {
			Uslov = true;
			Console.Clear();
			Console.WriteLine("Upišite korisničko ime. Ono se sastoji samo iz slova engleske abecede.");
			string username = Console.ReadLine();
			while(username == "" || NisuSamoSlova(username))
      {
				Console.WriteLine("Probajte ponovo.");
				username = Console.ReadLine();
			}
			Console.WriteLine("Upišite lozinku. Ona se sastoji samo iz slova engleske abecede.");
			string password = Console.ReadLine();
			while(password == "" || NisuSamoSlova(password)){
				Console.WriteLine("Probajte ponovo.");
				password = Console.ReadLine();
			}
			string unos;
			do{
				Console.Clear();
				Console.WriteLine("Korisničko ime: " + username);
				Console.WriteLine("Lozinka: " + password);
				Console.WriteLine("Da li potvrđujete ove podatke? (1 - da, 2 - ne)");
				unos = Console.ReadLine();
				if(unos == "1"){
					StreamWriter podaci = File.AppendText ("korisnici.txt");
					podaci.WriteLine("username:{0}|password:{1}", DeSifruj(username, 1), DeSifruj(password, 1));
					podaci.Close();
					PocetniEkranILogovanje();
				}
				else if(unos == "2") {
					Uslov = false;
				}
			}while(unos != "1" && unos != "2");
		}while(!Uslov);
	}
	public static string DeSifruj (string rec, int smer){
		//smer = 1: sifruj rec
		//smer = 2: DEsifruj rec
		string slovaVelika = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string slovaMala = slovaVelika.ToLower();
		
		int pomak = 5;
		char[] kodirana = new char[rec.Length];
		if (smer == 2) pomak *= -1;
		for (int i = 0; i < rec.Length; i++){
			char trenutnoslovo = rec[i];
			char maloslovo = char.ToLower(trenutnoslovo);
			if(trenutnoslovo.CompareTo(maloslovo) == 0) kodirana[i] = slovaMala[(26 + (slovaMala.IndexOf(rec[i]) + pomak)) % 26];
			else kodirana[i] = slovaVelika[(26 + (slovaVelika.IndexOf(rec[i]) + pomak)) % 26];
		}
		string NovaRec = new string(kodirana);
		return NovaRec;
	}
	public static bool NisuSamoSlova(string rec){
		//false: samo su slova
		//true: nisu samo slova
		for(int i = 0; i<rec.Length; i++){
			if(!char.IsLetter(rec[i])) return true;
		}
		return false;
	}
  public static void Main () 
  {
    PocetniEkranILogovanje();
  }
}