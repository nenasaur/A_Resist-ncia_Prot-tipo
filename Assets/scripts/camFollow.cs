using UnityEngine;

public class CameraSeguir2D : MonoBehaviour
{
    [SerializeField] private Transform alvo; // Arraste o seu Player para cá no Inspector
    [SerializeField] private float suavidade = 5f;
    [SerializeField] private Vector2 deslocamento; // Permite ajustar a altura/distância da câmera no Inspector

    void LateUpdate()
    {
        if (alvo != null)
        {
            // Define a posição alvo mantendo a câmera fixa em Z = -10 (padrão do Unity 2D)
            Vector3 posicaoAlvo = new Vector3(alvo.position.x + deslocamento.x, alvo.position.y + deslocamento.y, -10f);
            
            // Move a câmera de forma suave até o jogador usando Vector3.Lerp
            transform.position = Vector3.Lerp(transform.position, posicaoAlvo, suavidade * Time.deltaTime);
        }
    }
}
