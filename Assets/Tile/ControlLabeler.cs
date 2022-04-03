using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class ControlLabeler : MonoBehaviour
{
    [SerializeField] Color deafaultColor = Color.white; 
    [SerializeField] Color disableColor = Color.gray;
    Vector2Int coordinates = new Vector2Int();
    TextMeshPro label;
    Waypoint waypoint;
    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        waypoint = GetComponentInParent<Waypoint>();
        DsiaplyCordinates();
    }
    void Update()
    {
        UpdateObjectName();
        SetLabelColor();
        if(Input.GetKeyDown(KeyCode.G))
        {
            ToggleLabel();
        }
    }
    void ToggleLabel()
    {
        label.enabled = !label.IsActive();
    }
    void SetLabelColor()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = deafaultColor;
        }
        else
        {
            label.color = disableColor;
        }
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void DsiaplyCordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }
}
