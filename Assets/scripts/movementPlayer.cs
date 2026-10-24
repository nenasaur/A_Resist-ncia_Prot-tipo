using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float SpeedRun = 8f;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject interactText;
    
    private Rigidbody2D rb;
    private bool running, hide, interact;
    private float horizontalMove;
     private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
          // Pega a referência do SpriteRenderer do objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        horizontalMove =0;
        rb = GetComponent<Rigidbody2D>();
        running = false;
        hide = false;
        interact = false;
        
        // Congela a rotação para o player não capotar nas colisões
        rb.freezeRotation = true;

        // Tenta pegar o Animator automaticamente caso você esqueça de arrastar no Inspector
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. PRIMEIRO capturamos os comandos do jogador
        horizontalMove = Input.GetAxisRaw("Horizontal");

          // Executa o flip baseado na direção do movimento
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false; // Olha para a direita
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;  // Olha para a esquerda
        }
               
        // Captura o clique do agachamento
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("agachando");
        }
        if(Input.GetKey(KeyCode.F))
       {
         interact = true;
       }else{
        interact = false;
       }

        // Verifica se está correndo
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }

       


        // 2. DEPOIS atualizamos as animações (no final do Update)
        moveAnim();
        Debug.Log(interact);
    }

    void FixedUpdate()
    {
        // Define qual velocidade usar baseado se o player está correndo ou não
        float velocidadeAtual = running ? SpeedRun : Speed;

        rb.velocity = new Vector2(horizontalMove * velocidadeAtual, rb.velocity.y);
        //Debug.Log(horizontalMove);
          
    }

    void moveAnim()
    {
        if (anim != null)
        {
            float velocidadeAtual = running ? SpeedRun : Speed;

            // Usamos Mathf.Abs para transformar valores negativos (andar para a esquerda -1) em positivos (1)
            // Assim, seu parâmetro no Animator só precisa verificar se o valor é maior que 0.1 para correr!
            anim.SetFloat("horizontal", Mathf.Abs(horizontalMove));
            if(running){
                 anim.SetFloat("horizontal", 2);
            }
            if(hide){
                 anim.SetBool("hide", true);
            }else{
                anim.SetBool("hide", false);
            }
            

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
     if (other.CompareTag("Door"))
     {
       interactText.SetActive(true);
       if(interact){
        hide = true;
       }if(!interact)
       {
        hide = false;
       }
       
     }
    }

     void OnTriggerExit2D(Collider2D other)
    {
     if (other.CompareTag("Door"))
     {
       interactText.SetActive(false);
     }
    }

}
