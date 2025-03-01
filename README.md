# Procedural Funnel Mesh Generator

This project generates a **procedural funnel mesh** in Unity using C#. The funnel consists of a **top rim, sloping section, and tube section**, with adjustable parameters for dynamic generation.

---

## How It Works

The script dynamically creates a mesh by:
1. **Generating vertices** for the **top rim, slope, and tube** sections.
2. **Mapping UV coordinates** to ensure proper texture tiling.
3. **Defining triangles** to connect the vertices and form the mesh.
4. **Applying the generated mesh** to a `MeshFilter` for rendering.

---

## Usage
1. Pull this project using Git:
`git clone https://github.com/sz-99/WrenKitchens-Unity.git`
3. **Run the scene** to see the procedurally generated funnel.
4. **Modify the funnel parameters** (diameters, height, segments) in the **UI** for realtime rendering of dynamic funnel.




