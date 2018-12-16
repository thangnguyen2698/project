using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateMap : MonoBehaviour {


    public GameObject Map;
    public GameObject Flag;
    public GameObject Trap;
    public Transform Container;
    public int NumberOfFlags;
    public int NumberOfTraps;
    private int[] EntryList = new int[1000];
    private int LengthOfEntryList = 0;
    private const int MaxSize = (10 * 20) - 1;
    void Init()
    {
        LengthOfEntryList = 0;
        for(int i=1; i<=NumberOfFlags; i++)
        {
            EntryList[LengthOfEntryList] = 1;
            LengthOfEntryList++;
        }

        for(int i=1; i<=NumberOfTraps; i++)
        {
            EntryList[LengthOfEntryList] = 2;
            LengthOfEntryList++;
        }

        for(int i=1; i<=MaxSize - NumberOfTraps - NumberOfFlags; i++)
        {
            EntryList[LengthOfEntryList] = 0;
            LengthOfEntryList++;
        }

    }

	// Use this for initialization
	void Start () {
        Init();
        for (int i = 0; i <= 19; i++)
            for (int j = 0; j <= 9; j++)
                if (i + j != 0) {
                    int pivot = Random.Range(0, LengthOfEntryList);
                    int so = EntryList[pivot];
                    EntryList[pivot] = EntryList[LengthOfEntryList];
                    LengthOfEntryList--;

                    if (i == 0 && j == 8) so = 0;
                    if (i == 17 && j == 0) so = 0;
                    if (i == 17 && j == 8) so = 0;
                    if (so == 0) Instantiate(Map, new Vector2(transform.position.x + i, transform.position.y + j), Quaternion.identity, Container);
                    if (so == 1) Instantiate(Flag, new Vector2(transform.position.x + i, transform.position.y + j), Quaternion.identity, Container);
                    if (so == 2) Instantiate(Trap, new Vector2(transform.position.x + i, transform.position.y + j), Quaternion.identity, Container);
                }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
