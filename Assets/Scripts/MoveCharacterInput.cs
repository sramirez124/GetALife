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
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Camera mainCamera;
    [SerializeField] TextMeshProUGUI characterName;

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                NavMeshAgent newAgent = hit.transform.GetComponent<NavMeshAgent>();
                if (newAgent != null)
                {
                    agent = newAgent;
                    characterName.text = newAgent.GetComponent<Character>().Name;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            Physics.Raycast(ray, out hit);

            agent.destination = hit.point;
            Debug.Log("Moving");
        }
    }
}
