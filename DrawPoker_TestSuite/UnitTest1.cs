using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawPoker;
using static DrawPoker.Deck;
using System.Linq;

namespace DrawPoker_TestSuite {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestOnePair() {
            GUI gui = new();
            Deck deck = new();
            Hand hand = new();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            hand.Cards.Add(deck.Pack.ElementAt(2));
            hand.Cards.Add(deck.Pack.ElementAt(3));
            hand.Cards.Add(deck.Pack.ElementAt(13));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(1, score);
        }
        [TestMethod]
        public void TestTwoPair() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            hand.Cards.Add(deck.Pack.ElementAt(2));
            hand.Cards.Add(deck.Pack.ElementAt(13));
            hand.Cards.Add(deck.Pack.ElementAt(14));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(2, score);
        }
        [TestMethod]
        public void TestThreeOfAKind() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            hand.Cards.Add(deck.Pack.ElementAt(2));
            hand.Cards.Add(deck.Pack.ElementAt(13));
            hand.Cards.Add(deck.Pack.ElementAt(26));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(3, score);
        }
        [TestMethod]
        public void TestStraight() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            hand.Cards.Add(deck.Pack.ElementAt(2));
            hand.Cards.Add(deck.Pack.ElementAt(3));
            hand.Cards.Add(deck.Pack.ElementAt(4));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(4, score);
        }
        [TestMethod]
        public void TestFlush() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(4));
            hand.Cards.Add(deck.Pack.ElementAt(8));
            hand.Cards.Add(deck.Pack.ElementAt(12));
            hand.Cards.Add(deck.Pack.ElementAt(16));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(5, score);
        }
        [TestMethod]
        public void TestFullHouse() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(13));
            hand.Cards.Add(deck.Pack.ElementAt(26));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            hand.Cards.Add(deck.Pack.ElementAt(14));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(6, score);
        }
        [TestMethod]
        public void TestFourOfAKind() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(0));
            hand.Cards.Add(deck.Pack.ElementAt(13));
            hand.Cards.Add(deck.Pack.ElementAt(26));
            hand.Cards.Add(deck.Pack.ElementAt(39));
            hand.Cards.Add(deck.Pack.ElementAt(1));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(7, score);
        }
        [TestMethod]
        public void TestStraightFlushAto5() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(39));
            hand.Cards.Add(deck.Pack.ElementAt(27));
            hand.Cards.Add(deck.Pack.ElementAt(15));
            hand.Cards.Add(deck.Pack.ElementAt(3));
            hand.Cards.Add(deck.Pack.ElementAt(43));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(8, score);
        }
        [TestMethod]
        public void TestStraightFlush9toK() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(11));
            hand.Cards.Add(deck.Pack.ElementAt(23));
            hand.Cards.Add(deck.Pack.ElementAt(35));
            hand.Cards.Add(deck.Pack.ElementAt(47));
            hand.Cards.Add(deck.Pack.ElementAt(51));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(8, score);
        }
        [TestMethod]
        public void TestRoyalFlush() {
            GUI gui = new ();
            Deck deck = new ();
            Hand hand = new ();
            hand.Cards.Clear();
            hand.Cards.Add(deck.Pack.ElementAt(11));
            hand.Cards.Add(deck.Pack.ElementAt(23));
            hand.Cards.Add(deck.Pack.ElementAt(35));
            hand.Cards.Add(deck.Pack.ElementAt(39));
            hand.Cards.Add(deck.Pack.ElementAt(51));
            gui.Deal(hand);
            int score = hand.CheckForWinner();
            Assert.AreEqual(9, score);
        }
    }
}
