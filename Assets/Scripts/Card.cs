using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Diagnostics;
//using System.Threading.Tasks;

//Use .Value and .Face to to return each. 

namespace caZino
{
    public class Card : MonoBehaviour
    {
        public int value;
        public string cardskin;

 
        public void Start()
        {
            Debug.LogError(this.gameObject.name);
            cardskin = this.gameObject.name;
            Debug.LogError(cardskin);
            value = SetValue();
        }


        public string rank()
        {
            char[] array = cardskin.ToCharArray();
            string rank = "";
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Char.IsNumber(array[i]))
                    {
                    index = i;
                    rank += array[i];
                    break;
                }
            }
            return rank;
            
        }
        public int SetValue()
        {
            int value = Int32.Parse(rank());
            if (value > 9)
            { return 10; }
            else { return value; }
        }

        public Vector3 Cardsize() => this.gameObject.GetComponent<Renderer>().bounds.size;



    }
}
