using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModelFirst.Models
{
    public class Context
    {
        private List<Player> _players = new List<Player>
        {
            new Player { Name = "Player 1", Years = 5, Average = 0.23 },
            new Player { Name = "Player 2", Years = 7, Average = 0.32 },
            new Player { Name = "Player 3", Years = 3, Average = 0.35 },
        };

        public IEnumerable<Player> Players
        {
            get { return _players; }
        }

        public Player GetPlayer(string name)
        {
            return _players.Single(player => player.Name == name);
        }
    }
}
