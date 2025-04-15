using Microsoft.AspNetCore.Components.RenderTree;
using System.Numerics;
using System.Security.Cryptography.Xml;

namespace Proyecto.ScriptsBaseVJ
{
    public class ScenarioBuilderBase
    {
        //using UnityEngine;

        //[CreateAssetMenu(fileName = "NewPlatformGenerator", menuName = "Scenario/PlatformGenerator")]
        //public class PlatformGenerator : ScriptableObject
        //{
        //    public int numberOfPlatforms = 10;
        //    public GameObject[] platforms; // List of possible platforms
        //    public float platformSpacing = 1.0f; // Distance between platforms

        //    public void GeneratePlatforms(Transform parent)
        //    {
        //        Vector3 currentPosition = Vector3.zero;

        //        for (int i = 0; i < numberOfPlatforms; i++)
        //        {
        //            GameObject platform = Instantiate(GetRandomPlatform(), currentPosition, Quaternion.identity, parent);
        //            currentPosition.x += platform.GetComponent<Renderer>().bounds.size.x + platformSpacing;
        //        }
        //    }

        //    private GameObject GetRandomPlatform()
        //    {
        //        return platforms[Random.Range(0, platforms.Length)];
        //    }
        //}

}
}
