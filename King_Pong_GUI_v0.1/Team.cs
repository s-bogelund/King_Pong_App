using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_GUI_v0._1
{
    public class Team : Player
    {
        private List<Player> TeamMembers = new List<Player>();
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool Turn { get; set; }
        public string TeamName { get; set; }

        public Team() { }

        public Team(string teamName, Player player1, Player player2)
        {
            player1 = Player1;
            player2 = Player2;
            teamName = TeamName;
            TeamMembers.Add(player1);
            TeamMembers.Add(player2);
        }
    }
}
