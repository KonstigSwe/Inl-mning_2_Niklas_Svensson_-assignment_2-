using Inlamning_2_ra_kod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    /* CLASS: Person
    * PURPOSE: An object to save a persons information name,address,phone,email in one variable
    */
    class Person
    {
        public string name, address, phone, email;
        /* METHOD: Person (constructor)
       * PURPOSE: To create the object person
       * PARAMETERS: N sets name, A sets the address, T sets the phone, E sets the email.
       */
        public Person(string N, string A, string T, string E)
        {
            name = N; address = A; phone = T; email = E;
        }
        /* METHOD: Person (constructor)
        * PURPOSE: Creates the object person and add values  to the variables 
        */
        public Person()
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            address = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            phone = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            email = Console.ReadLine();

        }
        /* METHOD: Changevalue
        * PURPOSE: Changes the value in one of the selected atribute
        * PARAMETERS: atribute the variable that vill be changed, value the value that the atribute is assigned 
        * RETURN VALUE: none
        */
        public void Changevalue(string atribute, string value)
        {
            switch (atribute)
            {
                case "namn":
                    name = value;

                    break;
                case "adress":
                    address = value;
                    break;
                case "telefon":
                    phone = value;
                    break;
                case "email":
                    email = value;
                    break;
            }
            Console.WriteLine("Ändrat");
        }
        /* METHOD: Print
         * PURPOSE: Prints out all the viriables in this object
        */
        public void Print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", name, address, phone, email);
        }
    }
}
/* CLASS: Program
 * PURPOSE: Boot up and have the Main code
 */
class Program
{
    static void Main(string[] args)
    /* METHOD: Main (static)
    * PURPOSE: Starts the code is the backbone of the code
    * PARAMETERS: Dict,command
    * RETURN VALUE: None
    */
    {
        List<Person> Dict = Load();

        Console.WriteLine("Hej och välkommen till adresslistan");
        Console.WriteLine("Skriv 'sluta' för att sluta!");
        string command;
        do
        {
            Console.Write("> ");
            command = Console.ReadLine();
            if (command == "sluta")
            {
                Console.WriteLine("Hej då!");
            }
            else if (command == "ny")
            {
                Dict.Add(new Person());
            }
            else if (command == "ta bort")
            {
                Remove(Dict);
            }
            else if (command == "visa")
            {
                for (int i = 0; i < Dict.Count(); i++)
                {
                    Dict[i].Print();
                }
            }
            else if (command == "ändra")
            {
                Change(Dict);
            }
            else
            {
                Console.WriteLine("Okänt kommando: {0}", command);
            }
        } while (command != "sluta");
    }

    /* METHOD: Change (static)
           * PURPOSE: To change a person information
           * PARAMETERS: Dict list with persons,i a counter,found to check if person is in list ,chooseTochange what person to change,
           * fieldTochange what attribute to change,newValue the value to change into
           * RETURN VALUE: None
          */
    static void Change(List<Person> Dict)
    {
        Console.Write("Vem vill du ändra (ange namn): ");
        string choseToChange = Console.ReadLine();
        int found = -1;
        for (int i = 0; i < Dict.Count(); i++)
        {
            if (Dict[i].name == choseToChange) found = i;
        }
        if (found == -1)
        {
            Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", choseToChange);
        }
        else
        {
            Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
            string fieldToChange = Console.ReadLine();
            Console.Write("Vad vill du ändra {0} på {1} till: ", fieldToChange, choseToChange);
            string NewValue = Console.ReadLine();
            Dict[found].Changevalue(fieldToChange, NewValue);
        }
    }

    /* METHOD: Remove (static)
 * PURPOSE: Remove a specified person
 * PARAMETERS: Dict list of objects,toRemove which object to remove,found to check if person is in list
 * RETURN VALUE: None
 */
    static void Remove(List<Person> Dict)// remove a person
    {
        Console.Write("Vem vill du ta bort (ange namn): ");
        string toRemove = Console.ReadLine();
        int found = -1;
        for (int i = 0; i < Dict.Count(); i++)
        {
            if (Dict[i].name == toRemove) found = i;
        }
        if (found == -1)
        {
            Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", toRemove);
        }
        else
        {
            Dict.RemoveAt(found);
        }
    }
    /* METHOD: Load (static)
      * PURPOSE: Loads code from text file
      * PARAMETERS: Dict list of objects,filestream the reader,word[] list of words from txt file,P = object person
      * RETURN VALUE: Dict
      */
    static List<Person> Load()
    { 
        List<Person> Dict = new List<Person>();

        Console.Write("Laddar adresslistan ... ");
        using (StreamReader fileStream = new StreamReader(@"..\..\address.lis"))
        {
            while (fileStream.Peek() >= 0)
            {
                string line = fileStream.ReadLine();
                string[] word = line.Split('#');
                Person P = new Person(word[0], word[1], word[2], word[3]);
                Dict.Add(P);
            }
        }
        Console.WriteLine("klart!");
        return Dict;
    }
}