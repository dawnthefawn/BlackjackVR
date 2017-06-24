using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caZino {

    public class ZDealer : MonoBehaviour {

        public BlackjackTable bjt;
        public bool activegame() => bjt.activegame;
        public int hitpoints;
        public bool hostile;
        public GameObject zHead;
        // Use this for initialization
        void Start() {
            bjt = GameObject.FindGameObjectWithTag("bjt").GetComponent<BlackjackTable>();
            hitpoints = 1;
        }

        // Update is called once per frame
        void Update() {
            if(hitpoints == 0)
            {
                hostile = false;

            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (activegame() == true && collision.gameObject.tag == "Bullet")
            {
                bjt.playerhand.stay = true;
                bjt.Turn();
            }
            if(activegame() == false && collision.gameObject.tag == "Bullet")
            {
                hitpoints--;
            }
        }
    }
}