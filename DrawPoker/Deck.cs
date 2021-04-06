using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DrawPoker {
    public class Deck {

        public List<int[]> Pack { get; set; }
        public Deck() {
            Pack = CreateDeck();
        }
        private static List<int[]> CreateDeck() {
            var list = new List<int[]>();
            for (int i = 0; i < 52; i++) {
                int[] d = { i % 13, i % 4 };
                list.Add(d);
            }
            return list;
        }
        public class Hand : Deck {
            private readonly Random r;
            public List<int[]> Cards { get; set; }
            public Hand() {
                r = new Random();
                Cards = CardsToDeal(5);
            }
            public List<int[]> CardsToDeal(int num) {
                var list = new List<int[]>();
                for (int i = 0; i < num; i++) {
                    int x = (int)Math.Ceiling(r.NextDouble() * (Pack.Count - 1));
                    list.Add(Pack.ElementAt(x));
                    Pack.RemoveAt(x);
                    // The random function tends to return a straight without
                    // this code when getting re-deal of 5 cards
                    Thread.Sleep(15 + r.Next(5));
                }
                return list;
            }
            public void ReplaceCards(string held) {
                if (!held.Contains("1")) {
                    Cards.RemoveAt(0);
                    Cards.Insert(0, CardsToDeal(1).ElementAt(0));
                }
                if (!held.Contains("2")) {
                    Cards.RemoveAt(1);
                    Cards.Insert(1, CardsToDeal(1).ElementAt(0));
                }
                if (!held.Contains("3")) {
                    Cards.RemoveAt(2);
                    Cards.Insert(2, CardsToDeal(1).ElementAt(0));
                }
                if (!held.Contains("4")) {
                    Cards.RemoveAt(3);
                    Cards.Insert(3, CardsToDeal(1).ElementAt(0));
                }
                if (!held.Contains("5")) {
                    Cards.RemoveAt(4);
                    Cards.Insert(4, CardsToDeal(1).ElementAt(0));
                }
            }

            /// <summary>
            /// Check hand for winner
            /// </summary>
            /// <returns>An integer representing the win code</returns>
            public int CheckForWinner() {
                var chk = Cards.OrderBy(x => x[0]).ToList();
                bool flush = false;
                bool straight = false;
                int count;

                Pairing();
                if (count.Equals(7)) {
                    return 1;                              // Return 1 - One pair
                } else if (count.Equals(9)) {
                    return 2;                              // Return 2 - Two pair
                } else if (count.Equals(11)) {
                    return 3;                              // Return 3 - Three of a kind
                } else if (count.Equals(13)) {
                    return 6;                              // Return 6 - Full house
                } else if (count.Equals(17)) {
                    return 7;                              // Return 7 - Four of a kind
                }
                Flush();
                Straight();
                return (chk.ElementAt(0)[0].Equals(0) &&   // Ace
                        chk.ElementAt(1)[0].Equals(9) &&   // 10
                        chk.ElementAt(2)[0].Equals(10) &&  // Jack
                        chk.ElementAt(3)[0].Equals(11) &&  // Queen
                        chk.ElementAt(4)[0].Equals(12)     // King
                    ) ? (flush ? 9 : 4) :                  // True: Return 9 - Royal flush; False: Return 4 - Straight (royal)
                    flush && straight ? 8 :                // Return 8 - Straight flush
                    flush ? 5 :                            // Return 5 - Flush
                    straight ? 4 : 0;                      // True: Return 4 - Straight; False: Return 0 - No win

                // Pairing - Calculation for duplicate cards. Pairs, X of a kind and Full house
                void Pairing() {
                    count = 0;
                    for (int i = 0; i < chk.Count; i++) {
                        for (int j = 0; j < chk.Count; j++) {
                            if (chk.ElementAt(i)[0].Equals(chk.ElementAt(j)[0])) {
                                count++;
                            }
                        }
                    }
                }
                // Flush
                void Flush() {
                    count = 0;
                    for (int i = 1; i < chk.Count; i++) {
                        if (chk.ElementAt(0)[1].Equals(chk.ElementAt(i)[1])) {
                            count++;
                        }
                    }
                    flush = count.Equals(4);
                }
                //Straight
                void Straight() {
                    count = 0;
                    for (int i = 1; i < chk.Count; i++) {
                        if (chk.ElementAt(i - 1)[0].Equals(chk.ElementAt(i)[0] - 1)) {
                            count++;
                        }
                    }
                    straight = count.Equals(4);
                }
            }
        }
    }
}