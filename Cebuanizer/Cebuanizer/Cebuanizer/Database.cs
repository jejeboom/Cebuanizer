using System;
using SQLite;
using Mono.Data.Sqlite;
using System.Collections.Generic;

namespace Cebuanizer
{
	public class Database
	{
		private static string path = System.IO.Path.Combine((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)), "db_sqlnet.db");

		public Database ()
		{
		}

		public static void createDatabase(string strTblName)
		{
			try
			{
				var connection = new SQLiteConnection(path);
				if(!isTableExisting(strTblName)){
					if(strTblName == "Trivia"){
						connection.CreateTable<Trivia>();
						fillTrivia();
					}else if(strTblName == "Tip"){
						connection.CreateTable<Tip>();
						fillTip();
					}else if(strTblName == "Phrases"){
						connection.CreateTable<Phrases>();
						fillPhrases();
					}else if(strTblName == "Dictionary"){
						connection.CreateTable<Dictionary>();
						fillDictionary();
					}else if(strTblName == "Coins"){
						connection.CreateTable<Coins>();
						var data = new List<Coins> {new Coins { CoinsCount = 0}};
						try
						{
							var db = new SQLiteConnection(path);
							if (db.InsertAll(data) != 0){
								db.UpdateAll(data);
							}
						}
						catch (SQLiteException ex)
						{
							Console.Write (ex.Message);
						}
					}
				}
			}
			catch (SQLiteException)
			{
			}
		}

		private static bool isTableExisting(string strTblName){
			try{
				var connection = new SQLiteConnection(path);
				var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='" + strTblName + "'");
				if(count > 0){
					return true;
				}else{
					return false;
				}
			}catch(SQLiteException){
				return false;
			}
		}

		//Trivia Database

		private static void fillTrivia(){
			
			var data = new List<Trivia>
			{
				new Trivia { TrivPhrase = "#001 Alam mo bang ang Cebuano ay tinatawag ring Bisaya?"},
				new Trivia { TrivPhrase = "#002 Alam mo bang mahigit kumulang 20 milyong tao ang gumagamit sa dialektong Cebuano?"},
				new Trivia { TrivPhrase = "#003 Alam mo bang ang araw ng pagkakatatag ng Cebu ay sa ika-6 ng Agosto?"},
				new Trivia { TrivPhrase = "#004 Alam mo bang sa Cebu naganap ang paglalaban nina Lapu-Lapu at Magellan?"},
				new Trivia { TrivPhrase = "#005 Alam mo bang nasa Cebu ang pinakamatandang relikang Kristiyano ng Pilipinas?"},
				new Trivia { TrivPhrase = "#006 Alam mo bang nataguriang Queen City of the South ang Cebu?"},
				new Trivia { TrivPhrase = "#007 Alam mo bang ang mga sinunang Cebuano ay gumagamit ng alahas na yari sa ari ng hayop o tao?"},
				new Trivia { TrivPhrase = "#008 Alam mo bang karamihan sa mga salitang Cebuano ay sa wikang Espanyol rin nagmula?"},
				new Trivia { TrivPhrase = "#009 Alam mo bang ang Cebuano ay unang isinulat ni Antonio Pigafetta?"},
				new Trivia { TrivPhrase = "#010 Alam mo bang ang dialektong Cebuano ay mayroon lamang tatlong patinig noong panahon ng mga Espanyol?"},
				new Trivia { TrivPhrase = "#011 Alam mo bang may tinatawag ring Mindanao Cebuano, Luzon Cebuano, and Negrense Cebuano?"},
				new Trivia { TrivPhrase = "#012 Alam mo bang kaisa ang Cebuano sa Borneo-Philippines Languages?"},
				new Trivia { TrivPhrase = "#013 Alam mo bang ang Cebuano ay may 16 na katinig at limang patinig?"},
				new Trivia { TrivPhrase = "#014 Alam mo bang ang tawag sa mga nagsasalita ng Cebuano sa Luzon at Mindanao ay Binisaya?"},
				new Trivia { TrivPhrase = "#015 Alam mo bang ang tawag sa mga nagsasalita ng Cebuano sa Bohol ay Bol-anon?"},
				new Trivia { TrivPhrase = "#016 Alam mo bang ang Cebuano ang pangunahing dialekto sa Western Leyte?"},
				new Trivia { TrivPhrase = "#017 Alam mo bang noong 18th century nagsimulang gamitin ng mga Misyonaryong Espanyol ang dialektong Cebuano sa pagsusulat?"}
			};

			try
			{
				var db = new SQLiteConnection(path);
				if (db.InsertAll(data) != 0){
					db.UpdateAll(data);
				}
			}
			catch (SQLiteException ex)
			{
				Console.Write (ex.Message);
			}
		}

		public static string getRandomTrivia(){
			try
			{
				var db = new SQLiteConnection(path);

				string trivia = db.ExecuteScalar<string>("SELECT TrivPhrase FROM Trivia WHERE ID = " + Convert.ToString(new System.Random().Next(17) + 1));

				if(string.IsNullOrEmpty(trivia)){
					trivia = "0 returned";
				}
				return trivia;
			}
			catch (SQLiteException ex)
			{
				return ex.Message ;
			}
		}

		//end of Trivia Database

		//Tip Database

		private static void fillTip(){

			var data = new List<Tip>
			{
				new Tip { TipPhrase = "TIP 01: Kumausap ng mga taong mahusay mag-Cebuano"},
				new Tip { TipPhrase = "TIP 02: Wag pwersahin ang sarili sa pagkatuto"},
				new Tip { TipPhrase = "TIP 03: Magsimula muna sa mga ordinaryong salita"},
				new Tip { TipPhrase = "TIP 04: Basahin at gamitin ang diskyunaryo sa app na ito"},
				new Tip { TipPhrase = "TIP 05: Mag-ensayo ng mga pangungusap sa iyong isip"},
				new Tip { TipPhrase = "TIP 06: Tanggapin lamang na natural magkamali sa umpisa"},
				new Tip { TipPhrase = "TIP 07: Ang tamang pagbigkas sa mga salita ay mahalaga"},
				new Tip { TipPhrase = "TIP 08: Pakinggan mabuti ang mga tamang pagbigkas na maririnig dito"},
				new Tip { TipPhrase = "TIP 09: Ang madalas na paggamit ng mga natutunang salita ay makakatulong"},
				new Tip { TipPhrase = "TIP 10: Makinig o manuod ng mga palabas o tugtuging Cebuano"},
				new Tip { TipPhrase = "TIP 11: Gawing masaya ang pagkatuto ng Cebuano"},
				new Tip { TipPhrase = "TIP 12: Ang mga naipong \"coins\" ay maaring ipambili ng mga salita o ekspresyon"}
			};

			try
			{
				var db = new SQLiteConnection(path);
				if (db.InsertAll(data) != 0){
					db.UpdateAll(data);
				}
			}
			catch (SQLiteException ex)
			{
				Console.Write (ex.Message);
			}
		}

		public static string getRandomTip(){
			try
			{
				var db = new SQLiteConnection(path);

				string tip = db.ExecuteScalar<string>("SELECT TipPhrase FROM Tip WHERE ID = " + Convert.ToString(new System.Random().Next(12) + 1));

				if(string.IsNullOrEmpty(tip)){
					tip = "0 returned";
				}
				return tip;
			}
			catch (SQLiteException ex)
			{
				return ex.Message ;
			}
		}

		//end of Tip Database

		//Coins Database

		public static void addCoins(int intAmt){
			try
			{
				var db = new SQLiteConnection(path);

				db.Update(
					new Coins {ID = 1, CoinsCount = (intAmt + Convert.ToInt32(getCoins()))}
				);
			}
			catch (SQLiteException)
			{
			}
		}

		public static int getCoins(){
			try
			{
				var db = new SQLiteConnection(path);

				return db.ExecuteScalar<int>("SELECT CoinsCount FROM Coins WHERE ID = 1");
			}
			catch (SQLiteException)
			{
				return 0;
			}
		}

		public static void resetCoins(){
			try
			{
				var db = new SQLiteConnection(path);

				db.Update(
					new Coins {ID = 1, CoinsCount = 0}
				);
			}
			catch (SQLiteException ex)
			{
			}
		}

		public static void fillDictionary()
		{
			var mlistWords = new List<Dictionary> {
				new Dictionary {TagalogWord = "	abril	", CebuanoWord = "	abril	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	agad	", CebuanoWord = "	dayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	agosto	", CebuanoWord = "	agosto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ahas	", CebuanoWord = "	halas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	aking	", CebuanoWord = "	akong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ako	", CebuanoWord = "	nako	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	alalahanin	", CebuanoWord = "	hinumdomi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	alerto	", CebuanoWord = "	alisto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	alok	", CebuanoWord = "	ikalahad	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ampalaya	", CebuanoWord = "	ampalaya	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ampalaya	", CebuanoWord = "	amplaya	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	anak	", CebuanoWord = "	anak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	anay	", CebuanoWord = "	anay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	andito	", CebuanoWord = "	ania	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ang	", CebuanoWord = "	ang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ang	", CebuanoWord = "	ang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	aniya	", CebuanoWord = "	ania	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ano	", CebuanoWord = "	unsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ano	", CebuanoWord = "	unsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ano	", CebuanoWord = "	unsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ano	", CebuanoWord = "	unsa'y	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	anuman	", CebuanoWord = "	sapayan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	araw	", CebuanoWord = "	adlaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	araw-araw	", CebuanoWord = "	adlaw-adlaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	asawa	", CebuanoWord = "	banay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	aso	", CebuanoWord = "	iro	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ayusin	", CebuanoWord = "	pag-ayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	baba	", CebuanoWord = "	suwang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	babaan	", CebuanoWord = "	pagkanaog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	babae	", CebuanoWord = "	babaye	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	babae	", CebuanoWord = "	babae	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	babay	", CebuanoWord = "	babayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	baboy	", CebuanoWord = "	baboy	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bagalan	", CebuanoWord = "	paghinay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bagaman	", CebuanoWord = "	bisan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bago	", CebuanoWord = "	bag-o	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bahala	", CebuanoWord = "	bahala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	baka	", CebuanoWord = "	baka	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bakit	", CebuanoWord = "	ngano	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bakit	", CebuanoWord = "	ngano	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bakit	", CebuanoWord = "	nganong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	balakang	", CebuanoWord = "	bat'ang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	balikat	", CebuanoWord = "	abaga	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bangga	", CebuanoWord = "	bangga	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	basahin	", CebuanoWord = "	pagbasa 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bastos	", CebuanoWord = "	bastos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bawang	", CebuanoWord = "	ahos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bawasan	", CebuanoWord = "	kuhaan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bawa't	", CebuanoWord = "	matag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bayaw	", CebuanoWord = "	bayaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	baywang	", CebuanoWord = "	hawak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bibig	", CebuanoWord = "	baba	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bigote	", CebuanoWord = "	bigote	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	binti	", CebuanoWord = "	paa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bisperas	", CebuanoWord = "	bisperas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	biyenan	", CebuanoWord = "	ugangan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	biyernes	", CebuanoWord = "	biyernes	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	braso	", CebuanoWord = "	bukton	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	buhok	", CebuanoWord = "	buhok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bukang-liwayway	", CebuanoWord = "	kaadlawon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bukas	", CebuanoWord = "	ugma	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bukas	", CebuanoWord = "	ugma	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	buksan	", CebuanoWord = "	ablihi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bungantulog	", CebuanoWord = "	rawraw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	bungo	", CebuanoWord = "	bagol-bagol	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	buo	", CebuanoWord = "	tibuuk	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	butiki	", CebuanoWord = "	tabili	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	buwan	", CebuanoWord = "	bulan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	buwan	", CebuanoWord = "	bulan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	candy	", CebuanoWord = "	kamilitos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	cauliflower	", CebuanoWord = "	koliplor	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	daan	", CebuanoWord = "	dalan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	daga	", CebuanoWord = "	ilaga	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dagdagan	", CebuanoWord = "	dugangan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dala	", CebuanoWord = "	dala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	daliri	", CebuanoWord = "	tudlo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dibdib	", CebuanoWord = "	dughan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dila	", CebuanoWord = "	dila	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	din	", CebuanoWord = "	ra 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	diretso	", CebuanoWord = "	diretso	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	disyembre	", CebuanoWord = "	disyembre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	diyan	", CebuanoWord = "	diha	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dumating	", CebuanoWord = "	miabot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	dumating	", CebuanoWord = "	miabot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	enero	", CebuanoWord = "	enero	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gabi	", CebuanoWord = "	gabii	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gagamba	", CebuanoWord = "	lawa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gagamitin	", CebuanoWord = "	idapat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gagawin	", CebuanoWord = "	buhaton	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	galing	", CebuanoWord = "	gikan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	galit	", CebuanoWord = "	nasuko	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	galit	", CebuanoWord = "	naglagot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gamugamo	", CebuanoWord = "	anunugba	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ganoon	", CebuanoWord = "	ma-o	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	garbanzo beans	", CebuanoWord = "	garbanzos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gastador	", CebuanoWord = "	gastador	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gilagid	", CebuanoWord = "	lagos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gilid	", CebuanoWord = "	daplin	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gilid	", CebuanoWord = "	kilid	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gitna	", CebuanoWord = "	tungang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gumawa	", CebuanoWord = "	buhaton	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gumising	", CebuanoWord = "	magmata	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gusto	", CebuanoWord = "	gusto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gusto	", CebuanoWord = "	gusto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	gwapo	", CebuanoWord = "	gwapo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	habag	", CebuanoWord = "	looy	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	halik	", CebuanoWord = "	halok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hambog	", CebuanoWord = "	hambogero	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hamog	", CebuanoWord = "	yamog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hapon	", CebuanoWord = "	hapon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	harap	", CebuanoWord = "	atbang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hating	", CebuanoWord = "	tungang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hawak	", CebuanoWord = "	gunit	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hila	", CebuanoWord = "	bira	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hilain	", CebuanoWord = "	ibira	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hindi	", CebuanoWord = "	dili	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hipag	", CebuanoWord = "	bilas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hugas	", CebuanoWord = "	hugas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hulyo	", CebuanoWord = "	hulyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	hunyo	", CebuanoWord = "	hunyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	huwebes	", CebuanoWord = "	huwebes	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iba	", CebuanoWord = "	ubang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ibaba	", CebuanoWord = "	ipaubos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ibigay	", CebuanoWord = "	ihatag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ibon	", CebuanoWord = "	langgam	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ikaw	", CebuanoWord = "	ikaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ikaw	", CebuanoWord = "	ikaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ilong	", CebuanoWord = "	ilong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	inaasahan	", CebuanoWord = "	naglaum	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	inom	", CebuanoWord = "	inom	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ipagbili	", CebuanoWord = "	pagbaligya	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ipakilala	", CebuanoWord = "	ipaila	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ipakita	", CebuanoWord = "	ipakita	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ipis	", CebuanoWord = "	uk'uk	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	isa	", CebuanoWord = "	usa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	isagawa	", CebuanoWord = "	himoon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	isara	", CebuanoWord = "	isara	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	itaas	", CebuanoWord = "	ipataas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	itago	", CebuanoWord = "	itago	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	itik	", CebuanoWord = "	itik	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ito	", CebuanoWord = "	kini	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	itulak	", CebuanoWord = "	itulod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyak	", CebuanoWord = "	hilak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyo	", CebuanoWord = "	imong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyo 	", CebuanoWord = "	imo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyon	", CebuanoWord = "	kana	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyong	", CebuanoWord = "	imong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	iyong	", CebuanoWord = "	kanang 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaakit-akit	", CebuanoWord = "	makadani	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kabute	", CebuanoWord = "	libgos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kabutihan	", CebuanoWord = "	kamaayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kahapon	", CebuanoWord = "	gahapon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kahapon	", CebuanoWord = "	kagahapon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaibigan	", CebuanoWord = "	higala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaibigan	", CebuanoWord = "	higala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaibigan	", CebuanoWord = "	amigo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kailan	", CebuanoWord = "	kanus'a	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kailan	", CebuanoWord = "	anus'a	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kailangan	", CebuanoWord = "	magkinahanglan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kakain	", CebuanoWord = "	mangaon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kakilala	", CebuanoWord = "	kaila	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kalabitin	", CebuanoWord = "	tandog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kalagayan	", CebuanoWord = "	kahimtag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kalayo	", CebuanoWord = "	kalayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaliwa	", CebuanoWord = "	wala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kamag-anak	", CebuanoWord = "	paryente	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kamakailan	", CebuanoWord = "	bag-oha'y	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kamay	", CebuanoWord = "	kamot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kamay	", CebuanoWord = "	kamot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kamote	", CebuanoWord = "	kamote	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kanan	", CebuanoWord = "	too	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kanta	", CebuanoWord = "	kanta	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kapatid	", CebuanoWord = "	igsoon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kapatid	", CebuanoWord = "	igsoong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kapitbahay	", CebuanoWord = "	silingan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kasama	", CebuanoWord = "	kauban	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kasama	", CebuanoWord = "	kuyog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kasama	", CebuanoWord = "	uban	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kaya	", CebuanoWord = "	busa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kilay	", CebuanoWord = "	kilay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kuhain	", CebuanoWord = "	bakwi-a	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kuko	", CebuanoWord = "	kuko	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kuliglig	", CebuanoWord = "	kuliklik	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kumain	", CebuanoWord = "	nanga'on	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kumakain	", CebuanoWord = "	mokaon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kumusta	", CebuanoWord = "	komusta	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kuneho	", CebuanoWord = "	koneho	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kung	", CebuanoWord = "	kon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kung	", CebuanoWord = "	kon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kuwago	", CebuanoWord = "	mang'ak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	kwento	", CebuanoWord = "	sugilanon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	laban 	", CebuanoWord = "	batok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	labanos	", CebuanoWord = "	rabanos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	labas	", CebuanoWord = "	lab-as	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lakad	", CebuanoWord = "	padayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lakad	", CebuanoWord = "	lakaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lakad	", CebuanoWord = "	mouban	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lakad	", CebuanoWord = "	lakaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lalaki	", CebuanoWord = "	lalaki	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lalaki	", CebuanoWord = "	lalaki	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lalaki	", CebuanoWord = "	lalakiha	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lalamunan	", CebuanoWord = "	tutunlan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	langgam	", CebuanoWord = "	hulmigas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	langoy	", CebuanoWord = "	langoy	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lasa	", CebuanoWord = "	lami	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	leeg	", CebuanoWord = "	liog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	letsugas	", CebuanoWord = "	letsugas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	liko 	", CebuanoWord = "	liko	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	likod	", CebuanoWord = "	luyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	linggo	", CebuanoWord = "	domingo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	linggo	", CebuanoWord = "	semana	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lion	", CebuanoWord = "	liyon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lola	", CebuanoWord = "	lola	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lolo	", CebuanoWord = "	lolo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	luma	", CebuanoWord = "	daan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	lunes	", CebuanoWord = "	lunes	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	luya	", CebuanoWord = "	luy-a	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maalat	", CebuanoWord = "	parat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maanghang	", CebuanoWord = "	halang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maasim	", CebuanoWord = "	aslom	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabagal	", CebuanoWord = "	hinay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabagal	", CebuanoWord = "	hinayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabait	", CebuanoWord = "	buotan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabilis	", CebuanoWord = "	paspas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabuhay	", CebuanoWord = "	mabuhi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabuti	", CebuanoWord = "	maayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabuti	", CebuanoWord = "	buyno	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mabuti	", CebuanoWord = "	maayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magagawa	", CebuanoWord = "	mahimo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mag-alala	", CebuanoWord = "	mabalaka	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magalit	", CebuanoWord = "	masuko	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	katahom	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	ka-guapa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	pagkaanindot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	gwapa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	matahom	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maganda	", CebuanoWord = "	maanyag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magbantay	", CebuanoWord = "	pagbantay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maghintay	", CebuanoWord = "	paghulat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maghintay	", CebuanoWord = "	magpaabot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maghiwalay	", CebuanoWord = "	magbulag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maging malungkot	", CebuanoWord = "	maguul	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mag-ingat	", CebuanoWord = "	pag-amping	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magkano	", CebuanoWord = "	pila	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magkaroon	", CebuanoWord = "	naa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magmamadali	", CebuanoWord = "	pagdali	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magsalita	", CebuanoWord = "	sulti	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magsalita	", CebuanoWord = "	sulti	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magsama	", CebuanoWord = "	mag-uban	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magulang	", CebuanoWord = "	ginikanan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magulang	", CebuanoWord = "	ginikan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	magulang	", CebuanoWord = "	ginikanan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahal	", CebuanoWord = "	mahal	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahalaga	", CebuanoWord = "	mahinungdanon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahirap	", CebuanoWord = "	lisod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahirap	", CebuanoWord = "	gahi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahirap	", CebuanoWord = "	pobre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahirap	", CebuanoWord = "	kabus	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mahirap	", CebuanoWord = "	pobre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maigsi	", CebuanoWord = "	mubo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maikli	", CebuanoWord = "	mubo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maingat	", CebuanoWord = "	mainampingon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maintindihan	", CebuanoWord = "	mahibalo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maintindihan	", CebuanoWord = "	masayod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	makasarili	", CebuanoWord = "	hikawan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	makatanggap	", CebuanoWord = "	modawat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	makita	", CebuanoWord = "	motan-aw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	malaki	", CebuanoWord = "	dako	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	malaki	", CebuanoWord = "	dako	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	malamig	", CebuanoWord = "	makamig	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maliit	", CebuanoWord = "	gamay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maliit	", CebuanoWord = "	gamay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	malungkot	", CebuanoWord = "	magul'anon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	malusog	", CebuanoWord = "	himsog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mamalo	", CebuanoWord = "	latus	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mamatay	", CebuanoWord = "	mamatay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mamaya	", CebuanoWord = "	taod-taod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mamaya na	", CebuanoWord = "	unya	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	manok	", CebuanoWord = "	manok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	manugang na babae	", CebuanoWord = "	binalaye	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	manugang na lalaki	", CebuanoWord = "	masamong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapagbigay	", CebuanoWord = "	mahinatagon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapagpakumbaba	", CebuanoWord = "	maaghup	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapait	", CebuanoWord = "	pait	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapakla	", CebuanoWord = "	aplod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapasikat	", CebuanoWord = "	garboso	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapayat	", CebuanoWord = "	daut	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapayat	", CebuanoWord = "	niwang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mapera	", CebuanoWord = "	dato	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	marami	", CebuanoWord = "	daghan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	marso	", CebuanoWord = "	marso	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	martes	", CebuanoWord = "	martes	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masalita	", CebuanoWord = "	tabi-an	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masama	", CebuanoWord = "	daotan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masasabi	", CebuanoWord = "	ikasulti	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masaya	", CebuanoWord = "	nalipay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masaya	", CebuanoWord = "	magpalipayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masaya	", CebuanoWord = "	malipayon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masipag	", CebuanoWord = "	kugihan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	masusunod	", CebuanoWord = "	masunod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mata	", CebuanoWord = "	mata	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mataas	", CebuanoWord = "	taas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mataba	", CebuanoWord = "	tambok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matalino	", CebuanoWord = "	utokan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matalino	", CebuanoWord = "	maantigo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matalino	", CebuanoWord = "	makahibalo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matamis	", CebuanoWord = "	pagkatam-is	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matatakot	", CebuanoWord = "	nahadlok	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matipid	", CebuanoWord = "	daginutan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matulog	", CebuanoWord = "	matulog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	matulungin	", CebuanoWord = "	matinabangon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	maunawain	", CebuanoWord = "	masinabtanon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mawalan	", CebuanoWord = "	pakawala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mayaman	", CebuanoWord = "	dato	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mayaman	", CebuanoWord = "	sapian	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mayo	", CebuanoWord = "	mayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mayroon	", CebuanoWord = "	dunay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	miyerkules	", CebuanoWord = "	miyerkules	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mo	", CebuanoWord = "	nimo 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mo	", CebuanoWord = "	mo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	monggo	", CebuanoWord = "	monggo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mukha	", CebuanoWord = "	aping	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mura	", CebuanoWord = "	barato	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	mustasa	", CebuanoWord = "	mostasa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	na	", CebuanoWord = "	na	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	na 	", CebuanoWord = "	nga	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagagalak	", CebuanoWord = "	malipay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nag-anyaya	", CebuanoWord = "	miagda	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagdadalawang-isip	", CebuanoWord = "	nagduha-duha	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	naglakad-lakad	", CebuanoWord = "	nagsuroy-suroy	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagpadala	", CebuanoWord = "	nagpadala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagsabi	", CebuanoWord = "	nagsulti	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagsabi	", CebuanoWord = "	nag'ingon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagtatago	", CebuanoWord = "	nagtago	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagtataka	", CebuanoWord = "	nahibulong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nagtataka	", CebuanoWord = "	natingala	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nais	", CebuanoWord = "	buut	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nakaraan	", CebuanoWord = "	miaging	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nakaraan	", CebuanoWord = "	miaging	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nakatira	", CebuanoWord = "	nagpuyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nakatira	", CebuanoWord = "	magpuyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nakuha	", CebuanoWord = "	nagkuha	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nalaman	", CebuanoWord = "	pagkahibalo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nanalo	", CebuanoWord = "	midaog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nanalo	", CebuanoWord = "	nakadaog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nanay	", CebuanoWord = "	inahan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nanginginig	", CebuanoWord = "	nagpangurog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nangyari	", CebuanoWord = "	nahitabo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nangyari	", CebuanoWord = "	pagkahitabo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	napaka	", CebuanoWord = "	kaayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nasa	", CebuanoWord = "	anaa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	natanggap	", CebuanoWord = "	nadawat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	natanggap	", CebuanoWord = "	nadawat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ng 	", CebuanoWord = "	og 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngayon	", CebuanoWord = "	karon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngayon	", CebuanoWord = "	karon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngayong araw	", CebuanoWord = "	karong adlawa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngayong gabi	", CebuanoWord = "	karong gabii	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngipin	", CebuanoWord = "	ngipon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ngiti	", CebuanoWord = "	pahiyom	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	niyan	", CebuanoWord = "	niana	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	nobyembre	", CebuanoWord = "	nobyembre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	noo	", CebuanoWord = "	agtang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	noong	", CebuanoWord = "	niadtong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	oktubre	", CebuanoWord = "	oktubre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paa	", CebuanoWord = "	tiil	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paalam	", CebuanoWord = "	adiyos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paano	", CebuanoWord = "	unsaon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paano	", CebuanoWord = "	giunsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paano	", CebuanoWord = "	naunsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paano	", CebuanoWord = "	unsaon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pabaya	", CebuanoWord = "	dangag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pabili	", CebuanoWord = "	paliton	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pag-asa	", CebuanoWord = "	paglaum	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pagdating	", CebuanoWord = "	pag-abot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pagitan	", CebuanoWord = "	kapulihay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pagkakamali	", CebuanoWord = "	pagkasayup	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pakiusap	", CebuanoWord = "	palihug	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palagi	", CebuanoWord = "	kanunay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palagi	", CebuanoWord = "	kanunay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palaka	", CebuanoWord = "	baki	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palakaibigan	", CebuanoWord = "	mahigalahon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palakaibigan	", CebuanoWord = "	mahigalahon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palakpak	", CebuanoWord = "	pakpak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	palitan	", CebuanoWord = "	pag-ilis	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pamangkin	", CebuanoWord = "	pag-umangkon 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pamilya	", CebuanoWord = "	banay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangalan	", CebuanoWord = "	ngalan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangalan	", CebuanoWord = "	ngalan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangit	", CebuanoWord = "	ngil'ad	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangit	", CebuanoWord = "	kamaot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangit	", CebuanoWord = "	laksot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pangit	", CebuanoWord = "	ma-ot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	panika	", CebuanoWord = "	kulaknit	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paradahan	", CebuanoWord = "	paradahan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paruparu	", CebuanoWord = "	kabakaba	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	patawarin	", CebuanoWord = "	gikasubo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	patola	", CebuanoWord = "	sikwa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	patungo	", CebuanoWord = "	paingon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	patungo	", CebuanoWord = "	padulong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	paumanhin	", CebuanoWord = "	tabi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pebrero	", CebuanoWord = "	pebrero	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pechay	", CebuanoWord = "	petsay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	piga	", CebuanoWord = "	puga	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pili	", CebuanoWord = "	pili	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pilipitin	", CebuanoWord = "	salapid	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pinsan	", CebuanoWord = "	ig'agaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pipino	", CebuanoWord = "	pipino	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	presyo	", CebuanoWord = "	presyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	problema	", CebuanoWord = "	kabilinggan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pulso	", CebuanoWord = "	pulso	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pumunta	", CebuanoWord = "	nangadto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pupunta	", CebuanoWord = "	mangatdo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	puro	", CebuanoWord = "	pulus	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pusa	", CebuanoWord = "	iring	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	puso ng saging	", CebuanoWord = "	puso sa saging	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	pusod	", CebuanoWord = "	pusod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	repolyo	", CebuanoWord = "	repolyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sa	", CebuanoWord = "	sa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sa atin	", CebuanoWord = "	kanato	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sa katunayan	", CebuanoWord = "	gayod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	saan	", CebuanoWord = "	asa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	saan	", CebuanoWord = "	hain	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	saan	", CebuanoWord = "	hain	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	saan	", CebuanoWord = "	asa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	saan	", CebuanoWord = "	diin	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sabado	", CebuanoWord = "	sabado	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sabihin	", CebuanoWord = "	ipasabot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sakayan	", CebuanoWord = "	pagsakay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sakitin	", CebuanoWord = "	masakiton	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	salamat	", CebuanoWord = "	salamat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	samahan	", CebuanoWord = "	ubanan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sampal	", CebuanoWord = "	sagpa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sasabihin	", CebuanoWord = "	sultihan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sasama	", CebuanoWord = "	mokuyog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sasama	", CebuanoWord = "	manguyog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sayaw	", CebuanoWord = "	sayaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sayo	", CebuanoWord = "	sayo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	septyempre	", CebuanoWord = "	septyempre	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sibuyas	", CebuanoWord = "	sibuyas	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sigaw	", CebuanoWord = "	singgit	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sige	", CebuanoWord = "	sige	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sigurado	", CebuanoWord = "	segurado	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sikat	", CebuanoWord = "	gibantog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sinabi	", CebuanoWord = "	gisultihan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sinagot	", CebuanoWord = "	balusi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sino	", CebuanoWord = "	kinsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sino	", CebuanoWord = "	kinsa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sinsero	", CebuanoWord = "	matinuuron	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sipa	", CebuanoWord = "	sipa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sitaw	", CebuanoWord = "	balatong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	spinach	", CebuanoWord = "	ispinaka	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	suka	", CebuanoWord = "	suka	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sulatan	", CebuanoWord = "	sulati	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sumagot	", CebuanoWord = "	pagtubag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sumagot	", CebuanoWord = "	mosugot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sumisigaw	", CebuanoWord = "	nagsinggit	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sunod	", CebuanoWord = "	sunod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	suntok	", CebuanoWord = "	sumbag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	suso	", CebuanoWord = "	umang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	susulatan	", CebuanoWord = "	mosulat	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	sususod	", CebuanoWord = "	umaabot	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	taas	", CebuanoWord = "	taas 	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tahimik	", CebuanoWord = "	hilumon	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tainga	", CebuanoWord = "	dalunggan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	takbo	", CebuanoWord = "	dagan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	talaga	", CebuanoWord = "	lagi	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	talaga	", CebuanoWord = "	bitaw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	talon	", CebuanoWord = "	lukso	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tamad	", CebuanoWord = "	tapulan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tamis	", CebuanoWord = "	tam-is	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tanggihan	", CebuanoWord = "	mobalibad	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tanghali	", CebuanoWord = "	udto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tanghali	", CebuanoWord = "	udto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tanghali	", CebuanoWord = "	udto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	taon	", CebuanoWord = "	tuig	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tapon	", CebuanoWord = "	labay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tara na	", CebuanoWord = "	tana	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tatakan	", CebuanoWord = "	tindak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tatay	", CebuanoWord = "	amahan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tawa 	", CebuanoWord = "	katawa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tawag	", CebuanoWord = "	tawag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tigil	", CebuanoWord = "	hunong	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tinatanong	", CebuanoWord = "	nangutana	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tingnan	", CebuanoWord = "	tan'awa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tita	", CebuanoWord = "	tiya	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tita	", CebuanoWord = "	iyaan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tito	", CebuanoWord = "	tiyo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tito	", CebuanoWord = "	uyuan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tiyan	", CebuanoWord = "	tiyan	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	totoo	", CebuanoWord = "	tinuod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tuhod	", CebuanoWord = "	tuhod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tulak	", CebuanoWord = "	tulod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumango	", CebuanoWord = "	tando	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumatawa	", CebuanoWord = "	nagkatawa	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumayo	", CebuanoWord = "	pagtindog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumayo	", CebuanoWord = "	tindog	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumingin	", CebuanoWord = "	tan-aw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tumitingin	", CebuanoWord = "	nagtan-aw	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	tunay	", CebuanoWord = "	diay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ubo	", CebuanoWord = "	ubo	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	ulit	", CebuanoWord = "	usab	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	umaga	", CebuanoWord = "	buntag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	umaga	", CebuanoWord = "	buntag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	umalis	", CebuanoWord = "	miadto	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	umiiyak	", CebuanoWord = "	naghilak	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	unggoy	", CebuanoWord = "	unggoy	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	upang	", CebuanoWord = "	aron	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	upo	", CebuanoWord = "	lingkod	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	upo	", CebuanoWord = "	tabayag	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	wala	", CebuanoWord = "	wala'y	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	wala	", CebuanoWord = "	gidili	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	walang kuwenta	", CebuanoWord = "	binuang	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	walis	", CebuanoWord = "	silhig	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	wow	", CebuanoWord = "	ayay	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	yakap	", CebuanoWord = "	gakos	", Cost = 0, Status = 0},
				new Dictionary {TagalogWord = "	yan	", CebuanoWord = "	niana	", Cost = 0, Status = 0},

			};

			try
			{
				var db = new SQLiteConnection(path);
				if (db.InsertAll(mlistWords) != 0)
				{
					db.UpdateAll(mlistWords);
				}
			}
			catch (SQLiteException)
			{

			}
		}

		public static void fillPhrases(){
			var peopleList = new List<Phrases>
				{
					new Phrases { TagalogPhrase = "Magandang Hapon", CebuanoPhrase = "Maayong hapon.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Araw", CebuanoPhrase = "Maayong adlaw sa imo.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Gabi", CebuanoPhrase = "Maayong gabii.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Goodluck", CebuanoPhrase = "Maayo unta swertihon!", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Umaga", CebuanoPhrase = "Maayong buntag.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Hello, Kumusta ka?", CebuanoPhrase = "Uy, kumusta man ka?", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Hindi ko maintindihan.", CebuanoPhrase = "Wala ko kasabot.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Naiintidihan ko.", CebuanoPhrase = "Nakasabot ko.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Ayos lang ako.", CebuanoPhrase = "Maayo man ko.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Matagal na panahong di nagkita.", CebuanoPhrase = "Dugayng panahon wala ta nagkita", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Ang pangalan ko ay Juan.", CebuanoPhrase = "Ang akong ngalan kay Juan.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Maligayang Pagdating.", CebuanoPhrase = "Maayong pag-abot", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Anong pangalan mo?", CebuanoPhrase = "Unsa'y imong ngalan?", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Taga-saan ka?", CebuanoPhrase = "Taga-asa ka?", Cost = 0, Status = 0}
				};
				try
				{
					var db = new SQLiteConnection(path);
					if (db.InsertAll(peopleList) != 0)
					{
						db.UpdateAll(peopleList);
					}
				}
				catch (SQLiteException)
				{

				}
		}

		private int findNumberRecords(){
			
			try{
				var db = new SQLiteConnection(path);
				// this counts all records in the database, it can be slow depending on the size of the database
				var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Phrases");

				// for a non-parameterless query
				// var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

				return count;
			}catch (SQLiteException){
				return -1;
			}
		}
	}

}

