using UnityEngine;

public class StartGameText : MonoBehaviour
{
    // Dit is dé comment
    BallMovement ballMovement;
    [SerializeField] GameObject playText;
    void Start()
    {
        ballMovement = FindObjectOfType<BallMovement>();
    }

    void Update()
    {
        playText.SetActive(!ballMovement.IsPlaying());
    }
}
