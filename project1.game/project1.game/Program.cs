using System;
using System.ComponentModel.Design;

namespace project1.game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TypeWriter("Välkommen till spelet 21!"); //keep

            TypeWriter("Vill du slå eller stanna?"); //player 1

           string answer = Console.ReadLine();

            int playerSum = 0; //player 1
            int dealerSum = 0;

            while (answer == "slå")// && (sum < 21 || sum2 < 21))
            {

                int diceNumber = RullarTärning();
                TypeWriter("Du slog:" + diceNumber); //player 1

                playerSum += diceNumber;
                TypeWriter("Dina poäng:" + playerSum); //player 1

                DealerTurn();

                if (playerSum > 21 || dealerSum > 21 ) //om för mycket poäng sluta spelet
                {
                    break;
                }

                TypeWriter("Vill du slå eller stanna?"); //doesnt work as it should
                answer = Console.ReadLine();
            }

            TypeWriter("Dina poäng:" + playerSum);
            TypeWriter("Dealerns poäng:" + dealerSum);

            #region resultat
            if (playerSum <= 21 && dealerSum <= 21)
            {
                if(playerSum > dealerSum)
                {
                    TypeWriter("Du (Player 1) vinner"); //A wins
                }
                else if(playerSum==dealerSum)
                {
                    TypeWriter("Du (Player 1) och du (dealern) har like, då vinner dealern.");//both win
                }
                else if(playerSum<dealerSum)
                {
                    TypeWriter("Du (dealern) vinner");
                    //B wins?
                }
            }

            if (playerSum > 21 && dealerSum > 21)
            {
                TypeWriter("Du (Player 1) och du (dealern) förlorar eftersom ni båda har över 21");
                //BOTH LOSE
            }
            else if (playerSum > 21)
            {
                TypeWriter("Du (Dealern) vinner och du (player 1) förlorar eftersom du har över 21");
                //A is over 21 and loses
                //B wins
            }
            else if (dealerSum > 21)
            {
                TypeWriter("Du (Player 1) vinner och du (dealern) förlorar eftersom du har över 21");
                //B is over 21 and loses
                //A wins
            }
            #endregion

            Console.ReadLine();

            Console.ReadLine();

            int RullarTärning()
            {
                Random rand = new Random();
                int diceNumber = rand.Next(1, 7);
                return diceNumber;
            }

            void DealerTurn() //hanterar när datorn slår åt dealern
            {
                TypeWriter("Vill du (dealern) slå eller stanna?");

                if(dealerSum>21)
                {
                    TypeWriter("stopp");
                    TypeWriter("Dealerns poäng:" + dealerSum);
                    return;
                }

                TypeWriter("slå");
                int diceNumber2 = RullarTärning();
                TypeWriter("Dealern slog:" + diceNumber2);
                dealerSum += diceNumber2;
                TypeWriter("Dealerns poäng:" + dealerSum);

            }

            void TypeWriter(string text) //creates type writer effect, från https://stackoverflow.com/questions/47943840/c-sharp-making-text-appear-letter-by-letter-in-a-label
            {
                Random rnd = new Random();
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(rnd.Next(30, 60));
                }
                Console.WriteLine();
            }

        }
    }
}
