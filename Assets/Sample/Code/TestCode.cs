using Damdor.Sample;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var model = new PlayerModel("Damian", 77, PlayerModel.PlayerType.Wizard);
        var viewModel = new PlayerViewModel(model);
        
        GetComponent<PlayerView>().Setup(viewModel);
    }
    
}
