# Scada sistem
Predmetni projekat iz Softversko nadzorno upravljačkih sistema upotrebom WCF-a i Entity Framework-a.
Projekat se sastoji od sledećih funkcionalnosti:
  - Dodavanje i uklanjanje analognih i digitalnih tagova
   - Registraciju i prijavljivanje korisnika za korišćenje DatabaseManager-a.
  - Upisivanje vrednosti izlaznih tagova i prikaz njihovih trenutnih vrednosti preko DatabaseManager aplikacije.
  - Uključivanje i isključivanje skeniranja ulaznih tagova (on/off scan).
  - Prikaz trenutnih vrednosti ulaznih tagova sistema preko Trending aplikacije.
  - Čitanje i pisanje konfiguracije sistema iz/u fajl scadaConfig.xml pri pokretanju/zaustavljanju SCADA sistema. U konfiguracionom fajlu se uvek mora naći najsvežija konfiguracija sistema.
  - Povezivanje (pretplatu) sistema na neki Real-Time Unit (publisher ).
  - Čuvanje (perzistenciju) vrednosti tagova u bazi podataka.
  - Dodavanje i uklanjanje alarma za analogne ulaze. Alarmi imaju sledeća svojstva: tip (low,
  high), prioritet (1,2,3), graničnu vrednost (prag) i ime veličine na koju je vezan alarm.
  - Ispis informacija o alarmima koji se dese u fajl alarmsLog.txt, kao i u bazu podataka.
  - Prikaz alarma koji se dese u sistemu preko Alarm Display klijenta. Alarmi n-tog prioriteta
  se prikazuju n puta zaredom.
  - Čitanje/pisanje konfiguracije alarma iz/u fajl alarmConfig.xml pri pokretanju/zaustavljanju SCADA sistema. U konfiguracionom fajlu se nalazi najsvežija konfiguracija alarma SCADA aplikacije
  - Prikaz različitih vrsta izveštaja preko Report Manager klijenta:
    - Svi alarmi koji su se desili u određenom vremenskom periodu (sortiranje: prioritet,
    vreme).
    - Svi alarmi određenog prioriteta (sortiranje: vreme).
    - Sve vrednosti tagova koje su dospele na servis u određenom vremenskom periodu
    (sortiranje: vreme).
    - Poslednja vrednost svih AI tagova (sortiranje: vreme).
    - Poslednja vrednost svih DI tagova (sortiranje: vreme).
    - Sve vrednosti taga sa određenim identifikatorom (sortiranje: vrednosti).
    
# Softverska arhitektura sistema definisana je na sledeći način:
![image](https://user-images.githubusercontent.com/102969313/188267039-fae446d5-6934-4602-8e18-c9765f02ca51.png)

- Opis:
  - Real-Time Unit (RTU) imitira merni uređaj na terenu, koji vrši očitavanje vrednosti
  (jedne) “stvarne” veličine i šalje podatke o toj veličini na servis. RTU ima svoj identifikator, gornju i donju granicu za (nasumične) vrednosti koje šalje, kao i adresu Real-Time
  Driver-a na koju će slati pomenute vrednosti (ova adresa je jedinstvena za svaki RTU).
  Ove opcije se unose ručno prilikom pokretanja uređaja/aplikacije. Poruke sa svakog RTU
  (ima ih više) se digitalno potpisuju i proveravaju na servisu pre upisivanja u bazu ili slanja
  ostalim WCF klijentima
  - Database Manager dodatno omogućava definisanje alarma za veličine.
  - Alarm Display preko interfejsa ispisuje na konzoli sve alarme koji se dese u sistemu
  zajedno sa tipom alarma, vremenom aktivacije alarma i imenom veličine nad kojom se
  desio alarm.
  - Report Manager preko jednostavnog menija omogućava prikaz gorepomenutih izveštaja.
  - SCADA Core predstavlja jezgro SCADA sistema. Nova verzija jezgra sadrži i RealTime Driver, koji omogućava upisivanje vrednosti pristiglih sa RT uređaja na određenu
  adresu, kao i njihovo očitavanje.


