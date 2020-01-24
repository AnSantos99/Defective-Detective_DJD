using UnityEngine;

/// <summary>
/// Class that display's the mouse reticle on the screen
/// </summary>
public class Reticle : MonoBehaviour
{
    // private variable of type RectTransform 
    private RectTransform _reticle;

    /// <summary>
    /// Set range of size of the box to min of 50f and max of 250
    /// </summary>
    [Range(50f, 250)]
    public float size;

    // Get the component on run of the game
    private void Start()
    {
        _reticle = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Update of the reticle on each frame
    /// </summary>
    private void Update()
    {
        _reticle.sizeDelta = new Vector2(size, size);
    }
}
