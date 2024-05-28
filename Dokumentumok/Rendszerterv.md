# Progtech beadandónk rendszerterve

## A rendszer célja
Projektünk célja egy olyan nyilvántartó rendszer létrehozása, ami segíti és megkönnyíti a menhelyen dolgozók életét. Egy egyszerű, letisztult rendszer, ahol egy adatbázisban láthatják a menhelyen lévő állatokat, külön Örökbefogadó résszel, ahol az örökbeadandó állatokhoz hozzákapcsolhatnak informáiókat, úgy mint az Örökbefogadó család neve, lakhelye illetve telefonszáma. A főoldalon pedig számszerűsítve láthatják hány állat tartózkodik a menhelyen, hány lett örökbefogadva, illetve hányan nem.

## Projektterv
### Projektszerepkörök és felelősségük:
- Kiss Dalma: Fejlesztő, adminisztrátor, tesztelő
- Földi Krisztina: Fejlesztő, adminisztrátor, tesztelő

### Ütemterv
| Funkció / Story | Feladat / Task | Becslés | Eltelt idő | Hátralévő idő |
| --- | --- | --- | --- | --- |
| Megbeszélések | Feladatkörök kiosztása, projekt témájának rögzítése | 6 | 4 | 2 |
| Rendszerterv |  | 16 | 12 | 4 |
| Adattárolás, Adatbázis | Adatmodell megtervezése, Adatbázis megvalósítása | 6 | 4 | 2 |
| Login felület | Login/Register felület készítése | 8 | 4 | 4 |
| Crud műveletek |  | 8 | 4 | 4 |

## Üzleti folyamatok modellje
### Üzleti szereplők
A rendszerhez regsiztrált felhasználók tudnak hozzáférni, azonban a Login felületen van lehetőség új felhasználó hozzáadására is. A login oldalon, amennyiben nem töltjük ki helyesen az adatokat, úgy hibaüzenetet kapunk, ellenkező esetben bedob minket a főoldalra.
Regisztrációkor, ha már meglévő embert szeretnénk hozzáadni, úgy hibaüzenetet dob ki, illetve akkor is, ha az űrlapot üresen akarjuk elküldeni. Ha minden adatot helyesen töltöttünk ki, a Register gombbal tudjuk regsiztrálni magunkat.

### Üzleti folyamatok
Sikeres bejelentkezést követően, a főoldalon azt láthatjuk, hány állat tartózkodik a menhelyen, hányat adtak örökbe, továbbá mennyi kiskedvenc várakozik örökbefogadásra.
Oldalt a menük közt navigálva tovább láthatjuk az "Add Pet" funkciót, ahol a táblázathoz hozzá adhatjuk az újonnan beérkező állatot, miután megadtuk a szükséges adatokat. Meg kell adni a kiskedvenc azonosító kódját, a nevét, a fajtáját, a korát, illetve, hogy van-e már jelentkező az örökbefogadásra. 
Van lehetőség az adatok módosítására, a táblázatban kijelöljük az adott állatot, átírjuk a változó adatot, majd az UPDATE gombbal tudjuk frissíteni. Van lehetőség adat törlésre is, amennyiben mondjuk az örökbeadás már befejeződött, illetve ha elkezdtük kitölteni az adatokat, de meggondoltuk magunkat, úgy a CLEAR gombbal kitudjuk törölni az űrlapot.
A harmadik menüpont az állatok örökbeadásának megkezdése, az ADOPTION menüpont alatt. Miután megadtuk az állat azonosítóját, nevét, korát, illetve a státuszt átállítottuk 'YES'-re, úgy ki tudjuk tölteni az örökbefogadó család adatait, és az UPDATE lenyomásával már frissítettük is az adatbázist, melyet jobb oldalt láthatunk. Szintúgy mint az előző menüpontnál, ha menet közben meggondolnánk magunkat, a CLEAR gombbal tudjuk törölni az űrlapot.

Ha minden feladattal végeztünk, úgy a LOGOUT gomb segítségével ki tudunk jelentkezni, ekkor visszadob a LOGIN felületre, ahol a jobb felső sarokban látható X segítségével tudjuk bezárni a programot.

## Követelmények
### Funkcionális követelmények
#### Menüpontok az oldalon:
- Dashboard
- Add Pet
- Adopton
- Logout

#### Nem funkcionális követelmények
- Letisztult kinézet
- User friendly felület
- Könnyű navigálhatóság

### Törvényi előírások, szabványok:

- GDPR-nak való megfelelés
- Általános információk
- Szellemi tulajdon
- Használat
- Felelősségi szabályok
- Technikai követelmények
- Garancia és kártérítés
- mmxiii. évi V. törvény
- Európai Parlament és Tanács 2016. április 27-i (EU) 2016/679 Rendelete
- mmxi. évi CXII. törvény
- a szerzői jogról szóló 1999. évi LXXVI. törvény
- mmi. évi CVIII. törvény

## Funkcionális terv
- Rendszerszereplők: A felhasználók, mivel egy menhely adatbázis használói már amúgy is egy szűkebb kör, így nincs külön Admin felület, de a használat regisztrációhoz kötött.

- Felhasználók: A menhelyre újonan érkező állatokat hozzáadhatják a rendszerhez, módosíthatják az adataikat, törölhetik őket miután az örökbeadás sikeres volt, illetve láthatják a menhelyen jelenleg tartózkodó állatokat.

- Menü-hierarchiák:
    - Dashboard: Információt nyújtó oldal
    - Add pet: Állat hozzáadása, frissítése, törlése
    - Adoption: Állat örökbeadásának elkezdése
    - Logout: kijelentkezés

## Fizikai környezet:
Eszközök, melyeket a fejlesztéshez használtunk:
- Visual Studio Code
- Notepad
- GitKraken
- GitHub
- Trello

## Architekturális terv
A rendszer megfelelő működéséhez adatbázisra van szükség, jelen esetben ez egy helyi Local adatbázis, ami a Visual Studio-n belül érhető el.

## Tesztterv

A tesztelések célja a nyilvántartó rendszer helyességének és megfelelő módon történő működésének ellenőrzése, a rendszer által megvalósított üzleti szolgáltatások verifikálása.

### Unit és Alfa teszt

A teszt elsődleges célja az eddig meglévő funkciók tesztelése folyamatosan, még a fejlesztés időtartama alatt. Ezt a tesztet a fejlesztők végzik, és az eljárás akkor sikeres, ha a különböző funkciók megfelelően működnek a különböző böngészőkben és operációs rendszereken. A teszt időtartama egy hét.

### Beta teszt

A tesztelő felhasználók visszajelzései alapján a probléma vagy hiba kiküszöbölése ennek a tesztnek a feladata. Ha hibát találnak a tesztelő felhasználók, a fejlesztők feladata a Beta teszt időszakában a lehető leghamarabb kijavítani azt. A teszt időtartama egy hét, azonban ha túl sok hiba merül fel, a teszt közben, akkor a tesztelés elhúzódhat plusz egy héttel.


## Karbantartási terv

Az alkalmazás folyamatos üzemeltetése és karbantartása, amely magába foglalja a programhibák elhárítását, a belső igények változása miatti módosításokat, valamint a környezeti feltételek változása miatt megfogalmazott program-, illetve állomány módosítási igényeket.

### Adatbázis karbantartása

- Időnként ellenőrizni kell, hogy az adatbázis megfelelően működik-e, vagyis jól működik-e a rendszer nagy mennyiségű adattal, nincsenek-e duplikált értékek, stb.
- Az adatbázisban felmerülő hiba esetén be kell ütemezni a webszerver átmeneti leállítását és erről értesíteni kell a felhasználókat.


### Karbantartás folyamata

- Corrective Maintenance: A felhasználók által beküldött hibajelentésekben szereplő hibák kijavítása.
- Adaptive Maintenance: A program naprakészen tartása, finomhangolása.
- Perfective Maintenance: A szoftver hosszútávú működése érdekében végzett módosítások, mint például az új funkciók.
- Preventive Maintenance: Olyan problémák elhárítása, kijavítása, amelyek még nem tűnnek fontosnak, de később komoly problémákat okozhatnak.