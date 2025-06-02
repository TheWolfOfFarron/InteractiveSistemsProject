using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{

    public List<GameAction> PreReactions { get; private set; }  
    public List<GameAction> PerformReactions { get; private set; }  
    public List<GameAction> PostReactions { get; private set; }  

   
}
