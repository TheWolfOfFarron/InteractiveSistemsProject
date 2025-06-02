using UnityEngine;

[CreateAssetMenu(menuName = "Data/Card")]

public class CardData : ScriptableObject
{

    [field:SerializeField] public string Description {  get; set; }
    [field:SerializeField] public string Title {  get; set; }
   
    [field:SerializeField] public Sprite Image {  get; set; }

}
