using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_10
{
    // Egy osztály is lehet statikus, ekkor az osztályban csak statikus adattagok és metódusok szerepelhetnek
    static class Example1
    {
        public static int i1; // Megy
        //public int i2; // Nem megy

        // Megy
        public static void Method1()
        {

        }

        // Nem megy
        /*public void Method2()
        {

        }*/
    }

    // Egyszerű indexer létrehozása:
    class Example2
    {
        public int[] array;

        public Example2(int size)
        {
            array = new int[size];
        }

        // Indexer egyszerű tömbszerű viselkedéssel:
        // Hasonló a tulajdonságokhoz, azonban név helyett a this kulcsszót kell használni, illetve a [] szimbólumok között az indexként megadott elem típusát és nevét kell megadni
        public int this[int index]
        {
            get { return array[index]; }

            set { array[index] = value; }
        }
    }

    // Tetszőleges indexer típus és logika:
    class Example3
    {
        private int a;

        public string this[string s]
        {
            get { return a + s; }

            set { a = int.Parse(s) + int.Parse(value); }
        }
    }

    class Example4
    {
        private int i;
    }

    // + operátor felülírása (hasonlóan mint a normál metódusok túlterhelése):
    class Example5
    {
        public int i;

        // Egyszerű operator+ túlterhelés
        // Kötelezően static!
        public static int operator +(Example5 e1, Example5 e2)
        {
            return e1.i + e2.i;
        }

        // A paraméterlista testreszabása:
        // Három fontos szabály:
        // A két operandusú összeadásnak két paramétere van (a két operandus)
        // Minden operátor túlterhelés esetén legalább az egyik paraméter típusának a túlterhelést tartalmazó osztálynak kell lennie
        // A paraméterlista nem egyezhet meg egy korábbi, azonos operátor túlterhelésének paraméterlistájával (mint metódusoknál)

        // Nem jó, rossz a paraméterek száma
        /*public static int operator +(int a, int b, int c)
        {

        }*/

        // Nem jó, legalább az egyik paraméternek Example5-nek kell lennie
        /*public static int operator +(int a, int b)
        {

        }*/

        // Paraméterlista testreszabása
        public static int operator +(Example5 e, int a)
        {
            return e.i + a;
        }

        // Visszatérési típus testreszabása
        public static Example5 operator +(Example5 e1, double a)
        {
            var example = new Example5();

            example.i = e1.i + (int)a;

            return example;
        }
    }

    // Túlterhelés problémák
    class Example6
    {
        // Ha túlterheljük az == operatort, akkor a !=-t is túl kell terhelnünk
        public static bool operator ==(Example6 e1, Example6 e2)
        {
            return false;
        }


        public static bool operator !=(Example6 e1, Example6 e2)
        {
            return false;
        }
    }

    // Túlterhelés problémák
    class Example7
    {
        // Az egyenlőség ellenőrzése nem bool-t ad vissza
        public static Example7 operator ==(Example7 e1, Example7 e2)
        {
            return new Example7();
        }


        public static Example7 operator !=(Example7 e1, Example7 e2)
        {
            return new Example7();
        }
    }

    // Implicit típuskényszerítés túlterhelése
    class Example8
    {
        public static Example8 operator ==(Example8 e1, Example8 e2)
        {
            return new Example8();
        }


        public static Example8 operator !=(Example8 e1, Example8 e2)
        {
            return new Example8();
        }

        // Implicit bool típuskényszerítés túlterhelése:
        public static implicit operator bool(Example8 e)
        {
            return false;
        }
    }

    // Explicit típuskényszerítés túlterhelése
    class Example9
    {
        public static Example9 operator ==(Example9 e1, Example9 e2)
        {
            return new Example9();
        }


        public static Example9 operator !=(Example9 e1, Example9 e2)
        {
            return new Example9();
        }

        // Explicit bool típuskényszerítés túlterhelése:
        public static explicit operator bool(Example9 e)
        {
            return false;
        }
    }
}
