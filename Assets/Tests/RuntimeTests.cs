using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework.Constraints;
using System.Threading.Tasks;

public class RuntimeTests 
{
    private ProceduralFunnel funnel;
    // [UnitySetUp]
    // public IEnumerator SetUp()
    // {
        

    //     yield return null;
    // }
    [Test]
    public async Task Funnel_GenerateMesh_OnStart()
    {
        GameObject funnelObject = new GameObject();
        funnel = funnelObject.AddComponent<ProceduralFunnel>();

        await Task.Delay(3000);
        Assert.IsNotNull(funnel.GetComponent<MeshFilter>().mesh);
        Assert.Greater(funnel.GetComponent<MeshFilter>().mesh.vertexCount, 0);
    }
   
}
