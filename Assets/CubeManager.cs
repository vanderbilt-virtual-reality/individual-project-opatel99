using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public int totalPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh textMesh = GameObject.FindObjectOfType(typeof(TextMesh)) as TextMesh;
        textMesh.text = $"Score: {this.totalPoints.ToString()}";
    }

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    public void AddPoints(int points)
    {
        totalPoints = totalPoints + points;
    }
}
