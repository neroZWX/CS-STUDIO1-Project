using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour
{
    public static int RDInt(int min,int max,System.Random rd =null) {
        if (rd ==null) {
            rd = new System.Random();
        }
        int val = rd.Next(min, max + 1);
        return val;
    }
 
}
