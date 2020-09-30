using Damdor.Sample;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var model = new PlayerModel {Nick = "Damian", Points = 98, Color = Color.blue};
        var viewModel = new PlayerViewModel(model);
        
        GetComponent<PlayerView>().Setup(viewModel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
