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
            button_1.Content = bucket(11)[0];
            button_2.Content = bucket(11)[1];
            button_3.Content = bucket(11)[2];
            button_4.Content = "Why should I play this creative game?";
        }

        int scoreStore = 0;
        int? level = null;
        public enum Operation { Welcome, Explanation, HowWin, WhyPlay, GameOn, Failure, YouWon }
        public Operation stage = Operation.Welcome;
        public static string[] currentQuestion = bucket(12);
        public Random rnd = new Random();


        public void gameController(Operation stage)
        {
            switch (stage)
            {
                case Operation.Welcome:
                    break;
                case Operation.Explanation:
                    currentQuestion = bucket(13);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this brilliant game?";

                    break;
                case Operation.HowWin:
                    currentQuestion = bucket(14);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this inventive game?";

                    break;
                case Operation.WhyPlay:
                    currentQuestion = bucket(15);
                    Display.Text = currentQuestion[0];
                    button_4.Content = "Why should I play this impressive game?";
                    break;
                case Operation.GameOn:
                    level += 1;
                    scoreStore += 1;
                    Score.Text = scoreStore.ToString();
                    currentQuestion = bucket(rnd.Next(3, 5));
                    break;
                case Operation.Failure:
                    Display.Text = "I'm sorry. You answered incorrectly";
                    break;
                case Operation.YouWon:
                    Display.Text = "Congratulations!! You now know what Joel likes!";
                    break;
                default:
                    break;
            }
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {



        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            if (!level.HasValue)
            {
                stage = Operation.Explanation;
                gameController(stage);
            }

        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            if (!level.HasValue)
            {
                stage = Operation.HowWin;
                gameController(stage);
            }
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            if (!level.HasValue)
            {
                stage = Operation.WhyPlay;
                gameController(stage);
            }
        }


        public static string[] bucket(int key)
        {
            string[] welcome = { "Welcome to JOEL LIKES!" };
            string[] explanation = { "This game will display a question about an activity or tangible item Joel may like. You will be provided with four options. Answer correctly to receive the next question, and continue playing." };
            string[] howWin = {  "This game has ten levels. If you successfully answer all ten questions about Joel, you win! However, if at any point you answer a question incorrectly, you lose."};
            string[] whyPlay = {  "Studies have shown that people who play games tend to be better mentors."};
            string[] introButtons = { "Play Game!", "What is this?", "How do I win?" };
            string[] questOne = { "Question 1", "Answer1", "Answer2", "Answer3", "Answer4", "Answer2" };
            string[] questTwo = { "Question 2", "Answer1", "Answer2", "Answer3", "Answer4", "Answer4" };
            string[] questThree = { "Question 3", "Answer1", "Answer2", "Answer3", "Answer4", "Answer3" };

            Dictionary<int, string[]> questionsAnswers = new Dictionary<int, string[]>();
            questionsAnswers.Add(11, introButtons);
            questionsAnswers.Add(12, welcome);
            questionsAnswers.Add(13, explanation);
            questionsAnswers.Add(14, howWin);
            questionsAnswers.Add(15, whyPlay);
            questionsAnswers.Add(1, questOne);
            questionsAnswers.Add(2, questTwo);
            questionsAnswers.Add(3, questThree);

            return questionsAnswers[key];
        }






    }
}
