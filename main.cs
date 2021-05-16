using System;
using System.IO;
using System.Globalization;

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
		if(File.Exists(nazivFajla))
		{
			Console.WriteLine("Dobrodošli! Ulogujte se (1), napravite novi nalog (2) ili izađite iz programa (3)");
			do
			{
				unos = Console.ReadLine();
				if(unos == "1")
				{
					UlogujSe();
				}
				else if (unos == "2")
				{
					NapraviNalog();
				}
				else if (unos == "3")
				{
					Console.Clear();
					Console.WriteLine("Hvala Vam što ste koristili naš program.");
					Console.WriteLine("Programeri: Jovan Lozanac, Mihajlo Đurić, Luka Đurović");
					Console.WriteLine("april - maj 2021.");
					Console.WriteLine("Doviđenja!");
					System.Environment.Exit(0);
				}
				else 
				{
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}
			while(unos != "1" && unos != "2" && unos != "3");
			
		}
		else
    {
			Console.WriteLine("Čestitamo! Vi ste naš prvi korisnik. Napravite nalog (1) ili izađite iz programa (2).");
			do
			{
				unos = Console.ReadLine();
				if(unos == "1")
				{
					NapraviNalog();
				}
				else if (unos == "2")
				{
					Console.Clear();
					Console.WriteLine("Hvala Vam što ste koristili naš program.");
					Console.WriteLine("Programeri: Jovan Lozanac, Mihajlo Đurić, Luka Đurović");
					Console.WriteLine("april - maj 2021.");
					Console.WriteLine("Doviđenja!");
					System.Environment.Exit(0);
				}
				else 
				{
					Console.WriteLine("Molimo Vas, ponovite unos.");
				}
			}
			while(unos != "1" && unos != "2");
		}
	}
	public static string UpisStringa()
	{
    string UnosniString = "";
    ConsoleKeyInfo taster;
    do 
		{
      taster = Console.ReadKey(true);
			if ((taster.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt) 
			{
				continue;
			}
			else if ((taster.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control) 
			{
				continue;
			}
			else if (taster.Key == ConsoleKey.Tab)
			{
				continue;
			}
			else if (taster.Key == ConsoleKey.Backspace) 
			{
				if(UnosniString.Length >= 1)
				{
					UnosniString = UnosniString.Substring(0, UnosniString.Length - 1);
          Console.CursorLeft = UnosniString.Length;
					Console.Write(" ");
					Console.CursorLeft = UnosniString.Length;	
				}
        continue;
      }
      else if (taster.Key == ConsoleKey.Escape) 
			{
				PocetniEkranILogovanje();
			}
			else if (taster.Key == ConsoleKey.Enter) 
			{
				Console.WriteLine();
				return UnosniString;
			}
			else
			{
				Console.Write (taster.KeyChar);
        UnosniString += taster.KeyChar;
			}
    } 
		while (true);
  }
  public struct Poruka
  {
    public string naslov;
    public string telo;
    public DateTime vreme;
    public string primalac;
    public string posiljalac;
    public Poruka (string Naslov, string Telo, DateTime Vreme, string Primalac, string Posiljalac)
    {
      this.naslov = Naslov;
      this.vreme = Vreme;
      this.telo = Telo;
      this.primalac = Primalac;
      this.posiljalac = Posiljalac;
    }
    public void Upisi()
    {
			StreamWriter PrimljeneFajl = File.AppendText (this.primalac + "primljene.txt");
      PrimljeneFajl.WriteLine("0|" + DeSifruj(this.naslov, 1) + "|" + "{0}", DeSifrujDatum(this.vreme.ToString("dd/MM/yyyy HH:mm:ss")));
      PrimljeneFajl.WriteLine("Od: " + DeSifruj(this.posiljalac, 1));
			PrimljeneFajl.WriteLine(DeSifruj(this.telo, 1));
      PrimljeneFajl.Close();
			
			StreamWriter PoslateFajl = File.AppendText (this.posiljalac + "poslate.txt");
      PoslateFajl.WriteLine("0|" + DeSifruj(this.naslov, 1) + "|" + "{0}", DeSifrujDatum(this.vreme.ToString("dd/MM/yyyy HH:mm:ss")));
      PoslateFajl.WriteLine("Ka: " + DeSifruj(this.primalac, 1));
      PoslateFajl.WriteLine(DeSifruj(this.telo, 1));
      PoslateFajl.Close();
    }
  }

	public static void UlogujSe()
	{
		Console.Clear();
		Console.WriteLine("Tokom upisa korisničkog imena i lozinke možete da pritisnete Esc da se vratite na početni ekran.");
		Console.WriteLine("Upišite korisničko ime. Ono se sastoji samo iz slova engleske abecede.");
		string username = UpisStringa();

		Console.WriteLine("Upišite lozinku. Ona se sastoji samo iz slova engleske abecede.");
		string password = UpisStringa();

		string[] lines = System.IO.File.ReadAllLines("korisnici.txt");
		string provera = "username:" + DeSifruj(username, 1) + "|password:" + DeSifruj(password, 1);
		for(int i = 0; i < lines.Length; i++)
		{
			if(lines[i] == provera) Ulazak(username);
		}
		
		Console.Clear();
		Console.WriteLine("Greška. Ovaj nalog ne postoji u sistemu ili su uneti pogrešni podaci.");
		string unos;
		do
		{
			Console.WriteLine("Probajte ponovo (1) ili se vratite na početni ekran (2).");
			unos = Console.ReadLine();
			if(unos == "1") 
			{
				UlogujSe();
			}
			else if(unos == "2") 
			{
				PocetniEkranILogovanje();
			}
		}
		while(unos != "1" && unos != "2");
	}
  
	public static void NapraviNalog()
  {
		bool Uslov;
		do
    {
			Uslov = true;
			//Console.Clear();
			Console.WriteLine("Tokom upisa korisničkog imena i lozinke možete da pritisnete Esc da se vratite na početni ekran.");
			Console.WriteLine("Upišite korisničko ime. Ono se sastoji samo iz slova engleske abecede.");
			string username = UpisStringa();
			while(username == "" || NisuSamoSlova(username))
      {
				Console.WriteLine("Probajte ponovo. Dozvoljena su samo slova, i to engleske abecede.");
				username = UpisStringa();
			}
			Console.WriteLine("Upišite lozinku. Ona se sastoji samo iz slova engleske abecede.");
			string password = UpisStringa();
			while(password == "" || NisuSamoSlova(password))
			{
				Console.WriteLine("Probajte ponovo. Dozvoljena su samo slova, i to engleske abecede.");
				password = UpisStringa();
			}
			string unos;
			do
      {
				Console.Clear();
				if(File.Exists("korisnici.txt"))
				{
					bool PostojiLiUser = false;
					string Provera = "username:" + DeSifruj(username, 1);
					StreamReader podaci = new StreamReader("korisnici.txt");
					while(!podaci.EndOfStream)
					{
						string[] probni = podaci.ReadLine().Split('|');
						if(probni[0] == Provera) 
						{
							PostojiLiUser = true;
						}
					}

					if(PostojiLiUser)
					{
						Console.WriteLine("Greška. Već postoji korisnik sa istim imenom. Probajte ponovo.");
						podaci.Close();
						NapraviNalog();
					}
					podaci.Close();
				}
				
				Console.WriteLine("Korisničko ime: " + username);
				Console.WriteLine("Lozinka: " + password);
				Console.WriteLine("Da li potvrđujete ove podatke? (1 - da, 2 - ne)");
				unos = Console.ReadLine();
				if(unos == "1")
				{
					StreamWriter novipodaci = File.AppendText ("korisnici.txt");
					novipodaci.WriteLine("username:{0}|password:{1}", DeSifruj(username, 1), DeSifruj(password, 1));
					novipodaci.Close();

					PocetniEkranILogovanje();
				}
				else if(unos == "2") 
				{
					Uslov = false;
				}
			}
			while(unos != "1" && unos != "2");
		}
		while(!Uslov);
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

		for (int i = 0; i < rec.Length; i++)
		{
			char trenutnoslovo = rec[i];
			if(!Char.IsLetter(trenutnoslovo)) kodirana[i] = trenutnoslovo;

			else
			{
				char maloslovo = char.ToLower(trenutnoslovo);
				if(trenutnoslovo.CompareTo(maloslovo) == 0) kodirana[i] = slovaMala[(26 + (slovaMala.IndexOf(rec[i]) + pomak)) % 26];
				else kodirana[i] = slovaVelika[(26 + (slovaVelika.IndexOf(rec[i]) + pomak)) % 26];
			}
		}
		string NovaRec = new string(kodirana);
		return NovaRec;
	}
	public static string DeSifrujDatum (string datum)
	{
		string noviDatum = "";
		for(int i = 0; i<datum.Length; i++)
		{
			char provera = datum[i];
			if(provera == '/' || provera == ':' || provera == ' ') noviDatum += provera;
			else if(provera == '0') noviDatum += '5';
			else if(provera == '5') noviDatum += '0';
			else if(provera == '1') noviDatum += '6';
			else if(provera == '2') noviDatum += '9';
			else if(provera == '3') noviDatum += '7';
			else if(provera == '4') noviDatum += '8';
			else if(provera == '6') noviDatum += '1';
			else if(provera == '7') noviDatum += '3';
			else if(provera == '8') noviDatum += '4';
			else if(provera == '9') noviDatum += '2';
		}
		return noviDatum;
	}

	public static bool NisuSamoSlova(string rec)
  {
		//false: samo su slova
		//true: nisu samo slova
		string slova = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		for(int i = 0; i<rec.Length; i++)
		{
			bool DaLiSeJavljaSlovo = false;
			for(int j = 0; j<slova.Length; j++)
			{
				if(rec[i] == slova[j]) DaLiSeJavljaSlovo = true;
			}
			if(DaLiSeJavljaSlovo == false) return true;
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
			if(unos == "1")
			{
				PisanjeMejla(username);
				Ulazak(username);
			}
			else if(unos == "2") 
			{
				string NazivFajla = username + "poslate.txt";
				PregledFajla(NazivFajla, username);
			}
			else if(unos == "3")
			{
				string NazivFajla = username + "primljene.txt";
				PregledFajla(NazivFajla, username);
			}
			else if (unos == "4") PocetniEkranILogovanje();
		}
		while(unos != "1" && unos != "2" && unos != "3" && unos != "4");
		//dopuniti metodu
	}

	public static Poruka PisanjeMejla(string korisnik)
  {
		Console.WriteLine("Tokom ove procedure možete da pritisnete Esc da se vratite na početni ekran.");
    Console.WriteLine("Unesite korisničko ime primaoca.");
		string primac = UpisStringa();

    bool PostojiLiUser = false;
    while(!PostojiLiUser)
    {
      string Provera = "username:" + DeSifruj(primac, 1);
      StreamReader podaci = new StreamReader("korisnici.txt");
      while(!podaci.EndOfStream)
      {
        string probni = podaci.ReadLine();
        if(probni.Substring(0, Provera.Length) == Provera) PostojiLiUser = true;
      }
      if(!PostojiLiUser)
      {
        Console.WriteLine("Greška. Korisnik sa ovim korisničkim imenom ne postoji. Unesite korisničko ime ponovo: ");
        primac = UpisStringa();
      }
    }
    Console.WriteLine("Unesite naslov poruke: ");
    string naslov = UpisStringa();
    TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Belgrade");
    DateTime localTimeNow = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, localZone);
    for(int i = 0; i < 50; i++)
    {
      Console.Write("_");
    }
    for(int i = 0; i < 2; i++)
    {
      Console.Write("\n");
    }
    Console.WriteLine("Unesite telo poruke: ");
    string telo = UpisStringa();
    Poruka poruka = new Poruka(naslov, telo, localTimeNow, primac, korisnik);
		poruka.Upisi();
    return poruka;
  }

	static void PregledFajla(string NazivFajla, string username)
  {
		//cita samo one linije sa naslovom poruke
		if(!File.Exists(NazivFajla)) 
		{
			Console.WriteLine("Nemate primljenih ili poslatih poruka.");
			Ulazak(username);
		}

		StreamReader fajl = new StreamReader (NazivFajla);
		int[] BrojeviRedovaSaNaslovima = new int[100]; //ovo govori na kojim redovima su ispisane linije
		int Brojac1 = -1; //broji indeks niza
		int Brojac2 = -1; //broji liniju u fajlu
		Console.Clear();

		while(!fajl.EndOfStream)
		{
			string[] trenutnired = fajl.ReadLine().Split('|');
			Brojac2++;
			if(trenutnired.Length == 3 && Brojac2 % 3 == 0) 
			{
				Brojac1++;

				Console.Write(" ");
				if(trenutnired[0] == "0" && NazivFajla.Substring(NazivFajla.Length - 13) == "primljene.txt") Console.Write("NEPROČITANA: ");
				Console.Write(DeSifruj(trenutnired[1],2)); //ovo je naslov;
				Console.Write(" ({0})", DeSifrujDatum (trenutnired[2]));
				Console.WriteLine();

				if(Brojac1 == BrojeviRedovaSaNaslovima.Length) Array.Resize (ref BrojeviRedovaSaNaslovima, BrojeviRedovaSaNaslovima.Length + 100);
				BrojeviRedovaSaNaslovima[Brojac1] = Brojac2; //ovo govori da se naslov npr. 0. poruke nalazi na 7. redu u fajlu, sledece na 16. redu itd.
			}
		}
		fajl.Close();
		Console.WriteLine("Izaberite poruku koju želite prikazati, zatim pritisnite Enter. Pritisnite Esc ako želite da se odjavite.");
		Array.Resize(ref BrojeviRedovaSaNaslovima, Brojac1+1);
		
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
      else if (dugme.Key == ConsoleKey.DownArrow && KursorY != BrojeviRedovaSaNaslovima.Length - 1)
			{
				KursorY++;
				BrojRedaPorukeKojuTrebaPrikazati = BrojeviRedovaSaNaslovima[KursorY];
			}
			else if (dugme.Key == ConsoleKey.Escape) PocetniEkranILogovanje();
    }
		while (dugme.Key != ConsoleKey.Enter);
		//OVDE POZIVA SE METODA ZA ISPIS SELEKTOVANE PORUKE
		UcitajPoruku(NazivFajla, username,  BrojRedaPorukeKojuTrebaPrikazati);
		//jer je KursorY broj reda sa naslovom poruke
	}
	public static void UcitajPoruku (string NazivFajla, string username, int BrojRedaPorukeKojuTrebaPrikazati){
		Console.Clear();
		StreamReader fajl = new StreamReader (NazivFajla);

		int trazenRed = BrojRedaPorukeKojuTrebaPrikazati+1;
		int i = 1;
		string upis1;
		while(i != trazenRed){
			i++;
			upis1 = fajl.ReadLine();
		}
		upis1 = fajl.ReadLine();
		string upis2 = fajl.ReadLine();
		string upis3 = fajl.ReadLine();
		upis1 = "1" + upis1.Substring(1);
		fajl.Close();

		string[] ispis = System.IO.File.ReadAllLines(NazivFajla);
		ispis[BrojRedaPorukeKojuTrebaPrikazati] = upis1;
		System.IO.File.WriteAllLines(NazivFajla, ispis);
		string[] podeljen = upis1.Split('|');
		Console.WriteLine("Naslov: " + DeSifruj(podeljen[1],2));
		Console.WriteLine("Primalac/Pošiljalac: " + DeSifruj(upis2.Substring(4), 2));
		Console.WriteLine(DeSifruj(upis3, 2));

		Console.WriteLine("Pritisnite Enter da biste se vratili na izbor ili Esc da se odjavite.");
		ConsoleKeyInfo dugme;
		do{
			dugme = Console.ReadKey();
			if(dugme.Key == ConsoleKey.Escape) PocetniEkranILogovanje();
			if(dugme.Key == ConsoleKey.Enter) Ulazak(username);
		} 
		while (dugme.Key != ConsoleKey.Escape && dugme.Key != ConsoleKey.Enter);
	}
  public static void Main () 
  {
    PocetniEkranILogovanje();
  }
}