using Damdor.Sample;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<SummaryWindow>().Setup(new SummaryViewModel(Server.Player, Server.Opponent));
    }
}
