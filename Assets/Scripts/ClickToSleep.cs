using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSleep : ClickerBase
{
    [SerializeField] GameEvent gameEventSleep;
    private void OnMouseDown() => Die();


    private void Die()
    {
        if (canChangeState)
        {
            canChangeState = false;
            StartCoroutine(SimulateSun_Coroutine());
            StartCoroutine(Dissolve());
            playerAnim.SetBool("Death", true);
            playerAnim.SetBool("Running", false);
            gameEventSleep?.Invoke();
        }
    }

    private IEnumerator Dissolve()
    {
        float timer = 0;
        float dissolveSpeed = 0.4f;
        while (true)
        {
            if (timer >= 1)
            {
                canChangeState = true;
                yield break;
            }
            yield return null;
            dissolveMaterial.SetFloat("_DissolveAmount", timer);
            timer += Time.deltaTime * dissolveSpeed;
        }
    }

}
