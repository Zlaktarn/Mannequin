using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitScript : MonoBehaviour
{
    public RuntimeAnimatorController[] anims;


    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, anims.Length);

        this.GetComponent<Animator>().runtimeAnimatorController = anims[i] as RuntimeAnimatorController;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
