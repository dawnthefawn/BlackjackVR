using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caZino
{

    public class BlackjackTable : MonoBehaviour
    {
        //A few variables to help track the game
       
        public Shuffle shuffle;
        public Hand dealerhand;
        public Hand playerhand;
        public bool activegame;
        public string win;
        public int Wins;
        public int Losses;
        public int lostby;
        public GameObject ZDealer;
        public GameObject FreshDeck;

        private GameObject[] deck;
        private int index;
        private GameObject DealerInstance;



        private void Start()
        {
            index = 0;
            DealerInstance = Instantiate(ZDealer) as GameObject;
            DealerInstance.SetActive(true);
            BeginGame(1);
        }

///
/// <summary>
/// This should only be used when you are starting a new game.
/// The players can choose a new number of decks in between rounds,
/// if they do, use this to regenerate the deck.
/// </summary>
/// <param name="n">
/// The number of decks to use. This is determined
/// by shooting the zombie with the corresponding card
/// </param>
/// 
        void BeginGame(int n)
        {
            activegame = true;
            shuffle = FreshDeck.GetComponent<Shuffle>();
            dealerhand = new Hand();
            playerhand = new Hand();
            playerhand.mat = GameObject.FindGameObjectWithTag("Playermat").GetComponent<Mathandler>();
            dealerhand.mat = GameObject.FindGameObjectWithTag("Dealermat").GetComponent<Mathandler>();
            dealerhand.Init();
            playerhand.Init();
            deck = shuffle.Generatedeck(n); 
            FirstTurn();
        }


/// <summary>
/// FirstTurn reshuffles the deck, clears all hands, and then deals
/// the first two cards. It is the only time the Hand.SecretCard(DealCard()) method
/// will be used.
/// </summary>
        void FirstTurn()
        {

            playerhand.mat.Newgame();
            dealerhand.mat.Newgame();
            Debug.Log(deck.Length);
            deck = shuffle.shuffler(deck);
            Debug.Log(deck.Length);
            Debug.Log(deck[0].name);
            index = deck.Length - 1;
            dealerhand.SecretCard(DealCard());
            playerhand.FirstCard(DealCard());
            // ** this function will be replaced by a call to ZedHandler to deal cards out to zombies
            dealerhand.AddCard(DealCard());
            playerhand.AddCard(DealCard());
            // ** Same Here
            CheckWin();
        }

///
/// <summary>
/// This is the default turn in blackjack. 
/// Use it after the player inputs their choice.
/// </summary>
///
        public void Turn()
        {
                if (playerhand.stay == false)
                { playerhand.AddCard(DealCard()); }

                if (dealerhand.secretvalue < 17)
                {
                    dealerhand.AddCard(DealCard());
                }
                else
                {
                    dealerhand.stay = true;
                }

                CheckWin();
        }

/// <summary>
/// DealCard simply advances the index of the array containing the shuffled cards. 
/// It should be equivalent to dealing off the top card,
/// theres no reason to resize the array.
/// </summary>
/// <returns>The next card off the top of the deck</returns>

        public GameObject DealCard()
        {
            if (index >= 0)
            {
                index--;
                return deck[index];
            }
            else return null;
        }
///
/// <summary>
/// Call after a turn is complete to check the win conditions.
/// Order ought to be in favor of the house for an authentic
/// "Lost Wages" experience.
/// </summary>
        public void CheckWin()
        {

//automatically bust over 21
            if (playerhand.value > 21)
            {
                activegame = false;
                win = "BUST";
                Losses++;
                lostby = playerhand.value - 21;
                DealerInstance.GetComponent<ZDealer>().hitpoints = lostby;
                DealerInstance.GetComponent<ZDealer>().hostile = true;
            }

//if you dont bust and the dealer does, you win
            else if (dealerhand.secretvalue > 21)
            {
                activegame = false;
                win = "WIN: DEALER BUST";
                Wins++;
            }

//handle win checking once both players decide to stay
            else if (playerhand.stay == true && dealerhand.stay == true)
            {

                if (playerhand.value > dealerhand.secretvalue)
                {
                    activegame = false;
                    win = "WIN: HIGH HAND";
                    Wins++;
                }

                else if (dealerhand.secretvalue == playerhand.value)
                {
                    activegame = false;
                    win = "PUSH";
                }

                else
                {
                    activegame = false;
                    win = "LOSE: LOW HAND";
                    Losses++;
                    lostby = (dealerhand.secretvalue - playerhand.value);
                }
            }

//if one of the win conditions is triggered, the activegame check
//will call the game over handler (name TBD)
            if (activegame == false)
            {
                //render.GameOver(dealerhand, playerhand, win);       <---- Remnant from console based blackjackgame, needs overhaul.
                //input.GameOver(this);                               <---- Remnant from console based blackjackgame, needs overhaul.
            }

//If the game is still on, keep playing!
            else
            {
                //render.blackjack(dealerhand, playerhand);           <---- Remnant from console based blackjackgame, needs overhaul.
                //input.blackjackTurn(this);                          <---- Remnant from console based blackjackgame, needs overhaul.
            }

        }


        /// <summary>
        /// When the table is shot, the player hits. Call Turn();
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bulllet")
            {
                Turn();
            }
        }
        /// <summary>
        /// Currently Update() is not in use. It may be used to detect the users 
        /// choice to stay on their hand, which they will do by shooting our dealer 
        /// of the damned in the head.
        /// 
        /// Commented out to prevent it from being called once per frame.
        /// </summary>
        /// 
        //void Update()
        //{
        //
        //}



    }
}