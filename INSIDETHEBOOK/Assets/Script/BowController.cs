using System.Collections;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BowController : MonoBehaviour
{
    private Animator BowAnimator;
    public string arrowItemName = "Arrow";
    private bool isDrawing = false;

    public string arrowPrefabPath = "Arrow";

    private GameObject arrowPrefab;
    public Transform spawnPosition;

    public float shootingForce = 100;

    private void Start()
    {
        BowAnimator = GetComponent<Animator>();
        LoadArrowPrefab();
    }
    private void LoadArrowPrefab()
    {
        arrowPrefab = Resources.Load<GameObject>(arrowPrefabPath);

        if (arrowPrefab == null)
        {
        }
    }

}
