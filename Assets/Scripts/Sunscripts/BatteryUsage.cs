using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryUsage : MonoBehaviour
{
    public OfficeObject officeObject;
    public Numbers numbers;
    public float usage = 0f;
    public float defaultUsage = 0f;
    public float energy = 100f;
    public SpriteRenderer num1Sprite;
    public SpriteRenderer num2Sprite;
    public SpriteRenderer usageRenderer;
    public Sprite[] usageSprites;

    public float timer = 0f;
    public float timerSec = 10f;
    public float countUsages = 0f;
    void Start()
    {
        officeObject.door_left = false;
        officeObject.door_right = false;
        officeObject.light_left = false;
        officeObject.light_right = false;
    }

    void FixedUpdate()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= 10)
        {
            timer = 0;
            defaultUsage += 0.00001f;
        }
        usage = 0;
        countUsages = 0f;
        if (officeObject.door_left)
        {
            usage += 0.0007f;
            countUsages += 1.5f;
        }
        if (officeObject.door_right)
        {
            usage += 0.0007f;
            countUsages += 1.5f;
        }
        if (officeObject.light_left)
        {
            usage += 0.0003f;
            countUsages += 1f;
        }
        if (officeObject.light_right)
        {
            usage += 0.0003f;
            countUsages += 1f;
        }

        energy -= usage + defaultUsage;
        int enegeryToInt = (int)Math.Truncate(energy);
        int num1 = enegeryToInt % 10;
        int num2 = 0;
        if (enegeryToInt >= 10)
        {
            num2 = (enegeryToInt % 100 - num1) / 10;
        }
        num1Sprite.sprite = numbers.getSprite(num1);
        num2Sprite.sprite = numbers.getSprite(num2);
        float clamping=Mathf.Clamp(countUsages, 0, usageSprites.Length-1);
        usageRenderer.sprite = usageSprites[(int)Math.Truncate(clamping)];
    }
}
