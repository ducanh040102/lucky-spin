using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }

    void OnMouseDown()
    {
        isDragging = true;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDragging)
        {
            transform.position = collision.transform.position;
            collision.gameObject.GetComponent<Drop>().SetPlacedColor(gameObject.name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isDragging)
        {
            collision.gameObject.GetComponent<Drop>().SetPlacedColor("None");
        }
    }
}
