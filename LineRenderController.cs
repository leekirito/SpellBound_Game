using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> linePositions = new List<Vector3>();
    private List<GameObject> touchedLetters = new List<GameObject>();

    [SerializeField] private LayerMask touchInputMask;
    [SerializeField] private float lineWidth = 0.1f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 0f, touchInputMask);
    

            if (hit)
            {
                GameObject touchedObject = hit.collider.gameObject;

                if (!touchedLetters.Contains(touchedObject))
                {
                    Vector3 offset = new Vector3(0.3f, -0.3f, 0f); // adjust the offset as needed

                    touchedLetters.Add(touchedObject);
                    linePositions.Add(touchedObject.transform.position + offset);

                    lineRenderer.positionCount = linePositions.Count;
                    lineRenderer.SetPositions(linePositions.ToArray());
                }
            }
        }
    }

    public void ClearLine()
    {
        linePositions.Clear();
        touchedLetters.Clear();
        lineRenderer.positionCount = 0;
        gmScript.currentWord = "";
    }
}
