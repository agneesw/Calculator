using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämningsuppgiftandra
{
    class Program //Agnes Wollner 8/10 Visual Studio 17, inlämning 2 Agnes Wollner 17/10 visual studios 17
    {

        static void Main(string[] args)
        {
            //här deklarerar jag en tom string för att kunna nå den senare i main-metoden
            string output = "";
            //här deklarerar jag en tom stringarray som ska ha 5 positioner
            string[] historik = new string[5];
            int i = 0;
            //använder double för att det ska kunna hantera decimaltal
            double nummer1;
            double nummer2;
            double svar = 0;
            string räknesätt;
            string stängav;
            bool femsvar = false;

            //Tar in vad som ska stå på första raden, centrera med hjälp av \t\t\t 
            Console.WriteLine("\t\t\tAgnes Miniräknare");
            Console.WriteLine("Vänligen skriv minst fem uträkningar");
            Console.ReadLine();

            while (true)  //While loop
            {
                //så länge i är mindre än 5 så utförs det som står innanför loopen
                if (i < historik.Length)
                {
                    //kontrollerar om det finns 5 svar eller inte
                    if (femsvar)
                    {
                        //frågar ifall man vill fortsätta eller avsluta. 
                        Console.WriteLine("\nStäng av, på/av?");

                        //om stäng av == (alltså stämmer med av) kommer programmet först gå in i en loop för att skriva ut 
                        //alla uträkningar innan den stänger av helt. 
                        stängav = Console.ReadLine();
                        if (stängav == "av")
                        {
                            output = MinaUträkningar(historik);
                            Console.WriteLine("Dina gamla uträkningar");
                            Console.WriteLine(output);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    //Skriv ut att det är dags att välja sitt första nummer
                    Console.WriteLine("Skriv ditt första nummer");
                    //Tar in det namnet du valde till första numret och konverterar det till att det kommer 
                    //att bli det första numret i uträkningen.

                    nummer1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Välj vilket räknesätt du vill använda: +, -, *, /");
                    räknesätt = Console.ReadLine();
                    //Likadant här, dags för andra numret och konverterar det så att det blir det andra 
                    //numret i uträkningen.
                    Console.WriteLine("Skriv in ditt andra nummer");
                    nummer2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Svar");
                    Console.ReadLine();

                    //undersök vad som händer beroende på vilket räknesätt användaren valt (+, -, *, /)

                    if
                        (räknesätt == "+")
                    {
                        svar = Plus(nummer1, nummer2);
                        //Console.WriteLine(svar);
                    }
                    else if (räknesätt == "-")
                    {
                        svar = Minus(nummer1, nummer2);
                        // Console.WriteLine(svar);
                    }
                    else if (räknesätt == "*")
                    {
                        svar = Gånger(nummer1, nummer2);
                        // Console.WriteLine(svar);
                    }
                    else if (räknesätt == "/")
                    {
                        svar = Delat(nummer1, nummer2);
                        // Console.WriteLine(svar);
                        Console.ReadLine();
                    }
                    else
                    {   //ifall de valt en annan symbol än de fyra räknesätten kommer det stå "Räknesätt finns ej"
                        Console.WriteLine("Räknesätt finns ej");
                    } //deklarerar en string och lägger 4 värden på varsin plats. 
                    string rättsvar = String.Format("{0} {1} {2} = {3}", nummer1, räknesätt, nummer2, svar);
                    //här kör jag metoden "svaren" och lagrar det i variabeln historik
                    historik = svaren(historik, rättsvar, i);
                    i = i + 1;
                    Console.WriteLine(rättsvar);
                }
                //när användaren angett fem tal ger vi användaren möjlighet att stäng av.
                else
                {

                    i = 0;
                    femsvar = true;
                }
            };

        }  

        /// <summary>
        /// Metoden adderar två tal.
        /// </summary>
        /// <param name="nummer1">det första värdet som användaren skrivit in</param>
        /// <param name="nummer2">det andra värdet som användaren skrivit in</param>
        /// <returns>summan av additionen</returns>
        static double Plus(double nummer1, double nummer2) 
        {
            return nummer1 + nummer2;
        }
        /// <summary>
        /// Metoden subtraherar två tal.
        /// </summary>
        /// <param name="nummer1">det första värdet som användaren skrivit in</param>
        /// <param name="nummer2">det andra värdet som användaren skrivit in</param>
        /// <returns>summan av subtrationen</returns>
        static double Minus(double nummer1, double nummer2)
        {
            return nummer1 - nummer2;
        }
        /// <summary>
        /// Metoden multiplicerar två tal.
        /// </summary>
        /// <param name="nummer1">det första värdet som användaren skrivit in</param>
        /// <param name="nummer2">det andra värdet som användaren skrivit in</param>
        /// <returns>summan av multiplikationen</returns>
        static double Gånger(double nummer1, double nummer2)
        {
            return nummer1 * nummer2;
        }
        /// <summary>
        /// Metoden dividerar två tal.
        /// </summary>
        /// <param name="nummer1">det första värdet som användaren skrivit in</param>
        /// <param name="nummer2">det andra värdet som användaren skrivit in</param>
        /// <returns>summan av divisionen</returns>
        static double Delat(double nummer1, double nummer2)
        {
            return nummer1 / nummer2;
        }
        /// <summary>
        /// Vi sätter en string på en plats i en array.
        /// </summary>
        /// <param name="resultat">det är en stringarray som vi vill spara data i</param>
        /// <param name="input">det är en sträng som kommer att läggas på en plats i arrayen.</param>
        /// <param name="i">ett heltal, som kommer användas för att definiera platsen i arrayen.</param>
        /// <returns>vi returnerar en stringarray med ett värde tillagt i arrayen på i:s position</returns>
        static string[] svaren(string[] resultat, string input, int i)
        {
            resultat[i] = input;
            return resultat;
        }
        /// <summary>
        /// Den här metoden går igenom en array och ser till att spara den i ett läsbart strängformat.
        /// </summary>
        /// <param name="historik">historik är arrayen som vi sparat information i.</param>
        /// <returns>den returnerar arrayens innehåll i ett stringformat</returns>
        static string MinaUträkningar(string[] historik) 
        {
            string operation = "";
            for (int j = 0; j < historik.Length; j++)
            {
                operation = operation + historik[j] + ", ";
            }
            string output = operation.Remove(operation.Length - 2);
            return output;
        } 
    }
    
}


//Källor. Jag tittade på denna video som jag tyckte förklarade väldigt bra hur man gör för att själva miniräknaren 
//ska fungera. https://www.youtube.com/watch?v=KvhfSIbzFGA
//Jag var osäker på hur man skulle konvertera sin "double" och använde mig av samma rad som de gav exempel på denna sidan. https://www.tutorialspoint.com/convert-todouble-method-in-chash
//https://stackoverflow.com/questions/7901360/delete-last-char-of-string
//https://www.dotnetperls.com/array
