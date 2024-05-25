using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : Graphic
{
    public Vector2 start;
    public Vector2 end;
    public float thickness = 2f;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        Vector2 direction = (end - start).normalized;
        Vector2 perpendicular = new Vector2(-direction.y, direction.x) * thickness / 2f;

        UIVertex[] vertices = new UIVertex[4];

        vertices[0] = UIVertex.simpleVert;
        vertices[0].color = color;
        vertices[0].position = start - perpendicular;

        vertices[1] = UIVertex.simpleVert;
        vertices[1].color = color;
        vertices[1].position = start + perpendicular;

        vertices[2] = UIVertex.simpleVert;
        vertices[2].color = color;
        vertices[2].position = end + perpendicular;

        vertices[3] = UIVertex.simpleVert;
        vertices[3].color = color;
        vertices[3].position = end - perpendicular;

        vh.AddUIVertexQuad(vertices);
    }

    public void SetPositions(Vector2 start, Vector2 end)
    {
        this.start = start;
        this.end = end;
        SetAllDirty();
    }
}
