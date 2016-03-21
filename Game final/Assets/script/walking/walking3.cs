using UnityEngine;
using System.Collections;

public class walking3 : MonoBehaviour {
	protected CharacterController control;
    public float fTime = 1.5f;      // Hop time
    public float fRange = 5.0f;     // Max dist from origin
    public float fHopHeight = 2.0f; // Height of hop

    private Vector3 v3Dest;
    private Vector3 v3Last;
    private float fTimer = 0.0f;
    private bool moving = false;
    private int number= 0;
    private Vector2 direction;

    public virtual void Start () {

        control = GetComponent<CharacterController>();

        if(!control){

            Debug.LogError("No Character Controller");
            enabled=false;

        }

    }


    void Update () {

       if (fTimer >= fTime&& moving) {
        var playerObject = GameObject.Find("Player");
        v3Last = playerObject.transform.position;
        Debug.Log(v3Last);
        v3Dest = direction *fRange;
        //v3Dest = newVector* fRange + v3Last;

         v3Dest.z = v3Dest.y;
         v3Dest.y = 0.0f;
         fTimer = 0.0f;
        moving = false;
       }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            moving = true;
            direction = new Vector2(1.0f, 1.0f);
            number++;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            moving = true;
            direction = new Vector2(-1.0f, 1.0f);
            number++;
        }
        if(moving){
       Vector3 v3T = Vector3.Lerp (v3Last, v3Dest, fTimer / fTime);
       v3T.y = Mathf.Sin (fTimer/fTime * Mathf.PI) * fHopHeight;
       control.transform.position = v3T;
       fTimer += Time.deltaTime;
        }
    }
}