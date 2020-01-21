using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Lines/Dialogue")]
public class Conversation : ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
    public Line[] lines;
}


