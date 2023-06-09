﻿using _1095652_Roth_HuntTheWumpus;
using Epshtein;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;

namespace Cao
{
    public partial class SubmitAnswerButton : Form
    {
        string answer;
         int QuestionNumber  = 1;
        public Player player { get; set; }
        public int askNumber { get; set; } = 0;
        public int CorrectNumber { get; set; } = 0;

        Random RandomGenerator = new Random();
        //.OrderBy(_=>generator.Next()).ToArray();
        Dictionary<string, List<string>> questions = new Dictionary<string, List<string>>()
        {
            //trivia questions
            {"When was the KGB founded?",  new List<string> {"1953", "1954", "1955", "1964" } },
            {"Who plays Lavrentiy Beria in the movie The Death of Stalin?",  new List<string> {"George Beale Russell", "Jeffery Tambor", "Steve Buscemi", "Jason Isaacs" } },
            {"In what bomber did Putin fly in during an inspection?", new List<string>{"Tu-160M2", "Tu-160M", "Tu-160S", "Tu-160" } },
            {"What is Putin's shoe size?", new List<string>{"9", "8", "7", "10"} },
            {"Which KGB directorate did Putin work for?", new List<string>{"2nd", "1st", "3rd", "4th" } },
            {"Which of these countries did not withdraw its signature from the Rome Statute?", new List<string>{"China", "Russia", "USA", "Sudan" } },
            {"How many countries are state parties to the Rome Statute?", new List<string>{"123", "139", "112", "90"} },
            {"What discipline did Putin receive his PhD in?", new List<string>{"Economics", "Finance", "Business", "Mechanical Engineering" } },
            {"Who is the chief of Wagner Group?", new List<string>{"Yevgeny Prigozhin", "Dimitry Utkin", "Andrei Troshev", "Konstantin Pikalov" } },
            {"How many pets has/does Putin had/have?", new List<string>{"5", "3", "1", "7" } },
            {"How old is Putin?", new List<string>{"70", "57", "63", "31" } },
            {"How large is russia?", new List<string>{ "16,400,000 m^2", " 31,200,000 m^2", "5,700,000 m^2", "11,500,000 m^2" } },
            {"How many terms has Putin had as president of russia?", new List<string>{"4", "3", "2", "1" } },
            {"What Martial art does Putin have a black belt in?", new List<string>{"Judo", "Karate", "Sambo", "Taekwondo" } },
            {"In 2016 what american celebrity did Putin give Russian Citizenship to?", new List<string>{"Steven Seagal", "Katy Perry", "Tom Cruise", "Frank Sinatra" } },
            {"In what place was Putin born?", new List<string>{"Russia", "Ukraine", "Poland", "Georgia" } },
            {"How many Kinzhal missiles did Ukraine claim to have shot down?", new List<string>{"7", "6", "5", "0" } },
            {"Which airport did Russia attack in the opening days of the invasion?", new List<string>{"Antonov Airport", "Odessa Airport", "Mikolayev Airport", "Mariupol Airport"} },
            {"What is the largest city in Crimea?", new List<string>{"Sevastapol", "Kerch", "Simferopol", "Yevpatoriya"} },
            {"When did the Battle of Bakhmut begin?", new List<string>{"1 August 2022", "23 February 2022", "5 May 2022", "9th December 2022" } },
            {"How many Armata tanks showed up to the 2022 Victory Day parade?", new List<string>{"3", "2", "4", "5" } },
            {"What is the latest model of T-72?", new List<string>{"T-72B3M", "T-72BU", "T-72AV", "T-72B3"} },
            {"What color Formula One car did Putin drive in 2010?", new List<string>{"Yellow", "Blue", "Red", "Orange"}},
            {"Which Press Secretary told the truth about Putin's 2011 scuba dive?", new List<string>{"Dimitry Peskov", "Natalya Timakova", "Alexei Gromov", "Dimitry Medvedev" }},
            {"Заполни эту цитату: И если бы за ____ часов до операции не был нанесён превентивный удар по позициям ", new List<string>{"шесть", "пять", "семь", "восемь"}},
            {"What was Yevgeny Prigorizhin's profession before he joined Wagner Group?", new List<String>{"Children's Book Author", "Chef", "Judo Instructor", "Used Car Salesman"} },
            {"Which endangered bird did Putin attempt to lead on a migration route?", new List<String>{"Siberian White Cranes", "Artic Terns", "Ospreys", "Northern Gannets" } },
            {"When was Putin named Time Magazine's <<Person of the Year>>?", new List<string> {"2007", "1999", "2010", "2018"} },
            {"How many children does putin have?", new List<string>{"2","0","1","3"} },
            {"How many languages does Putin speak?" , new List<string>{"3","1","4","5"} },
            {"In the 2012 Russian Presidential Election, how many federal subjects(regions) were won by the runner-up, Gennady Zyuganov?", new List<string>{"0","5","8","3"} },
            {"How many official residences has Putin lived in during his tenure as president and prime minister?", new List<string>{"6","10", "29", "4"} },
            {"Which football club is Putin as supporter of?", new List<string> { "FC Zenit Saint Petersburg", "FC Dynamo Moscow", "PFC CSKA Moscow", "FC Lokomotiv Saint Petersburg" } }
        };
        //commit test

        public void populate()
        {
            string question = questions.Keys.OrderBy(_ => RandomGenerator.Next()).ToArray()[0];
            string[] answers = questions[question].OrderBy(_ => RandomGenerator.Next()).ToArray();
            answer = questions[question][0];
         

            TriviaQuestion.Text = question;
            //prevent duplicate questions
            questions.Remove(question);


            
            if(!player.payGold(1))
            {
                MessageBox.Show("Comrade, you've ran out of oil money and won't be able to answer any more questions!");
                this.Close();
            }
            Answer1.Text = answers[0];
            Answer2.Text = answers[1];
            Answer3.Text = answers[2];
            Answer4.Text = answers[3];

            label4.Text = (QuestionNumber + "/" + askNumber).ToString();
            label5.Text = CorrectNumber.ToString();
            label6.Text = ((QuestionNumber - CorrectNumber) - 1).ToString();

            Answer1.Checked = false;
            Answer2.Checked = false;
            Answer3.Checked = false;
            Answer4.Checked = false;



        }

        public SubmitAnswerButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Answer1.Checked == true && Answer1.Text == answer)
            {
;
                CorrectNumber++;
            }
            if (Answer2.Checked == true && Answer2.Text == answer)
            {

                CorrectNumber++;
            }
            if (Answer3.Checked == true && Answer3.Text == answer)
            {

                CorrectNumber++;
            }
            if (Answer4.Checked == true && Answer4.Text == answer)
            { 
                CorrectNumber++;
            }
            QuestionNumber++;
            
            if (QuestionNumber > askNumber)
            {
                this.Close();
            }
            populate();

        }

        private void SubmitAnswerButton_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void SubmitAnswerButton_Activated(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
