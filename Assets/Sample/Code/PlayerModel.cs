using Damdor.MVVM;

namespace Damdor.Sample
{

    public class PlayerModel : Model
    {
        public enum PlayerType
        {
            Warrior,
            Wizard,
            Rouge
        }
        
        public PlayerModel(string nick, int points, PlayerType type)
        {
            Nick = nick;
            Points = points;
            Type = type;
        }
        
        public string Nick { get; }
        public int Points { get; private set; }
        public PlayerType Type { get; }

        public void Update(int points)
        {
            Points = points;
            SignalUpdate();
        }
    }
}