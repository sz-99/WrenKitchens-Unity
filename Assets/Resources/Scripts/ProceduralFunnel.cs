using Unity.Collections;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class Funnel
{
    public float topDiameter = 4f; 
    public float bottomDiameter = 1f;
    public float slopingHeight = 2f;
    public float tubeHeight = 2f;
    public int Segments = 24;

}
[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ProceduralFunnel : MonoBehaviour
{
    [SerializeField] private Funnel funnel = new Funnel();

        public float TopDiameter
        {
            get { return funnel.topDiameter; }
            set { funnel.topDiameter = value; GenerateProceduralFunnel(); }
        }

        public float BottomDiameter
        {
            get { return funnel.bottomDiameter; }
            set { funnel.bottomDiameter = value; GenerateProceduralFunnel(); }
        }

        public float SlopingHeight
        {
            get { return funnel.slopingHeight; }
            set { funnel.slopingHeight = value; GenerateProceduralFunnel(); }
        }

        public float TubeHeight
        {
            get { return funnel.tubeHeight; }
            set { funnel.tubeHeight = value; GenerateProceduralFunnel(); }
        }
        public int Segments
        {
            get { return funnel.Segments; }
            set { funnel.Segments = value; GenerateProceduralFunnel(); }
        }

    private MeshFilter meshFilter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        GenerateProceduralFunnel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateProceduralFunnel()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Procedural Funnel";

        int vertCount = funnel.Segments * 2 + funnel.Segments * 2;
        Vector3[] vertices = new Vector3[vertCount];
        int[] triangles = new int[funnel.Segments * 12];
        Vector2[] uvs = new Vector2[vertCount];

        float angleStep = 2 * Mathf.PI / funnel.Segments;
        int vertIndex = 0;
        int triIndex = 0;

        //top rim vert
        for(int i = 0; i < funnel.Segments; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle) * (funnel.topDiameter / 2);
            float z = Mathf.Sin(angle) * (funnel.topDiameter / 2);
            vertices[vertIndex] = new Vector3(x, funnel.slopingHeight + funnel.tubeHeight, z);
            uvs[vertIndex] = new Vector2(i/(float)funnel.Segments, 1);
            vertIndex++;
        }

        //slope vert
        for(int i = 0; i < funnel.Segments; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle) * (funnel.bottomDiameter / 2);
            float z = Mathf.Sin(angle) * (funnel.bottomDiameter / 2);
            vertices[vertIndex] = new Vector3(x, funnel.tubeHeight, z);
            uvs[vertIndex] = new Vector2(i/(float)funnel.Segments, 0);
            vertIndex++;
        }

        //lower tube vert
        for(int i = 0; i < funnel.Segments; i++)
        {
            float angle  = i * angleStep;
            float x = Mathf.Cos(angle) * (funnel.bottomDiameter / 2);
            float z = Mathf.Sin(angle) * (funnel.bottomDiameter / 2);
            vertices[vertIndex] = new Vector3(x, 0, z);
            float v = funnel.tubeHeight / (funnel.slopingHeight + funnel.tubeHeight); 
            uvs[vertIndex] = new Vector2(i / (float)funnel.Segments, v);
            vertIndex++;
        }

        //sloping tris
        for(int i = 0; i < funnel.Segments; i++)
        {
            int next = (i + 1) % funnel.Segments;
            int topA = i;
            int topB = next;
            int bottomA = i + funnel.Segments;
            int bottomB = next + funnel.Segments;

            triangles[triIndex++] = bottomB;
            triangles[triIndex++] = bottomA;
            triangles[triIndex++] = topA;

            triangles[triIndex++] = topB;
            triangles[triIndex++] = bottomB;
            triangles[triIndex++] = topA;
        }

        //tube tris
        int offset = funnel.Segments * 2;
        for (int i = 0; i < funnel.Segments; i++)
        {
            int next = (i + 1) % funnel.Segments;
            int lowerA = i + funnel.Segments;
            int lowerB = next + funnel.Segments;
            int bottomA = i + offset;
            int bottomB = next + offset;

            triangles[triIndex++] = bottomB;
            triangles[triIndex++] = bottomA;
            triangles[triIndex++] = lowerA;

            triangles[triIndex++] = lowerB;
            triangles[triIndex++] = bottomB;
            triangles[triIndex++] = lowerA; 
        }

        //assign
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }


    
    // public float GetTopDiameter() => funnel.topDiameter;
    // public float GetBottomDiameter() => funnel.bottomDiameter;
    // public float GetSlopingHeight() => funnel.slopingHeight;
    // public float GetTubeHeight() => funnel.tubeHeight;
    // public int GetSegments() => funnel.Segments;
    
    public void UpdateFunnel(float topD, float bottomD, float slopeH, float tubeH, int segments)
    {
        funnel.topDiameter = topD;
        funnel.bottomDiameter = bottomD;
        funnel.slopingHeight = slopeH;
        funnel.tubeHeight = tubeH;
        funnel.Segments = segments;

        GenerateProceduralFunnel();
    }
}
