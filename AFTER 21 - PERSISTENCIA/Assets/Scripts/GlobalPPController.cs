using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlobalPPController : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    private ColorGrading colorEffect;

    private bool isRuntimeDamage = false;

    private void Awake() {
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out colorEffect);
        PlayerCollision.OnLivesChange += OnDamage;
    }

    private void Start() {
        //StartCoroutine(Damage());
    }

    IEnumerator Damage(){
        isRuntimeDamage = true;
        colorEffect.active = true;
        colorEffect.colorFilter.value = Color.red;
        yield return new WaitForSeconds(2f);
        colorEffect.colorFilter.value = Color.white;
        colorEffect.active = false;
        isRuntimeDamage = false;
    }

    public void OnDamage(int hp){
        if(!isRuntimeDamage){
            StartCoroutine(Damage());
        }
    }
}
