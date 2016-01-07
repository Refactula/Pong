using UnityEngine;
using System.Collections;
using System;

public class RectangleView : MonoBehaviour { 

    public float Width;
    public float Height;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = createMesh();
    }

    private Mesh createMesh() {
        var verts = new Vector3[4];
        var normals = new Vector3[4];
        var uv = new Vector2[4];
        var tri = new int[6];

        var halfWidth = Width / 2F;
        var halfHeight = Height / 2F;

        verts[0] = new Vector3(-halfWidth, -halfHeight, 0);
        verts[1] = new Vector3(halfWidth, -halfHeight, 0);
        verts[2] = new Vector3(-halfWidth, halfHeight, 0);
        verts[3] = new Vector3(halfWidth, halfHeight, 0);

        for (var i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 3;

        tri[3] = 0;
        tri[4] = 3;
        tri[5] = 1;

        var mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tri;
        mesh.uv = uv;
        mesh.normals = normals;
        
        return mesh;
    }

    public Rectangle CreateRectangle()
    {
        return new Rectangle(transform.position.x, transform.position.y, Width, Height);
    }

    public void Update(Rectangle rectangle)
    {
        transform.position = new Vector3(rectangle.GetCenterX(), rectangle.GetCenterY(), transform.position.z);
    }
}
