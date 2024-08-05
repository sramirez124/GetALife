using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMarker : MonoBehaviour
{
    [SerializeField] GameObject markerObject;
    [SerializeField] float markerElevation = 1f;

    public void MarkCharacter(GameObject target)
    {
        markerObject.transform.SetParent(target.transform);
        markerObject.transform.localPosition = Vector3.zero;
        markerObject.transform.localPosition += Vector3.up * markerElevation;
    }
}
