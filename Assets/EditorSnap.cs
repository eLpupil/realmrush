using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] float snapSize = 10f;

    // Start is called before the first frame update

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / snapSize) * snapSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / snapSize) * snapSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / snapSize) * snapSize;

        //transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
        transform.position = snapPos;
    }
}
