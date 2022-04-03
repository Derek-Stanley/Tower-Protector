using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{ 
    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get {return isPlaceable;} }
    // Start is called before the first frame update
   void OnMouseDown() 
   {
       if(isPlaceable)
       {
           bool isPlaced = tower.CreateTower(tower, transform.position);
           isPlaceable = !isPlaced;
       }
   }
}
