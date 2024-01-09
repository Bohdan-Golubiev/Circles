using UnityEngine;

public class DinamicArea : MonoBehaviour
{   
    public void ChangeSize(Vector2 sizeChange)
    {
        Vector2 currentScale = transform.localScale;
        transform.localScale = new Vector2(currentScale.x + sizeChange.x, currentScale.y + sizeChange.y);
    }
}
