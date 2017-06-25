using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace caZino
{
    //Shuffle the deck of cards by setting the deck = to Shuffle.shuffler(deck being shuffled, number of decks in play.)

    public class Shuffle : MonoBehaviour
    {
        private static System.Random random = new System.Random();
        public GameObject FreshDeck;

        private void Start()
        {
            FreshDeck = this.gameObject;
        }

        /// 
        /// shuffle to approximate true random
        /// based on the fisher-yates shuffle
        /// <param name="deck">pass the dealer's deck into the shuffler to return it. no need to generate a new deck each round.</param>
        /// <returns>a shuffled deck of cards</returns>
        /// 

        public GameObject[] shuffler(GameObject[] deck)
        {
            int n = deck.Length;

            for (int i = 0; i < n; i++)
            {
                int index = random.Next(i, n);
                GameObject card = deck[index];
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

        public GameObject[] Generatedeck(int numdecks)
        {
            int index = 0;
            if (numdecks < 1) { numdecks = 1; }
            var deck = new GameObject[52 * numdecks];
            for (int i = 1; i <= numdecks; i++)
            {


                foreach (Card card in this.gameObject.GetComponentsInChildren<Card>())
                {
                    deck[index] = Instantiate(card.gameObject);
                    Debug.LogError(deck[index].name);
                    index++;

                }
            }   
            return deck;
        }
                
            


          

        
    }
}