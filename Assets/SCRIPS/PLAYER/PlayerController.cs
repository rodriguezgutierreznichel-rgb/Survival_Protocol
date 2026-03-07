using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player
    [SerializeField] Animator animatorPlayer;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] VIEW view;

    //UI
    [SerializeField] GameObject ui_game;
    [SerializeField] GameObject ui_derrota;
    

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
        animatorPlayer.SetBool("RUN", false);
        animatorPlayer.SetBool("ATTACK", false);
        animatorPlayer.SetBool("WALKING", false);
        animatorPlayer.SetBool("BACKWARDS", false);
        animatorPlayer.SetBool("LEFT", false);
        animatorPlayer.SetBool("RIGHT", false);
        animatorPlayer.SetBool("AIM", false);
        playerMove.enabled = false;
        view.enabled = false;
        ui_game.SetActive(false);
        ui_derrota.SetActive(true);
        
    }
}
