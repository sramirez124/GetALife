using CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEditor;

public class SelectCharacter : MonoBehaviour
{
    public NavMeshAgent selectedCharacter;
    [SerializeField] Camera mainCamera;
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] CharacterMarker characterMarker;
    [SerializeField] NeedPanel needPanel;
    [SerializeField] GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {

    }

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
                    selectedCharacter = newAgent;
                    characterName.text = newAgent.GetComponent<Character>().Name;
                    characterMarker.MarkCharacter(selectedCharacter.gameObject);
                    needPanel.SelectCharacter(selectedCharacter.GetComponent<Character>());
                }
            }
        }

        pivot.transform.position = selectedCharacter.transform.position;
    }
}
