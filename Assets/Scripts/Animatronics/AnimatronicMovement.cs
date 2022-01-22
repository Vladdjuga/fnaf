using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMovement : MonoBehaviour
{
    public CameraAnima cam1a;
    public Animatronics bonnie;
    public Animatronics chica;
    public Animatronics freddy;
    public float chanceReducer;

    void Start()
    {
        #region Bonnie
        bonnie = new Animatronics();
        bonnie.camera = cam1a;
        bonnie.chanceReducer = 10;
        bonnie.name = "bonnie";
        #endregion
        #region Chica
        chica = new Animatronics();
        chica.camera = cam1a;
        chica.chanceReducer = 10;
        chica.name = "chica";
        #endregion
        #region Freddy
        freddy = new Animatronics();
        freddy.camera = cam1a;
        freddy.chanceReducer = 0;
        freddy.name = "freddy";
        #endregion
    }

    void FixedUpdate()
    {
        float rand = Random.value;
        if (rand<bonnie.chanceReducer* chanceReducer)
        {
            rand = Random.value;
            if (rand < bonnie.camera.stepBack_chance && bonnie.camera.stepBack!=null)
            {
                int randInt = Random.Range(0, bonnie.camera.stepBack.Length);
                if (bonnie.camera.stepBack[randInt].is_canBonnie)
                {
                    bonnie.camera = bonnie.camera.stepBack[randInt];
                    Debug.Log($"0 {bonnie.camera.stepBack.Length}");
                    Debug.Log(randInt);
                    Step(bonnie.camera.cameraName);
                }
            }
            else if(rand < bonnie.camera.stepForward_chance && bonnie.camera.stepForward != null)
            {
                int randInt = Random.Range(0, bonnie.camera.stepForward.Length);
                if (bonnie.camera.stepForward[randInt].is_canBonnie)
                {
                    bonnie.camera = bonnie.camera.stepForward[randInt];
                    Debug.Log($"0 {bonnie.camera.stepForward.Length}");
                    Debug.Log(randInt);
                    Step(bonnie.camera.cameraName);
                }
            }
        }
    }
    void Step(string camera)
    {
        Debug.Log($"Step------{camera}");
    }
}
