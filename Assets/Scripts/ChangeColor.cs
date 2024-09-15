using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor = Color.red;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        if (rend != null)
        {
            rend.material.color = newColor;
        }
        else
        {
            Debug.LogError("No Renderer found on the object!");
        }
    }
}
