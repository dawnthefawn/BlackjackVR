using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caZino
{

    public class caZinoDealer : MonoBehaviour
    {
        //A few variables to help track the game
        public Shuffle shuffle;
        public Hand dealerhand;
        public Hand playerhand;
        public bool activegame;
        public string win;
        public int Wins;
        public int Losses;

        private Card[] deck;
        private int index;


        private void Start()
        {
            
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
            shuffle = new Shuffle();
            dealerhand = new Hand();
            playerhand = new Hand();
            //playerhand.mat.gObj = GameObject.FindGameObjectWithTag("Playermat");
            //dealerhand.mat.gObj = GameObject.FindGameObjectWithTag("Dealermat");
            dealerhand.Init();
            playerhand.Init();
            deck = shuffle.Generatedeck(n); 
            index = deck.Length;
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
            index = 0;
            deck = shuffle.shuffler(deck);
            dealerhand.SecretCard(DealCard());
            playerhand.FirstCard(DealCard());
            dealerhand.AddCard(DealCard());
            playerhand.AddCard(DealCard());
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

                //render.blackjack(dealerhand, playerhand); <---- Remnant from console based blackjackgame, needs overhaul.
                //render will be replaced by mathandler
                CheckWin();
        }

/// <summary>
/// DealCard simply advances the index of the array containing the shuffled cards. 
/// It should be equivalent to dealing off the top card,
/// theres no reason to resize the array.
/// </summary>
/// <returns>The next card off the top of the deck</returns>

        public Card DealCard()
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