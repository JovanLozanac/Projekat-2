using System;
using System.IO;
class MainClass
{
	public static void PocetniEkranILogovanje()
  {
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
		else
    {
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
	public static void UlogujSe()
	{
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
		while(password == "" || NisuSamoSlova(password))
		{
			Console.WriteLine("Probajte ponovo.");
			password = Console.ReadLine();
		}
		string[] lines = System.IO.File.ReadAllLines("korisnici.txt");
		string provera = "username:"+ DeSifruj(username,1)+"|password:"+ DeSifruj(password,1);
		for(int i = 0; i<lines.Length; i++)
		{
			if(lines[i]==provera) Ulazak(username);
		}
		Console.Clear();
		Console.WriteLine("Greška. Ovaj nalog ne postoji u sistemu ili su uneti pogrešni podaci.");
		string unos;
		do
		{
			Console.WriteLine("Probajte ponovo (1) ili se vratite na početni ekran (2).");
			unos = Console.ReadLine();
			if(unos == "1") UlogujSe();
			else if(unos == "2") PocetniEkranILogovanje();
		}while(unos != "1" && unos != "2");
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
			do
      {
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
	public static string DeSifruj (string rec, int smer)
  {
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
	public static bool NisuSamoSlova(string rec)
  {
		//false: samo su slova
		//true: nisu samo slova
		for(int i = 0; i<rec.Length; i++){
			if(!char.IsLetter(rec[i])) return true;
		}
		return false;
	}
	public static void Ulazak (string username)
  {
		//Ovo je ono sto se prikaze kad se korisnik uloguje u sistem.
		string unos;
		do
    {
			
			Console.WriteLine("Napišite mejl (1), pogledajte svoje poslate (2) ili primljene (3) mejlove ili se odjavite (4).");
			unos = Console.ReadLine();
			if(unos == "1"){
				NapisiPoruku(username);
			}
			else if(unos == "2") {
				string NazivFajla = username + "poslate.txt";
				PregledFajla(NazivFajla, username);
			}
			else if(unos == "3"){
				string NazivFajla = username + "primljene.txt";
				PregledFajla(NazivFajla, username);
			}
			else if (unos == "4") PocetniEkranILogovanje();
		}while(unos != "1" && unos != "2" && unos != "3" && unos != "4");
		//dopuniti metodu
	}
	static void NapisiPoruku(string username)
	{
		//napisi metodu
	}
	static void PregledFajla(string NazivFajla, string username)
  {
		//cita samo one linije sa naslovom poruke
		if(!File.Exists(NazivFajla)) {
			Console.WriteLine("Nemate primljenih ili poslatih poruka.");
			Ulazak(username);
		}
		StreamReader fajl = new StreamReader (NazivFajla);
		int[] BrojeviRedovaSaNaslovima = new int[100]; //ovo govori na kojim redovima su ispisane linije
		int Brojac1 = -1;
		int Brojac2 = -1;
		while(!fajl.EndOfStream){
			string[] trenutnired = fajl.ReadLine().Split('|');
			Brojac2++;
			if(trenutnired.Length == 3) {
				Brojac1++;
				Console.Write(" ");
				if(trenutnired[0] == "0" && NazivFajla.Substring(NazivFajla.Length - 13) == "primljene.txt") Console.Write("NEPROČITANA: ");
				Console.Write(trenutnired[1]); //ovo je naslov;
				Console.Write(" ({0})", trenutnired[2]);
				Console.WriteLine();
				if(Brojac1 == BrojeviRedovaSaNaslovima.Length) Array.Resize (ref BrojeviRedovaSaNaslovima, BrojeviRedovaSaNaslovima.Length + 100);
				BrojeviRedovaSaNaslovima[Brojac1] = Brojac2; //ovo govori da se naslov npr. 0. poruke nalazi na 7. redu u fajlu, sledece na 16. redu itd.
			}
		}
		fajl.Close();
		Console.WriteLine("Izaberite poruku koju želite prikazati, zatim pritisnite Enter. Pritisnite Esc ako želite da se odjavite.");
		Array.Resize(ref BrojeviRedovaSaNaslovima, Brojac2+1);
		//OVDE IDE KURSOR I IZBOR PORUKA
		int KursorY = 0;
		int BrojRedaPorukeKojuTrebaPrikazati = BrojeviRedovaSaNaslovima[KursorY];
		ConsoleKeyInfo dugme;
    do
    {
      Console.SetCursorPosition(0, KursorY);
      dugme = Console.ReadKey(true);
      if (dugme.Key == ConsoleKey.UpArrow && KursorY != 0) 
			{
				KursorY--;
				BrojRedaPorukeKojuTrebaPrikazati = BrojeviRedovaSaNaslovima[KursorY];
			}
      else if (dugme.Key == ConsoleKey.DownArrow && BrojRedaPorukeKojuTrebaPrikazati != BrojeviRedovaSaNaslovima[BrojeviRedovaSaNaslovima.Length-1]) 
			{
				KursorY++;
				BrojRedaPorukeKojuTrebaPrikazati = BrojeviRedovaSaNaslovima[KursorY];
			}
			else if (dugme.Key == ConsoleKey.Escape) PocetniEkranILogovanje();
    }while (dugme.Key != ConsoleKey.Enter);
		//OVDE POZIVA SE METODA ZA ISPIS SELEKTOVANE PORUKE
		UcitajPoruku(NazivFajla, KursorY);
		//jer je KursorY broj reda sa naslovom poruke
	}
	public static void UcitajPoruku (string NazivFajla, int KursorY){

	}
  public static void Main () 
  {
    PocetniEkranILogovanje();
  }
}