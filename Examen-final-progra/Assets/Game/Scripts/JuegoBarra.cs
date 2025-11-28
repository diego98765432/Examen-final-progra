using UnityEngine;

public class JuegoBarra : MonoBehaviour
{
    [SerializeField] private GameObject fondo;
    [SerializeField] private Transform barraVerde;
    [SerializeField] private float limiteIzqVerde, limiteDerVerde;

    private float limiteIzq, limiteDer;

    [SerializeField] private Transform barraPlayer;
    [SerializeField] private float velocidadBarra;
    private bool derecha = true;
    private float posActual;

    private void Start()
    {
        Vector2 limites = CalcularLimites(fondo.transform, barraPlayer);
        limiteIzq = limites.x;
        limiteDer = limites.y;

    }

    private void Update()
    {
        MoverBarra();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Hit())
            {
                BarraRandom();
                GameManager.Instance.AgregarPuntos(1);
            }
        }
    }

    private Vector2 CalcularLimites(Transform fondo, Transform barra)
    {
        float mitadFondo = fondo.localScale.x / 2f;
        float mitadBarra = barra.localScale.x / 2f;

        float limiteIzq = fondo.position.x - mitadFondo + mitadBarra;
        float limiteDer = fondo.position.x + mitadFondo - mitadBarra;

        return new Vector2(limiteIzq, limiteDer);
    }

    private void BarraRandom()
    {
        float rand = Random.Range(limiteIzqVerde, limiteDerVerde);

        Vector3 nuevaPos = barraVerde.position;
        nuevaPos.x = rand;
        barraVerde.position = nuevaPos;

        Debug.Log("Barra verde nueva pos = " + nuevaPos);
    }

    private void MoverBarra()
    {
        Vector3 pos = barraPlayer.position;

        if (derecha)
            pos.x += velocidadBarra * Time.deltaTime;
        else
            pos.x -= velocidadBarra * Time.deltaTime;

        posActual = pos.x;
        barraPlayer.position = pos;

        if (pos.x >= limiteDer)
            derecha = false;

        if (pos.x <= limiteIzq)
            derecha = true;
    }

    private bool Hit()
    {
        float mitad = barraVerde.localScale.x / 2f;

        float limiteIzqBarra = barraVerde.position.x - mitad;
        float limiteDerBarra = barraVerde.position.x + mitad;

        return posActual >= limiteIzqBarra && posActual <= limiteDerBarra;
    }
}
