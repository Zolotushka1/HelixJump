using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatform : Platform
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Ball") == true ){
            var towerElements = GameObject.FindGameObjectWithTag("Respawn");
            var ball = GameObject.FindGameObjectWithTag("Ball");
            GameObject.Destroy(ball);
            foreach (Transform child in towerElements.transform) {
                GameObject.Destroy(child.gameObject);
            }
            
            var lvlCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
            lvlCount.LevelCounter();
            var UiElement = GameObject.FindGameObjectWithTag("Ui").GetComponent<UiScript>();
            UiElement.LvlCounterShow();
            UiElement.ShowUi();
        }
    }
}
