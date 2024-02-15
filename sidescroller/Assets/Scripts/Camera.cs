using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // Offset de la caméra par rapport au joueur

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            // Met à jour la position de la caméra en fonction de la position du joueur avec l'offset
            transform.position = Player.position + offset;
        }
    }
}
