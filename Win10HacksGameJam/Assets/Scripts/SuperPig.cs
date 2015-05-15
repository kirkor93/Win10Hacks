﻿using UnityEngine;
using System.Collections;

public class SuperPig : MonoBehaviour {

    public float Speed = 5.0f;

    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        this.myTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        this.myTransform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

    void SmashPig()
    {
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        this.gameObject.SetActive(false);
    }
}