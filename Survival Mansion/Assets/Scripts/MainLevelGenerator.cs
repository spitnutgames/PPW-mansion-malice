using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelGenerator : MonoBehaviour {

    private bool generateRooms = true;
    private int c1, c2, c3 = 0;
    private int s1, s2, s3, s4, s5, s6, s7, s8, s9, s11, s12, s13, s14, s15, s16, s17, s18, s19 = 0;
    private int maxRandomRange;

    public GameObject[] CenterRooms = new GameObject[30];
    public GameObject[] SideRooms = new GameObject[20];


    void Start () {
        if (generateRooms)
            BuildRooms();
        //makes sure rooms don't generate on top of each other
        generateRooms = false;
	}
	
    private void BuildRooms()
    {

        //decide which center rooms to build
        c1 = Random.Range(0, CenterRooms.Length);
        c2 = Random.Range(0, CenterRooms.Length);
        c3 = Random.Range(0, CenterRooms.Length);

        //decide which side rooms to build
        s1 = Random.Range(1, SideRooms.Length);
        s2 = Random.Range(1, SideRooms.Length);
        s3 = Random.Range(1, SideRooms.Length);
        s4 = Random.Range(1, SideRooms.Length);
        s5 = Random.Range(1, SideRooms.Length);
        s6 = Random.Range(1, SideRooms.Length);
        s7 = Random.Range(1, SideRooms.Length);
        s8 = Random.Range(1, SideRooms.Length);
        s9 = Random.Range(1, SideRooms.Length);
        s11 = Random.Range(1, SideRooms.Length);
        s12 = Random.Range(1, SideRooms.Length);
        s13 = Random.Range(1, SideRooms.Length);
        s14 = Random.Range(1, SideRooms.Length); 
        s15 = Random.Range(1, SideRooms.Length);
        s16 = Random.Range(1, SideRooms.Length);
        s17 = Random.Range(1, SideRooms.Length);
        s18 = Random.Range(1, SideRooms.Length);
        s19 = Random.Range(1, SideRooms.Length);

        //build the center rooms
        Instantiate(CenterRooms[c1], new Vector3(0, 0, 1), Quaternion.identity);
        Instantiate(CenterRooms[c2], new Vector3(0, 21, 1), Quaternion.identity);
        Instantiate(CenterRooms[c3], new Vector3(0, 42, 1), Quaternion.identity);

        //build the side rooms
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s1], new Vector3(-9, -5, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, -5, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s2], new Vector3(-9, 2, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 2, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s3], new Vector3(-9, 9, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 9, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s4], new Vector3(-9, 16, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 16, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s5], new Vector3(-9, 23, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 23, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s6], new Vector3(-9, 30, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 30, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s7], new Vector3(-9, 37, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 37, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s8], new Vector3(-9, 44, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 44, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s9], new Vector3(-9, 51, 1), Quaternion.identity); } else { Instantiate(SideRooms[0], new Vector3(-9, 51, 1), Quaternion.identity); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s11], new Vector3(36, 4, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 4, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s12], new Vector3(36, 11, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 11, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s13], new Vector3(36, 18, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 18, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s14], new Vector3(36, 25, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 25, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s15], new Vector3(36, 32, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 32, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s16], new Vector3(36, 39, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 39, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s17], new Vector3(36, 46, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 46, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s18], new Vector3(36, 53, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 53, 1), Quaternion.Euler(0, 0, 180)); }
         if (Random.Range(0, 3) > 0) { Instantiate(SideRooms[s19], new Vector3(36, 60, 1), Quaternion.Euler(0, 0, 180)); } else { Instantiate(SideRooms[0], new Vector3(36, 60, 1), Quaternion.Euler(0, 0, 180)); }
        
    }

}
