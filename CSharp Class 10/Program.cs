using System;

namespace CSharp_Class_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tulajdonság használata (Student osztályok):
            var student1 = new Studentv2();

            // Meghívjuk a settert, ahol a speciális value-ba az "A" string fog kerülni
            student1.Name = "A";
            // Meghívjuk a gettert, ahonnan az imént beírt "A" string olvasódik ki
            Console.WriteLine(student1.Name);

            // Auto-property
            var student2 = new Studentv3();

            // Meghívódik az automatikusan generált settert és beíródik az automatikusan generált adattagba az "A" string
            student2.Name = "A";

            // Meghívódik az automatikusan generált getter és visszaadja az imént beírt "A" stringet
            Console.WriteLine(student2.Name);

            // Természetesen az osztályon kívül sem írható a csak getter-t tartalmazó tulajdonság
            var student3 = new Studentv4("A");
            //student3.Name = "B"; // Nem megy

            // Csak az osztályon belül írható a tulajdonság
            var student4 = new Studentv5("A");
            //student4.Name = "B"; // Nem megy

            // A tulajdonságok miatt gyakorlatilag soha nem szoktunk getter-setter metódusokat használni, mindig tulajdonságot hozunk létre

            // Mikor használjunk tulajdonságot és mikor adattagot?
            // Ha kívülről nem látható az adat, akkor csináljunk egy privát adattagot
            // Egyébként tulajdonságot

            // Bár fontos megjegyezni, hogy ha valamilyen speciális algoritmus kell az adattag írásához vagy olvasásához, akkor nyugodtan használható, sőt ajánlott akár privát, akár publikus tulajdonság

            // Mostmár négy dolgot készíthetünk egy osztályban: adattagokat, tulajdonságokat, konstruktorokat és metódusokat (bár az utolsó kettő lényegében ugyanaz, hisz a konstruktor egy speciális metódus)

            //--------------------------------------------------

            // Vegyük észre, hogy a dictionaryket "indexelhetjük" a [] szimbólumokkal, pedig nem tömbök
            // Készíthetünk olyan osztályt amit indexelhetünk?
            // Igen, csak egy indexer segítségével meg kell adnunk mi történjen indexeléskor (Example2):
            var example1 = new Example2(10);

            // A kettő ugyanazt csinálja, csak az egyik a konkrét tömböt, a másik az indexert használja
            example1.array[0] = 1;
            example1[0] = 1; // Indexeren keresztüli írás

            // A kettő ugyanazt csinálja, csak az egyik a konkrét tömböt, a másik az indexert használja
            Console.WriteLine(example1.array[0]);
            Console.WriteLine(example1[0]); // Indexeren keresztüli olvasás
            
            // Az indexer valójában tetszőleges típust átvehet és tetszőleges logikát megvalósíthat:
            var example2 = new Example3();
            example2["0"] = "1";
            Console.WriteLine(example2["10"]);

            // Nagyon ritkán készítünk indexereket, mivel ránézésre sokszor nehéz megmondani, hogy pontosan milyen műveletet végez az adott objektumon, hiszen nincs neve ami legalább valami támpontot adna
            // Emiatt csak olyan esetben használjuk, ha egyértelmű a célja

            //--------------------------------------------------

            // Mi történik akkor, ha két általunk készített osztályt próbálunk mondjuk összeadni?
            // Hiba:
            var example3 = new Example4();
            var example4 = new Example4();
            //var n = example3 + example4; // Nem megy

            // Miért van ez?
            // Azért, mert soha nem mondtuk meg, hogy mit jelent két Example4 összeadása!

            // Meg tudjuk mondani?
            // Igen! Az operátorok (+, -, /, * stb.) is metódusok lényegében és C#-ban felül is tudjuk írni őket:
            var example5 = new Example5();
            var example6 = new Example5();

            var i1 = example5 + example6;

            // Sőt a paraméterlistát is testreszabhatjuk:
            var example7 = new Example5();
            var i2 = example7 + 0;

            // Fontos! A sorrend nem mindegy!
            // A túléterhelt operátor első paramétere az operátor bal oldalával egyezik meg, a második paramétere pedig a jobb oldallal
            // Azaz ez már nem megy:
            //var i3 = 0 + example7; // Nem megy

            // Ahhoz, hogy menjen a fordított sorrendet is meg kell valósítanunk -> operator +(int a, Example5 e)!

            // Sőt a visszatérési típust is mi magunk adhatjuk meg:
            var example8 = example7 + 1.0; // example8 egy Example5 példány

            // Az operátorok túlterhelését is viszonylag ritkán használjuk, mivel a legtöbb osztály esetén nem lenne egyértelmű mi fog történni, illetve rengeteg problémát is okozhat
            
            // Probléma:
            var example9 = new Example6();

            // Hamis lesz!
            if (example9 == example9)
            {

            }

            // Ennél nagyobb gondot is okozhatunk:
            var example10 = new Example7();

            // Még nagyobb gond:
            /*if (example10 == example10)
            {

            }*/

            // Érdekes módon az implicit és explicit típuskényszerítést is túlterhelhetjük, amivel aztán végképp eltörhetünk mindent:

            // Implicit:
            var example11 = new Example8();

            // Működik?
            // Nem igazán
            if (example11 == example11)
            {

            }

            // Explicit:
            var example12 = new Example9();

            // Működik?
            // Nem igazán
            if ((bool)(example12 == example12))
            {

            }

            // Konklúzió: csak nagyon indokolt esetben terheljük túl az operátorokat vagy a típuskényszerítéseket
        }
    }
}
