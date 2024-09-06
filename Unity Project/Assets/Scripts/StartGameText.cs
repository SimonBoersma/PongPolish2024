using UnityEngine;

public class StartGameText : MonoBehaviour
{
    // Dit is géén comment, of toch wel? nee
    BallMovement ballMovement;
    [SerializeField] GameObject playText;
    void Start()
    {
        ballMovement = FindFirstObjectByType<BallMovement>();
    }

    void Update()
    {
        playText.SetActive(!ballMovement.IsPlaying());
    }
}
