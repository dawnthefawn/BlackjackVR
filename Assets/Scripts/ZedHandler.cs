using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caZino
{

    public class ZedHandler : MonoBehaviour
    {

        public List<GameObject> zParts;
        public GameObject zHead;
        public GameObject walk;
        public GameObject attack;
        public GameObject fall;

        private void Start()
        {
            foreach (GameObject part in this.gameObject.GetComponentsInChildren<GameObject>())
            {
                zParts.Add(part);
                if(part.tag=="head")
                {
                    zHead = part;
                }
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "bulllet" && collision.collider == zHead.GetComponent<Collider>())
            {
                DestroyImmediate(zHead);

            }
        }
    }
}