using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bug", menuName = "SO/Bug")]
public class Bug : ScriptableObject
{
    public string namebug;
    public List<GameObject> weakbugList;
    public List<GameObject> normalbugList;
    public List<GameObject> strongbugList;
}
