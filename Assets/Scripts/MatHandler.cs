using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caZino
{

    public class MatHandler
    {
        public GameObject gObj;

        private Vector3 margins;
        private Vector3 nextposition;
        private int numcards;


        public void Newgame()
        {
            numcards = 0;
            margins = new Vector3();
            nextposition = new Vector3();
        }
        /// <summary>
        /// SecretCard will be the first card played in the game.
        /// It will play the card face down, and calculate the margins
        /// for laying down the cards nicely
        /// </summary>
        /// 
        /// <param name="c">This is the card passed through the dealers
        /// Secret Card Method
        /// 
        /// </param>
        public void FirstCard(Card c)
        {
            numcards++;
            margins = CalculateMargins(c);

        }


        ///
        /// <summary>
        /// Call this from the the respective Hand.AddCard
        /// </summary>
        /// <param name="c">same card passing through Hand.AddCard</param>
        /// 
        public void PlaceCard(Card c)
        {

        }

        private Vector3 CalculateMargins(Card c)
        {
            Vector3 v = gObj.GetComponent<Renderer>().bounds.size;
            var x = ((v.x / 5) - c.cardwidth) / 2;
            var y = .01F;
            var z = (v.z - c.cardlength) / 2;
            return new Vector3(x, y, z);
            
        }



        // Use this for initialization
        void Start () {
            Newgame();
        }

        // Update is called once per frame
        //void Update () {

        //}
    }
}
