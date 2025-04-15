using System.Numerics;
using System.Security.Cryptography.Xml;

namespace Proyecto.ScriptsBaseVJ {
    public class PlayerMovementBase 
    {
        //using UnityEngine;
        //using UnityEngine.SceneManagement;
        //public class PlayerMovement : MonoBehaviour
        //{
        //    public float speed = 5f;
        //    public Transform[] walkPoints;
        //    public GameObject combatManager;

        //    private int currentPointIndex = 0;
        //    private Vector3 target;
        //    private bool inCombat = false;

        //    void Start()
        //    {
        //        if (walkPoints.Length > 0)
        //        {
        //            target = walkPoints[currentPointIndex].position;
        //        }
        //    }

        //    void Update()
        //    {
        //        if (!inCombat)
        //        {
        //            MovePlayer();
        //        }
        //    }
        //    void MovePlayer()
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //        if (transform.position == target)
        //        {
        //            StartCombat();
        //        }
        //    }

        //    void StartCombat()
        //    {
        //        inCombat = true;
        //        SceneManager.LoadScene("CombatScene"); // Load the combat scene
        //    }

        //    public void OnCombatEnd()
        //    {
        //        inCombat = false;
        //        currentPointIndex = (currentPointIndex + 1) % walkPoints.Length;
        //        target = walkPoints[currentPointIndex].position;
        //        SceneManager.LoadScene("MainScene"); // Return to the main scene
        //    }
    }

}
