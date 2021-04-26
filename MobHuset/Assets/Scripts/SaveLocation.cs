using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocation : MonoBehaviour
{
    public Vector3 playerPosition;
    public VectorValue playerStorage;

    public void SceneChange()
    {
        playerStorage.initialValue = playerPosition;
    }
}


