using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caZino
{
    //Shuffle the deck of cards by setting the deck = to Shuffle.shuffler(deck being shuffled, number of decks in play.)

    public class Shuffle
    {
        private static Random random = new Random();

/// 
/// shuffle to approximate true random
/// based on the fisher-yates shuffle
/// <param name="deck">pass the dealer's deck into the shuffler to return it. no need to generate a new deck each round.</param>
/// <returns>a shuffled deck of cards</returns>
/// 

        public Card[] shuffler(Card[] deck)
        {
            int n = deck.Length;

            for (int i = 0; i < n; i++)
            {
                int index = random.Next(i, n);
                Card card = deck[index];
                deck[index] = deck[i];
                deck[i] = card;

            }

            return deck;
        }

///
/// generates as many decks of cards as desired. Some casinos play with
/// multiple decks for a more authentic experience.
/// the playing cards attached to the zombies chests will pass the face value
/// to the dealer's starting deck.
/// from then on, the dealer will reshuffle the same deck until 
/// the user chooses a new set of decks
/// 

        public Card[] Generatedeck(int numdecks)
        {
            int index = 0;
            if (numdecks < 1) { numdecks = 1; }
            var deck = new Card[52 * numdecks];

            for (int n = 1; n <= numdecks; n++)
            {
                foreach (string suit in new[] { "Spades", "Diamonds", "Clubs", "Hearts" })
                {
                    for (int rank = 1; rank < 14; rank++)
                    {
                        Card c = new Card();
                        c.Init(rank, suit);
                        //c.value = c.setValue();
                        //c.tag = c.setTag();
                        //c.face = c.Face();
                        deck[index] = c;
                        index++;
                    }
                }
            }


            return deck;

        }
    }
}