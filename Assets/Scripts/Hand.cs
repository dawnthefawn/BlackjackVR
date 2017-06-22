using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caZino
{
    public class Hand
    {
        public List<Card> hand;
        public int value;
        public bool stay;
        public Card secretcard;
        public int secretvalue;
        public MatHandler mat;

        public void Init()
        {
            stay = false;
            value = 0;
            hand = new List<Card>();
            mat = new MatHandler();
        }

        public void FirstCard(Card c)
        {
            mat.FirstCard(c);
            AddCard(c);
        }
        public void AddCard(Card c)
        {
            hand.Add(c);
            value += c.value;
            secretvalue += c.value;
            mat.PlaceCard(c);
        }

        public void SecretCard(Card c)
        {
            secretcard = c;
            FirstCard(c);
        }


    }
}
