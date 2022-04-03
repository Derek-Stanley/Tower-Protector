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
    [SerializeField] Color exploredColor = Color.yellow; 
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);
    Vector2Int coordinates = new Vector2Int();
    TextMeshPro label;
    GridManager gridManager;
    
    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DsiaplyCordinates();
    }
    void Update()
    {
        gridManager = FindObjectOfType<GridManager>();
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
        
        if(gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates);

        if(node == null) {return;}
        
        if(!node.isWalkable)
        {
            label.color = disableColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
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
