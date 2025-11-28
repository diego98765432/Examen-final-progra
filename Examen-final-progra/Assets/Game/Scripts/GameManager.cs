using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public int puntos;

    [SerializeField] private TextMeshProUGUI textoPuntos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntos(int puntosGanados)
    {
        puntos += puntosGanados;
        textoPuntos.text = puntos.ToString();
    }
}
