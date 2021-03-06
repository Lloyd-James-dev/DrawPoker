using System;
using static DrawPoker.Deck;

namespace DrawPoker {

    public class GUI {

        public readonly string[] faceValue = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public readonly string[] suiteValue = { "♣", "♦", "♥", "♠" };
        private readonly int[] winValues = { 
            0,         // 0. No win
            0,         // 1. One pair
            2,         // 2. Two pair 
            3,         // 3. Three of a kind
            5,         // 4. Straight
            10,        // 5. Flush
            20,        // 6. Full house
            50,        // 7. Four of a kind
            100,       // 8. Straight flush
            1000       // 9. Royal Flush
        };

        /// <summary>
        /// Title and intro
        /// </summary>
        public void Intro() {
            PrintColours(" ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ \n", "Yellow", "DarkGreen");
            PrintColours("  ♠", "Black", "DarkGreen");
            PrintColours(" ♥", "Red", "DarkGreen");
            PrintColours("  Draw  Poker ", "White", "DarkGreen");
            PrintColours(" ♣", "Black", "DarkGreen");
            PrintColours(" ♦  \n", "Red", "DarkGreen");
            PrintColours(" ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ ✶ \n", "Yellow", "DarkGreen");
            PrintColours("=========================\n", "DarkRed", "Black");
            PrintColours("  52 card, natural deck\n", "Magenta", "Black");
            PrintColours("  No wild cards. Fresh\n", "Magenta", "Black");
            PrintColours("  pack with every hand.\n", "Magenta", "Black");
            PrintColours("    1 credit per hand\n", "DarkMagenta", "Black");
            PrintColours("       Good Luck!!\n", "Blue", "Black");
            PrintColours("=========================\n", "DarkRed", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Royal Flush".PadRight(15, '.'), winValues[9].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Straight Flush".PadRight(15, '.'), winValues[8].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "4 of a Kind".PadRight(15, '.'), winValues[7].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Full House".PadRight(15, '.'), winValues[6].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Flush".PadRight(15, '.'), winValues[5].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Straight".PadRight(15, '.'), winValues[4].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "3 of a Kind".PadRight(15, '.'), winValues[3].ToString().PadLeft(6, '.')), "White", "Black");
            PrintColours(string.Format("  {0}{1}\n", "Two Pair".PadRight(15, '.'), winValues[2].ToString().PadLeft(6, '.')), "White", "Black");
            if (winValues[1] > 0) {
                PrintColours(string.Format("  {0}{1}\n", "One Pair".PadRight(15, '.'), winValues[1].ToString().PadLeft(6, '.')), "White", "Black");
            }
            PrintColours("=========================\n", "DarkRed", "Black");
            PrintColours(string.Format("{0,24}", "Credits: " + Program.credits), "Yellow", "Black");
            Console.WriteLine();
            Console.Write("\nAny key to start...\n");
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// Draws cards to screen
        /// </summary>
        /// <param name="hand">the List of cards to draw</param>
        public void Deal(Hand hand) {
            Console.WriteLine();
            foreach (int[] card in hand.Cards) {
                Begin();
                CardTop(card);
                End();
            }
            Console.WriteLine();
            foreach (int[] card in hand.Cards) {
                Begin();
                CardMid(card);
                End();
            }
            Console.WriteLine();
            foreach (int[] card in hand.Cards) {
                Begin();
                CardBase(card);
                End();
            }
            void Begin() {
                PrintColours("▐", "White", "Black");
            }
            void End() {
                PrintColours("▌", "White", "Black");
            }
            void CardTop(int[] card) {
                if (card[1].Equals(1) || card[1].Equals(2)) {
                    // Diamonds or Hearts
                    PrintColours(string.Format("{0,-3}", faceValue[card[0]]), "Red", "White");
                } else {
                    // Clubs or Spades
                    PrintColours(string.Format("{0,-3}", faceValue[card[0]]), "Black", "White");
                }
            }
            void CardMid(int[] card) {
                if (card[1].Equals(1) || card[1].Equals(2)) {
                    // Diamonds or Hearts
                    PrintColours(string.Format(" {0} ", suiteValue[card[1]]), "Red", "White");
                } else {
                    // Clubs or Spades
                    PrintColours(string.Format(" {0} ", suiteValue[card[1]]), "Black", "White");
                }
            }
            void CardBase(int[] card) {
                if (card[1].Equals(1) || card[1].Equals(2)) {
                    // Diamonds or Hearts
                    PrintColours(string.Format("{0,3}", faceValue[card[0]]), "Red", "White");
                } else {
                    // Clubs or Spades
                    PrintColours(string.Format("{0,3}", faceValue[card[0]]), "Black", "White");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the result and credits
        /// </summary>
        /// <param name="winCode">winning code</param>
        public void DisplayWin(int winCode) {
            string[] win = {                   // Win code
                "    No Win     ",              // 0 or default
                "   One Pair    ",              // 1
                "   Two Pair    ",              // 2
                "  3 of a Kind  ",              // 3
                "   Straight    ",              // 4
                "     Flush     ",              // 5
                "  Full House   ",              // 6
                "  4 of a Kind  ",              // 7
                "Straight Flush ",              // 8
                "✶ Royal Flush ✶",              // 9
            };
            switch (winCode) {
                case 1: // one pair
                    WinColours("Blue", "DarkBlue");
                    WinAmount(winValues[1]);
                    break;
                case 2: // two pair
                    WinColours("Cyan", "DarkCyan");
                    WinAmount(winValues[2]);
                    break;
                case 3: // 3 of a kind
                    WinColours("Green", "DarkGreen");
                    WinAmount(winValues[3]);
                    break;
                case 4: // straight
                    WinColours("Yellow", "DarkYellow");
                    WinAmount(winValues[4]);
                    break;
                case 5: // flush
                    WinColours("White", "Red");
                    WinAmount(winValues[5]);
                    break;
                case 6: // full house
                    WinColours("Magenta", "DarkMagenta");
                    WinAmount(winValues[6]);
                    break;
                case 7: // 4 of a kind
                    WinColours("Yellow", "DarkBlue");
                    WinAmount(winValues[7]);
                    break;
                case 8: // straight flush
                    WinColours("Yellow", "DarkMagenta");
                    WinAmount(winValues[8]);
                    break;
                case 9: // royal flush
                    WinColours("Yellow", "Red");
                    WinAmount(winValues[9]);
                    break;
                default: // no win
                    WinColours("White", "DarkGray");
                    WinAmount(winValues[0]);
                    break;
            }
            void WinColours(string colour0, string colour1) {
                Console.WriteLine();
                PrintColours(" ╔═════════════════════╗ ", colour0, colour1);
                Console.WriteLine();
                PrintColours(string.Format(" ║{0,18}   ║ ", win[winCode]), colour0, colour1);
                Console.WriteLine();
                PrintColours(" ╚═════════════════════╝ ", colour0, colour1);
                Console.WriteLine();
            }
            void WinAmount(int amount) {
                Program.credits += amount;
                PrintColours(string.Format(" Win: {0,-6}{1,12}", amount, "Credits: " + Program.credits), "Yellow", "Black");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Requests cards to hold and replaces them with
        /// random cards from the remainder of the deck
        /// </summary>
        public void HoldCards(Hand hand) {
            PrintColours("  1    2    3    4    5  \n", "Yellow", "Black");
            Console.Write("\nCards to hold: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            hand.ReplaceCards(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// "We are in the End Game now!"
        /// </summary>
        /// <returns>true if no credits remaining</returns>
        public bool EndGame() {
            if (Program.credits < 1) {
                Console.WriteLine();
                PrintColours("         Loser!!         ", "Black", "White");
                Console.WriteLine();
                PrintColours("      Is gambling a      ", "Red", "White");
                Console.WriteLine();
                PrintColours("     problem for you?    ", "Red", "White");
                Console.WriteLine();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Changes the forgraound and background
        /// colour for text written to screen
        /// </summary>
        /// <param name="text">text to display</param>
        /// <param name="colour0">fore colour</param>
        /// <param name="colour1">back colour</param>
        public void PrintColours(string text, string colour0, string colour1) {
            ConsoleColor tint0 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour0);
            ConsoleColor tint1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour1);
            Console.ForegroundColor = tint0;
            Console.BackgroundColor = tint1;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
