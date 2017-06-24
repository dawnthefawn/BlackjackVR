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
        public Mathandler mat;

        public void Init()
        {
            stay = false;
            value = 0;
            hand = new List<Card>();
            mat = new Mathandler();
        }

        public void FirstCard(Card c)
        {
            AddCard(c);
            mat.FirstCard(c);
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
            hand.Add(c);
            secretvalue += c.value;
            mat.SecretCard(c);
        }


    }
}
