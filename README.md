

# ASPNetMongoDB

Detta projekt är en mall för en ASP.net MVC sida som använder sig av MongoDB.

Skrivet av Marcus Medina & ChatGPT en alldeles för sen natt, därav blev det en MongoDB baserad databas för att hålla koll på katter.

## Baktankar
1.  Att med detta projekt få er att ge upp Consolen när ni nu kan se hur lätt det är att arbeta med ASP.net och MongoDB.
2. I vanliga fall börjar man aldrig från Scratch, så varför inte ha en färdig mall för ASP.net MVC Core MongoDB som alla kan ha som en startpunkt, så slipper ni konfigurera och krångla med allt annat.
3. Att ni ska ha roligt med ASP.net  

## Tips
+ Använd Atom för att skapa snygga layouter, och klistra sedan in det i ASP.net sidorna.
+ Kolla hur katt-Context klassen är gjord, så kan du lätt skapa en egen.
+ Skapa egna modeller i stil med kattmodellen så är det bara att använda **MongoDBHandler\<MinModell\>** och då har ni tillgång till databasen och ni kan leka med ASP.net i lugn och ro.
+ Kolla in [Boootstrap](https://getbootstrap.com/docs/5.3/examples/)
+ Kolla in [Tailwind](https://tailwindui.com/templates)
+ Läs på om [HTML](https://www.w3schools.com/html/)
 
## Disclaimer
MongoDBHandlern läser en fil från Users\{you!}\Mina dokument\ med connectionsString. Det finns snyggare sätt men då det varit problem med att koppla sig till Azure skippade jag Azures Vault i detta exempel. Det kommer i framtida uppdateringar. 

## Klasserna
Projektet innehåller en del klasser, och många kommentarer.

### Database
Denna mapp innehåller två klasser

#### MongoDBHandler
MongoDBHandler är en generisk klass som kan anpassa sig till alla modeltyper den får. I constructorn läser den in en textfil med connectionstring.

**Metoder**
+ Contructorn - Den tar emot parametrar för databasnamn och collectionnamn
+ Create - tar emot ett objekt som den sparar som JSON i databasen
+ Delete - tar emot ett Id och raderar objektet med det Id
+ Get - Tar emot ett Id och hämtar det objektet
+ GetByValue - tar emot två parametrar en för nyckeln man söker på och ett för värdet man söker
+ GetAll - Hämtar hem alla dokument i databasen och returnerar en lista
+ GetAll - tar emot parametrar för nyckel och värde och hämtar alla matchande
+ Update - tar emot ett Id och ett objekt, sparar objektets information på Id som angavs
+ DeleteAll - Raderar alla dokument i collection

#### MongoDBContext
Den använder sig av MongoDBHandler för att Cruda katter

+ CreateCat - skapar en katt
+ DeleteAllCats - raderar alla katter
+ DeleteAllCatsByColor- Raderar alla katter med en viss färg
+ DeleteCat - tar emot ett Id och raderar den katten
+ GetAllCats - hämtar en lista på alla katter
+ GetAllCatsByColor - hämtar en lista på alla katter som matchar en viss färg
+ GetCat - hämtar en katt enligt angivet Id
+ UpdateCat - Uppdatera katt

Observera att den inte använder alla metoder, fyll gärna på med funktionalitet

### Models
Detta exempel har bara en modell

#### Cat
Katten har tre egenskaper
+ Id (BsonId)
+ Name (sträng)
+ Color (Sträng)

### Controllers
Det finns bara en controller, och den har tillhörande vyer, dock kommer vyerna inte att beskrivas här

#### CatsController
I construktorn skapas en instans av Contexten
Sedan är det bara vanliga Crud metoder, men istället för Entity Framework som vi brukar ha på Asp.net så kör vi med vår egen Contextklass för att köra CRUD.

