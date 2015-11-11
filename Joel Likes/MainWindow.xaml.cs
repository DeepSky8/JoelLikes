using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Joel_Likes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Display.Text = "Welcome to JOEL LIKES!!!";
            Score.Text = "0";
            button_1.Content = bucket(21)[0];
            button_2.Content = bucket(21)[1];
            button_3.Content = bucket(21)[2];
            button_4.Content = "Why should I play this creative game?";
        }

        int? level = null;
        public enum Operation { Welcome, Explanation, HowWin, WhyPlay, GameOn, Failure, YouWon }
        public Operation stage = Operation.Welcome;

        public static string[] currentQuestion = bucket(22);
        public int[] selectedOrder = orderOptions();

        public void gameController(Operation stage)
        {
            switch (stage)
            {
                case Operation.Welcome:

                    break;
                case Operation.Explanation:
                    currentQuestion = bucket(23);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this brilliant game?";

                    break;
                case Operation.HowWin:
                    currentQuestion = bucket(24);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this inventive game?";

                    break;
                case Operation.WhyPlay:
                    currentQuestion = bucket(25);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this impressive game?";
                    break;
                case Operation.GameOn:
                    if (!level.HasValue)
                    {
                        level = -1;
                    }
                    if (level < 10)
                    {
                        level += 1;
                        currentQuestion = bucket(selectedOrder.ElementAt((int)level));
                        Score.Text = level.ToString();
                        button_1.Content = currentQuestion[2];
                        button_2.Content = currentQuestion[3];
                        button_3.Content = currentQuestion[4];
                        button_4.Content = currentQuestion[5];
                        Display.Text = currentQuestion[0];
                    }
                    else
                    {
                        stage = Operation.YouWon;
                        gameController(stage);
                    }
                   
                    break;
                case Operation.Failure:
                    currentQuestion = bucket(0);
                    button_1.Content = currentQuestion[0];
                    button_1.IsEnabled = false;
                    button_2.Content = currentQuestion[0];
                    button_2.IsEnabled = false;
                    button_3.Content = currentQuestion[0];
                    button_3.IsEnabled = false;
                    button_4.Content = "Play Again";
                    Display.Text = "I'm sorry. You answered incorrectly";
                    break;
                case Operation.YouWon:
                    currentQuestion = bucket(0);
                    button_1.Content = currentQuestion[1];
                    button_1.IsEnabled = false;
                    button_2.Content = currentQuestion[1];
                    button_2.IsEnabled = false;
                    button_3.Content = currentQuestion[1];
                    button_3.IsEnabled = false;
                    button_4.Content = currentQuestion[1];
                    button_4.IsEnabled = false;
                    Display.Text = "Congratulations!! You now know a lot more about what Joel likes!";
                    break;
                default:
                    break;
            }
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            int button = 1;
            if (!level.HasValue)
            {
                stage = Operation.GameOn;
                gameController(stage);
            }
            else
            {
                if (currentQuestion[1] == button.ToString())
                {
                    stage = Operation.GameOn;
                    gameController(stage);
                }
                else
                {
                    stage = Operation.Failure;
                    gameController(stage);
                }
            }

        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            int button = 2;
            if (!level.HasValue)
            {
                stage = Operation.Explanation;
                gameController(stage);
            }
            else
            {
                if (currentQuestion[1] == button.ToString())
                {
                    stage = Operation.GameOn;
                    gameController(stage);
                }
                else
                {
                    stage = Operation.Failure;
                    gameController(stage);
                }
            }

        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            int button = 3;
            if (!level.HasValue)
            {
                stage = Operation.HowWin;
                gameController(stage);
            }
            else
            {
                if (currentQuestion[1] == button.ToString())
                {
                    stage = Operation.GameOn;
                    gameController(stage);
                }
                else
                {
                    stage = Operation.Failure;
                    gameController(stage);
                }
            }
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            if (stage == Operation.Failure)
            {
                stage = Operation.Welcome;
                gameController(stage);
            }
            else
            {
                int button = 4;
                if (!level.HasValue)
                {
                    stage = Operation.WhyPlay;
                    gameController(stage);
                }
                else
                {
                    if (currentQuestion[1] == button.ToString())
                    {
                        stage = Operation.GameOn;
                        gameController(stage);
                    }
                    else
                    {
                        stage = Operation.Failure;
                        gameController(stage);
                    }
                }
            }

        }


        public static int[] orderOptions()
        {
            int[] firstOrder = { 5, 7, 9, 11, 13, 15, 1, 3, 2, 4, 6, 8, 10, 12, 14 };
            int[] secondOrder = { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] thirdOrder = { 6, 3, 1, 8, 15, 13, 11, 7, 5, 2, 10, 4, 14, 9, 12 };
            int[] fourthOrder = { 11, 1, 10, 2, 8, 3, 5, 4, 15, 6, 9, 7, 14, 13, 14 };
            int[] fifthOrder = { 13, 11, 2, 3, 5, 15, 1, 14, 4, 10, 12, 7, 8, 9, 6 };

            Random rnd = new Random();
            int pickFrom = rnd.Next(1, 6);

            Dictionary<int, int[]> setOptions = new Dictionary<int, int[]>();
            setOptions.Add(1, firstOrder);
            setOptions.Add(2, secondOrder);
            setOptions.Add(3, thirdOrder);
            setOptions.Add(4, fourthOrder);
            setOptions.Add(5, fifthOrder);

            int[] selectedOrder = setOptions[pickFrom];


            return selectedOrder;
        }

        public static string[] bucket(int key)
        {
            string[] welcome = { "Welcome to JOEL LIKES!" };
            string[] explanation = { "This game will display a question about an activity or tangible item Joel may like. Answer correctly to receive the next question.", "Continue", "Continue" };
            string[] howWin = {  "If you successfully answer all ten questions about Joel, you win! If at any point you answer a question incorrectly, you lose.", "Continue", "Continue" };
            string[] whyPlay = {  "Studies have shown that people who play games tend to be better mentors.","Continue", "Continue" };
            string[] introButtons = { "Play Game!", "What is this?", "How do I win?" };
            string[] failureWinner = { "Incorrect", "Success!" };
            string[] questOne = {   "This is the type of beer that Joel likes best:",
                                    "2",
                                    "IPAs",
                                    "Stouts",
                                    "Coors Light",
                                    "Trick question! Joel doesn't drink beer!" };
            string[] questTwo = {   "Joel prefers to listen to:",
                                    "4",
                                    "Death Metal",
                                    "Indie bands",
                                    "Orchestral pieces",
                                    "Jazz/Ambient" };
            string[] questThree = { "Joel is married to:",
                                    "3",
                                    "Evelyn",
                                    "Sarah",
                                    "Rebecca",
                                    "Susan" };
            string[] questFour = {  "The longest race in which Joel has participated is the:",
                                    "1",
                                    "Flying Pig Half Marathon",
                                    "Disney World Marathon",
                                    "Color-Run 5k",
                                    "Queen Bee Half Marathon" };
            string[] questFive = {  "Joel is currently training to run the:",
                                    "2",
                                    "Flying Pig Half Marathon",
                                    "Disney World Marathon",
                                    "Queen Bee Half Marathon",
                                    "Trick Question! Joel doesn't run!" };
            string[] questSix = {   "Joel only plays video games on a(n):",
                                    "4",
                                    "XBOX",
                                    "PlayStation",
                                    "Nintendo Wii",
                                    "Computer" };
            string[] questSeven = { "Joel loves to read:",
                                    "4",
                                    "Biographies/Autobiographies",
                                    "Comic Books",
                                    "Wikipedia",
                                    "Science Fiction/Fantasy" };
            string[] questEight = { "The state where Joel grew up was:",
                                    "3",
                                    "Ohio",
                                    "Kentucky",
                                    "Indiana",
                                    "Nebraska" };
            string[] questNine = {  "Joel's favorite color is:",
                                    "1",
                                    "Green",
                                    "Blue",
                                    "Purple",
                                    "Yellow" };
            string[] questTen = {   "This is the number of instruments Joel can play:",
                                    "3",
                                    "1",
                                    "2",
                                    "3",
                                    "4" };
            string[] questEleven = {"Joel has this many siblings:",
                                    "3",
                                    "1",
                                    "3",
                                    "5",
                                    "9" };
            string[] questTwelve = {"Joel likes to play this kind of card game:",
                                    "1",
                                    "Magic: the Gathering",
                                    "Euchre",
                                    "ERS",
                                    "Bridge" };
            string[] questThirteen = {"Joel left the Boy Scouts with this rank:",
                                    "4",
                                    "First Class Scout",
                                    "Star Scout",
                                    "Life Scout",
                                    "Eagle Scout" };
            string[] questFourteen = {"Joel's favorite sports team is:",
                                    "4",
                                    "Da Bears",
                                    "Indianapolis Colts",
                                    "Cincinnati Reds",
                                    "Trick Question! Joel doesn't care about sports!" };
            string[] questFifteen = {"Joel received his driver's license at age:",
                                    "3",
                                    "15 and 1/2",
                                    "16",
                                    "19",
                                    "21" };

            Dictionary<int, string[]> questionsAnswers = new Dictionary<int, string[]>();
            questionsAnswers.Add(21, introButtons);
            questionsAnswers.Add(22, welcome);
            questionsAnswers.Add(23, explanation);
            questionsAnswers.Add(24, howWin);
            questionsAnswers.Add(25, whyPlay);
            questionsAnswers.Add(0, failureWinner);
            questionsAnswers.Add(1, questOne);
            questionsAnswers.Add(2, questTwo);
            questionsAnswers.Add(3, questThree);
            questionsAnswers.Add(4, questFour);
            questionsAnswers.Add(5, questFive);
            questionsAnswers.Add(6, questSix);
            questionsAnswers.Add(7, questSeven);
            questionsAnswers.Add(8, questEight);
            questionsAnswers.Add(9, questNine);
            questionsAnswers.Add(10, questTen);
            questionsAnswers.Add(11, questEleven);
            questionsAnswers.Add(12, questTwelve);
            questionsAnswers.Add(13, questThirteen);
            questionsAnswers.Add(14, questFourteen);
            questionsAnswers.Add(15, questFifteen);

            return questionsAnswers[key];
        }






    }
}
