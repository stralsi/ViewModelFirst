using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst;
using ViewModelFirst.Models;

namespace ViewModelFirst.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Player _player;

        public PlayerViewModel(Player player)
        {
            _player = player;            
        }

        public override string Title
        {
            get { return "Player Details - " + _player.Name; }
        }

        public int Years
        {
            get { return _player.Years; }
            set { _player.Years = value; }
        }

        public double Average
        {
            get { return _player.Average; }
            set { _player.Average = value; }
        }
    }
}
