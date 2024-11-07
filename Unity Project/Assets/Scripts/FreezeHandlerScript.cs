using System;
using System.Collections;
using UnityEngine;

public class CollisionFreezeHandler : MonoBehaviour
{
    // Constante voor de duur van de pauze in milliseconden
    private const float PauseDurationMilliseconds = 100;

    // Methode die wordt aangeroepen bij een botsing van dit object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerPause(); // Start het pauzeproces
    }

    // Methode die de tijd pauzeert
    private void TriggerPause()
    {
        Time.timeScale = 0; // Pauzeer de tijd door Time.timeScale op 0 te zetten
        StartCoroutine(ResumeAfterPause()); // Start een coroutine om de pauze op te heffen
    }


    // Coroutine die de pauze na een bepaalde tijd beëindigt
    private IEnumerator ResumeAfterPause()
    {
        // Wacht voor de opgegeven duur in realtime (geen effect van Time.timeScale)
        yield return new WaitForSecondsRealtime(PauseDurationMilliseconds / 1000);

        Time.timeScale = 1; // Herstel de tijdsschaal naar normaal
    }
}
