using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public float unitsPerPixel;

	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
            Camera.main.orthographicSize =  ((270f / unitsPerPixel) / 2f);
        }
	}

    void update()
    {
    }
}
