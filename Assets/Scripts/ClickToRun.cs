using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToRun : ClickerBase
{
    [SerializeField] GameEvent gameEventRun;
    private void OnMouseDown() => Run();

    private void Run()
    {
        if (canChangeState)
        {
            canChangeState = false;
            StartCoroutine(Spawn());
            StartCoroutine(SimulateSun_Coroutine());
            playerAnim.SetBool("Death", false);
            playerAnim.SetBool("Running", true);
            gameEventRun?.Invoke();

        }
    }

    private IEnumerator Spawn()
    {
        float dissolveAmount = 0.6f;
        dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);
        float spawnSpeed = 0.4f;
        while (true)
        {
            if (dissolveAmount <= 0)
            {
                canChangeState = true;
                yield break;
            }
            yield return null;
            dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);
            dissolveAmount -= Time.deltaTime * spawnSpeed;
        }
    }
}
