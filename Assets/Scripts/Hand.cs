using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace caZino
{
    public class Hand
    {
        public List<GameObject> hand;
        public int value;
        public bool stay;
        public GameObject secretcard;
        public int secretvalue;
        public GameObject associatedMat;
        public Mathandler mat;

        public void Init()
        {
            stay = false;
            value = 0;
            hand = new List<GameObject>();
        }

        public void FirstCard(GameObject c)
        {
            AddCard(c);
            mat.FirstCard(c);
        }

        public void AddCard(GameObject c)
        {
            hand.Add(c);
            value += c.GetComponent<Card>().value;
            secretvalue += c.GetComponent<Card>().value;
            mat.PlaceCard(c);
        }

        public void SecretCard(GameObject c)
        {
            secretcard = c;
            Debug.Log(c.name);
            hand.Add(c);
            secretvalue += c.GetComponent<Card>().value;
            mat.SecretCard(c);
        }


    }
}
