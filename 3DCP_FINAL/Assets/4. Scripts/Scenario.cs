using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scenario : MonoBehaviour
{

}

[System.Serializable]
public struct PlayerComment
{
    public int ID; //String? Enum?
    public List<string> content;
}

[System.Serializable]
public struct ViewerComment
{
    public int ID;

}