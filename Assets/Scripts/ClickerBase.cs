using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerBase : MonoBehaviour
{
    public static bool canChangeState = true;
    [HideInInspector] public Animator playerAnim;
    [HideInInspector] public Material dissolveMaterial;

    public static bool isMorning = true;
    public GameObject sun;
    [HideInInspector] public Vector3 sunMorningPos;
    [HideInInspector] public Vector3 sunNightPos;

    public MeshRenderer sign;
    [HideInInspector] public Color signStartColor;

    public virtual void Awake()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        SkinnedMeshRenderer renderer = playerAnim.gameObject.GetComponentInChildren(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;
        dissolveMaterial = renderer.material;

        sunMorningPos = sun.transform.eulerAngles;
        sunNightPos = new Vector3(sunMorningPos.x + 120, sunMorningPos.y + 120, sunMorningPos.z + 120);
        signStartColor = sign.GetComponent<MeshRenderer>().material.color;

    }

    public IEnumerator SimulateSun_Coroutine()
    {
        float timer = 0;
        Vector3 startPos = isMorning ? sunMorningPos : sunNightPos;
        while (true)
        {
            if (timer >= 1)
            {
                isMorning = !isMorning;
                yield break;
            }


            yield return null;
            timer += Time.deltaTime;
            if (isMorning)
            {
                sun.transform.eulerAngles = Vector3.Slerp(startPos, sunNightPos, timer);
            }
            else
            {
                sun.transform.eulerAngles = Vector3.Slerp(startPos, sunMorningPos, timer);
            }


        }
    }

    public void OpenSign() => sign.GetComponent<MeshRenderer>().material.color = Color.green;

    public void CloseSign() => sign.GetComponent<MeshRenderer>().material.color = signStartColor;

    private void OnMouseEnter() => OpenSign();
    private void OnMouseExit() => CloseSign();

}



