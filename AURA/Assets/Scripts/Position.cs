using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 1f); // 1 meter in front of camera
        transform.localRotation = Quaternion.identity;
    }
}
