using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SwordCollision : MonoBehaviour
{
    public Vector3 startingPlayerPosition = new Vector3(0.065f, 1.0f, -3.569f);
    public Quaternion startingPlayerRotation = Quaternion.identity;
    public Vector3 startingSwordPosition = new Vector3(0, 1.13f, -2.27f);
    public Quaternion startingSwordRotation = new Quaternion(90, 0, 90, 0);
    public GameObject swordPrefab;


    // Start is called before the first frame update
    void Start()
    {
//        OVRPlayerController ovrPlayerController = GameObject.FindObjectOfType(typeof(OVRPlayerController)) as OVRPlayerController;
//        startingPlayerPosition = ovrPlayerController.transform.position;
//        startingSwordPosition = gameObject.transform.position;
//        startingSwordRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Application.LoadLevel(Application.loadedLevel);

        }
        Debug.Log(startingPlayerPosition);
    }

    // When Sword is Collided with another object
    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log("OnCollisionEnter");
    //}

    //void OnCollisionStay(Collision col)
    //{
    //    Debug.Log("OnCollisionStay");
    //}

    void OnTriggerEnter(Collider col)
    {
        CubeManager cubeManager = col.gameObject.GetComponentInParent(typeof(CubeManager)) as CubeManager;
        if (col.gameObject.TryGetComponent<CubeInstance>(out CubeInstance cubeInstance))
        {
            cubeManager.AddPoints(cubeInstance.pointsWorth);
            OVRPlayerController ovrPlayerController = GameObject.FindObjectOfType(typeof(OVRPlayerController)) as OVRPlayerController;
            ovrPlayerController.transform.localPosition = new Vector3(0.065f, 1.0f, -3.569f);
            ovrPlayerController.transform.rotation = Quaternion.identity;


            GameObject newObject = Instantiate(swordPrefab);
            newObject.GetComponent<Rigidbody>().freezeRotation = true;
            newObject.transform.position = new Vector3(0, 1.13f, -2.27f);
            newObject.transform.rotation = new Quaternion(90, 0, 90, 0);
            newObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            newObject.GetComponent<Rigidbody>().freezeRotation = false;
            Destroy(this.gameObject);

            


            //            OVRPlayerController ovrPlayerController = GameObject.FindObjectOfType(typeof(OVRPlayerController)) as OVRPlayerController;
            //           ovrPlayerController.transform.localPosition = new Vector3(0.065f, 1.0f, -3.569f);
            //          ovrPlayerController.transform.rotation = Quaternion.identity;
            //         int points = cubeManager.totalPoints;
            //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //       CubeManager cubeManager2 = col.gameObject.GetComponentInParent(typeof(CubeManager)) as CubeManager;
            //      cubeManager2.AddPoints(points);
            //     gameObject.transform.position = new Vector3(0, 1.13f, -2.27f);
            //    gameObject.transform.rotation = new Quaternion(90, 0, 90, 0);
            //   GameObject newSword = Instantiate(gameObject, gameObject.transform);
            //  newSword.transform.localScale = new Vector3(10,10,10);
            // Destroy(gameObject);
        }
    }
}
