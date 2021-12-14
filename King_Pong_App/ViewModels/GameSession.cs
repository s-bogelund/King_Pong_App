using King_Pong_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Text.Json;
using Newtonsoft.Json;

namespace King_Pong_App.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GameSession : INotifyPropertyChanged
    {
        /// <summary>
        /// Default constructor that initializes all the game elements needed for the game.
        /// Is called immediately when the application starts.
        /// </summary>
        public GameSession()
        {
            Player1 = new("Player1");
            Player2 = new("Player2");
            Player3 = new("Player3");
            Player4 = new("Player4");

            Team1 = new();
            Team2 = new();

            Cup1_1 = new();
            Cup1_2 = new();
            Cup1_3 = new();
            Cup1_4 = new();
            Cup1_5 = new();
            Cup1_6 = new();
            Cup1_7 = new();
            Cup1_8 = new();
            Cup1_9 = new();
            Cup1_10 = new();

            Cup2_1 = new();
            Cup2_2 = new();
            Cup2_3 = new();
            Cup2_4 = new();
            Cup2_5 = new();
            Cup2_6 = new();
            Cup2_7 = new();
            Cup2_8 = new();
            Cup2_9 = new();
            Cup2_10 = new();

            backFourCups = new()
            {
                Cup1_7, Cup1_8, Cup1_9, Cup1_10,
                Cup2_7, Cup2_8, Cup2_9, Cup2_10
            };
        }

        public List<CupModel> backFourCups;

        [JsonProperty] public int numberOfCups = 10;

        [JsonProperty] public int teamSize = 0;

        public int currentPlayer = 0;
        public bool cupsChosen = false;
        public bool playersCreated = false;
        public bool gameInProgress = false;
        public bool gameOver;
        private bool starterTeamDecided;

        public bool StarterTeamDecided
        {
            get { return starterTeamDecided; }
            set
            {
                starterTeamDecided = value;
                StarterTeamFound?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Resets all the game info to their default values.
        /// This is called if the new game process is disrupted by 
        /// the user closing a window during setup of a new game
        /// </summary>
        public void ResetGameInfo()
        {
            teamSize = 0;
            currentPlayer = 0;
            cupsChosen = false;
            playersCreated = false;
            gameInProgress = false;
            gameOver = false;
        }

        /// <summary>
        /// Changes which team has the turn
        /// </summary>
        public void TurnOver()
        {
            Current = Current == Team1 ? Team2 : Team1;
            currentPlayer = 0;
        }

        private string command;

        /// <summary>
        /// Property which value depends on what is received from the server.
        /// It's this property that is used for calling methods in the game loop.
        /// </summary>
        public string Command
        {
            get { return command; }
            set
            {
                command = value;
                CommandReceived?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event handler that tracks whether the starter team has been found
        /// </summary>
        public event EventHandler StarterTeamFound;

        /// <summary>
        /// Event handler for when a command is received from the server
        /// </summary>
        public event EventHandler CommandReceived;
		

        private TeamModel current;

        /// <summary>
        /// Tracks which team's turn it currently is. 
        /// Also implements INotifyPropertyChanged.
        /// </summary>
        public TeamModel Current
        {
            get { return current; }
            set
            {
                current = value;
                OnPropertyChanged(nameof(Current));
            }
        }

        #region Players and teams

        [JsonProperty] public PlayerModel Player1 { get; set; }
        [JsonProperty] public PlayerModel Player2 { get; set; }
        [JsonProperty] public PlayerModel Player3 { get; set; }
        [JsonProperty] public PlayerModel Player4 { get; set; }

        [JsonProperty] public TeamModel Team1 { get; set; }

        [JsonProperty] public TeamModel Team2 { get; set; }

        #endregion

        #region Cups

        public CupModel Cup1_1 { get; set; }
        public CupModel Cup1_2 { get; set; }
        public CupModel Cup1_3 { get; set; }
        public CupModel Cup1_4 { get; set; }
        public CupModel Cup1_5 { get; set; }
        public CupModel Cup1_6 { get; set; }
        public CupModel Cup1_7 { get; set; }
        public CupModel Cup1_8 { get; set; }
        public CupModel Cup1_9 { get; set; }
        public CupModel Cup1_10 { get; set; }
        public CupModel Cup2_1 { get; set; }
        public CupModel Cup2_2 { get; set; }
        public CupModel Cup2_3 { get; set; }
        public CupModel Cup2_4 { get; set; }
        public CupModel Cup2_5 { get; set; }
        public CupModel Cup2_6 { get; set; }
        public CupModel Cup2_7 { get; set; }
        public CupModel Cup2_8 { get; set; }
        public CupModel Cup2_9 { get; set; }
        public CupModel Cup2_10 { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The implementation of INotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}