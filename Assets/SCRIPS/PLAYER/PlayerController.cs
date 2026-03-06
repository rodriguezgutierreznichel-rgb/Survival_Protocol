using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player
    [SerializeField] Animator animatorPlayer;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] VIEW view;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuertePlayer()
    {
        animatorPlayer.SetBool("DEAD", true);
        playerMove.enabled = false;
        view.enabled = false;
    }
}
