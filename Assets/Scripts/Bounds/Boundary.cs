using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector2Int offset;

    private static int horizontalBoundary;
    public static int HorizontalBoundary
    {
        get { return horizontalBoundary; }
    }

    private static int verticalBoundary;
    public static int VerticalBoundary
    {
        get { return verticalBoundary; }
    }

    private void Awake()
    {
        int size = 10;
        horizontalBoundary = (size * 2) - offset.x;
        verticalBoundary = size - offset.y;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Snake>(out Snake snake))
        {
           Transform snakeTransform = snake.transform;
           Transform mainCamTransform = mainCamera.transform;

            if(snakeTransform.position.x > mainCamTransform.position.x + horizontalBoundary)
                snake.transform.position = new Vector3(-horizontalBoundary,snakeTransform.position.y,0);

            else if(snakeTransform.position.x < mainCamTransform.position.x - horizontalBoundary)
                snake.transform.position = new Vector3(horizontalBoundary, snakeTransform.position.y, 0);

            else if(snakeTransform.position.y > mainCamTransform.position.y + verticalBoundary)
                snake.transform.position = new Vector3(snakeTransform.position.x,-verticalBoundary, 0);

            else if (snakeTransform.position.y < mainCamTransform.position.y - verticalBoundary)
                snake.transform.position = new Vector3(snakeTransform.position.x, verticalBoundary, 0);

        }
    }
}