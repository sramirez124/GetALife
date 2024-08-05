using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering;

public class MoveCharacterInput : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] SelectCharacter selectedCharacter;

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(1))
        {
            Physics.Raycast(ray, out hit);

            selectedCharacter.selectedCharacter.destination = hit.point;
        }
    }
}
