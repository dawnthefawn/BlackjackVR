using System.Collections; using System.Collections.Generic; using UnityEngine;  namespace caZino {      public class ZedHandler : MonoBehaviour     {          public List<GameObject> zParts;         public GameObject zHead;         public GameObject walk;         public GameObject attack;         public GameObject fall;         public Avatar avatar;         public GameObject card;         public GameObject plane;         public Hand hand;         private bool active;         private bool hostile;           private void Start()         {             //foreach (GameObject part in this.gameObject)            // {              // zParts.Add(part);               //if( part.tag=="head")               //{               //    zHead = part;               //}           //  }             active = true;             hostile = false;             Instantiate(walk);             avatar = walk.GetComponent<Avatar>();           }          public void AddCard(GameObject c, Hand h)
        {
            card = c;
            hand = h;
            card.transform.position = plane.transform.position;
            card.transform.rotation = plane.transform.rotation;
            card.transform.localScale = new Vector3(3F, 1F, 3F);
        }         /// <summary>         /// If headshot, destroy the head and kill the zombie.         /// </summary>         /// <param name="collision"></param>         private void OnCollisionEnter(Collision collision)         {             if (collision.gameObject.tag == "Bulllet" && collision.collider == zHead.GetComponent<Collider>())             {                 DestroyImmediate(zHead);                 active = false;                 hostile = false;                 hand.AddCard(card);                              }         }          void Update()         {             if (card)
            {
                card.transform.position = plane.transform.position;
                card.transform.rotation = plane.transform.rotation;
            }         }     } }