using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Class_10
{
    // Láttuk, hogy az osztályokban szereplő adattagokat privátnak szoktuk jelölni és getter-setter metódusokat szoktunk biztosítani a hozzáféréshez (encapsulation)
    class Studentv1
    {
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }

    // Azonban van egy kis gond az adattag, getter-setter megoldással: az adattag, a getter és a setter csak a nevük alapján köthetőek össze, ezen kívül nincs semmilyen konkrét kapocs köztük
    // Ezen felül a létrehozásuk is kényelmetlen
    // Milyen jó lenne, ha ezeket a problémákat ki tudnánk valahogy küszöbölni!
    // Szerencsére a C# kínál egy mechanizmust a problémák megoldására, a tulajdonságokat (property):
    class Studentv2
    {
        // Hozzuk létre a privát adattagot
        private string name;

        // Hozzuk létre a hozzá tartozó tulajdonságot
        // A név minden esetben legyen az adattag nagybetűs camelCase megfelelője (nem kötelező, de erősen ajánlott)
        public string Name
        {
            // A tulajdonságnak van egy getter blokkja, ami akkor fut le amikor olvassuk a tulajdonságot
            // Ez lényegében megegyezik a getter metódussal (a háttérben ténylegesen egy metódus generálódik)
            get
            {
                return name;
            }

            // A tulajdonságnak van egy setter blokkja, ami akkor fut le amikor írjuk a tulajdonságot
            // Ez lényegében megegyezik a setter metódussal (a háttérben ténylegesen egy metódus generálódik)
            // Vegyük észre, hogy nincs paramétere a setternek, ekkor viszont felmerül a kérdés, hogy mit írunk az adattagba?!
            // A setterben elérhető egy speciális kulcsszó, a value, mely a setternek adott értéket tartalmazza (az egyenlőség jobb oldala)
            set
            {
                name = value;
            }
        }
    }

    // Valójában a legtöbb esetben a tulajdonság teljesen üres, így a C# egy egyszerűbb módot is kínál a létrehozásukra, az úgynevezett auto-property-ket
    class Studentv3
    {
        // Auto-property: nem kell adattagot léptrehozni, a fordító automatikusan generál egyet
        // A gettert és settert sem kell megvalósítani, az alapértelmezett működés fog generálódni hozzájuk (egyszerű olvasás és írás)
        public string Name { get; set; }
    }

    class Studentv4
    {
        // Csinálhatunk csak gettert tartalmazó tulajdonságot is, ekkor csak a konstruktorban lesz írható a tulajdonság, sehol máshol nem
        public string Name { get; }

        public Studentv4(string name)
        {
            // A konstruktorban írható
            Name = name;
        }

        public void Method(string name)
        {
            // Nem működik, mert nincs setter, így csak a konstruktorban írható
            //Name = name;
        }
    }

    // Nem csak a tulajdonságnak lehet láthatósága, hanem a getter és setternek is (hiszen csak egyszerű metódusok)
    class Studentv5
    {
        // Kívülről csak olvasható tulajdonság:
        // Ez a leggyakoribb kombináció, de természetesen más kombináció is lehetséges (pl. privát getter, publikus setter)
        public string Name { get; private set; }

        public Studentv5(string name)
        {
            // Megy
            Name = name;
        }

        public void Method(string name)
        {
            // Csak az osztályon belül írható a tulajdonság
            Name = name;
        }
    }

    class Sutdentv6
    {
        // Továbbra is adhatunk meg saját logikát a getternek és setternek, azonban figyeljünk arra, hogy ha akár a gettert, akár a settert saját logikával akarjuk megvalósítani, akkor a másikat is kötelesek vagyunk saját logikával megvalósítani
        // Azaz például ha saját settert írunk, akkor saját gettert is kell írnunk, nem fog létrejönni egy automatikusan generált getter (a fordító is jelzi ezt)
        // Továbbá egy adattagot is létre kell hoznunk onnantól, hogy megvalósítjuk
        private string name;
        public string Name
        {
            get { return name; }

            set
            {
                name = value + name.Skip(1);
            }
        }
    }
}
