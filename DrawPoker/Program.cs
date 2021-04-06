using System;
using System.Runtime.InteropServices;
using System.Text;
using static DrawPoker.Deck;

namespace DrawPoker {
    class Program {

        public static int credits = 20;

        static void Main() {

            #region Windows Only
            // Windows Specific Commands
            // =========================
            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            //    Console.WindowWidth = 25;
            //    Console.WindowHeight = 25;
            //}
            #endregion

            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Lloyd's Draw Poker";
            GUI gui = new();

            #region Display Card Position in Deck
            // For Testing Only - Displays Cards and their placeholder position
            // ================================================================
            //Deck deck = new Deck();
            //for (int i = 0; i < deck.Pack.Count; i++) {
            //    Console.WriteLine(i + ": " + gui.faceValue[deck.Pack[i][0]] + " " + gui.suiteValue[deck.Pack[i][1]]);
            //}
            //Console.WriteLine();
            #endregion

            gui.Intro();
            do {
                credits--;
                Hand hand = new();
                gui.Deal(hand);
                gui.HoldCards(hand);
                gui.Deal(hand);
                gui.DisplayWin(hand.CheckForWinner());
                if (gui.EndGame()) {
                    break;
                }
                Console.Write("\nAny key for a new hand...\n");
                Console.ReadKey();
                Console.WriteLine();
            } while (true);

            // Wait for keypress before closing console
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
