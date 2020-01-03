using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObjectController : MonoBehaviour
{
    Animator animator;
    public int quantity = 5;
    public float timeMultiplier = 0.1f;
    ParticleSystem particles;
    float waitToDestroy = 1f;
    public Animation coinAnimation;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        CoinsController coinscontroller = FindObjectOfType<CoinsController>();
        coinscontroller.quantity += quantity;
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null) { 
            if (animator.speed > 0.2f)
                animator.speed -= Time.deltaTime * timeMultiplier;
            else
            {
                if (!particles.isPlaying)
                {
                    particles.Play();
                
                    Destroy(animator);

                    SpriteRenderer sp = GetComponentInChildren<SpriteRenderer>();
                    Debug.Log(sp.name);
                    sp.sprite = null;
                }
                
            }
        }
        else
        {
            waitToDestroy -= Time.deltaTime;
            if (waitToDestroy < 0f)
                Destroy(gameObject);
        }
    }
}
