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
        public Transform[] transforms;

        private Animator[] animator;
        private string currentState = "";
        // Use this for initialization
        void Start() {
            bjt = GameObject.FindGameObjectWithTag("bjt").GetComponent<BlackjackTable>();
            hitpoints = 1;
            animator = new Animator[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                animator[i] = transforms[i].GetComponent<Animator>();
            }
            zanimation();
        }

        void zanimation()
        {
            AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);

            if (!stateInfo.IsName("Base Layer.idle0"))
            {
                for (int j = 0; j < animator.Length; j++)
                {
                    //animator[j].SetBool("idle0ToIdle0", false);
                    animator[j].SetBool("idle0ToIdle1", false);
                    animator[j].SetBool("idle0ToWalk", false);
                    animator[j].SetBool("idle0ToRun", false);
                    animator[j].SetBool("idle0ToWound", false);
                    //animator[j].SetBool("idle0ToSkill1", false);
                    animator[j].SetBool("idle0ToSkill0", false);
                    animator[j].SetBool("idle0ToAttack1", false);
                    animator[j].SetBool("idle0ToAttack0", false);
                    animator[j].SetBool("idle0ToDeath", false);
                }
            }
            else
            {
                for (int j = 0; j < animator.Length; j++)
                {
                    animator[j].SetBool("walkToIdle0", false);
                    animator[j].SetBool("runToIdle0", false);
                    animator[j].SetBool("deathToIdle0", false);
                }
            }

            if (currentState != "")
            {
                if (stateInfo.IsName("Base Layer.walk") && currentState != "walk")
                {
                    for (int j = 0; j < animator.Length; j++)
                    {
                        animator[j].SetBool("walkToIdle0", true);
                    }
                }

                if (stateInfo.IsName("Base Layer.run") && currentState != "run")
                {
                    for (int j = 0; j < animator.Length; j++)
                    {
                        animator[j].SetBool("runToIdle0", true);
                    }
                }

                if (stateInfo.IsName("Base Layer.death") && currentState != "death")
                {
                    for (int j = 0; j < animator.Length; j++)
                    {
                        animator[j].SetBool("deathToIdle0", true);
                    }
                }

                switch (currentState)
                {
                    /*
		        case "idle0":
					for (int j = 0; j < animator.Length; j++) {
						animator[j].SetBool("idle0ToIdle0", true);
					}				
					break;
					*/
                    case "idle1":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToIdle1", true);
                        }
                        /*
                        break;
                    case "idle0":

                        break;
                    case "walk":
                        for (int j = 0; j < animator.Length; j++) {
                            animator[j].SetBool("idle0ToWalk", true);
                        }
                        */
                        break;
                    case "run":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToRun", true);
                        }
                        break;
                    case "attack0":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToAttack0", true);
                        }
                        break;
                    case "attack1":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToAttack1", true);
                        }
                        break;
                    case "skill0":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToSkill0", true);
                        }
                        break;
                        /*
                    case "skill1":
                        for (int j = 0; j < animator.Length; j++) {
                            animator[j].SetBool("idle0ToSkill1", true);
                        }
                        */
                        break;
                    case "wound":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToWound", true);
                        }
                        break;
                    case "death":
                        for (int j = 0; j < animator.Length; j++)
                        {
                            animator[j].SetBool("idle0ToDeath", true);
                        }
                        break;

                    default:
                        break;
                }
                currentState = "";
            }
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