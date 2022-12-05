namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomWordHandler wordHandler = new RandomWordHandler();
            wordHandler.getTheWord();
            Console.WriteLine("H A N G M A N");
            var goodLetteras = new List<char>();
            var badLetters = new List<char>();
            bool work = true;
            bool guessed = false;
            char letter = ' ';

            HangmanPaint painter = new HangmanPaint();


            while (work)
            {
                painter.paint(badLetters.Count);
                wordHandler.paintGuessedLetters(goodLetteras);
                painter.missedLetters(badLetters);
                letter = Console.ReadKey().KeyChar;
                guessed = wordHandler.checkWord(letter, goodLetteras, badLetters);

                if (badLetters.Count >= 7)
                {
                    work = false;
                }

                if (guessed)
                {
                    work = false;
                }
                Console.WriteLine();
            }

            if (guessed)
            {
                Console.WriteLine("You guessed the word");
                Console.WriteLine("Do you want to restart? y/n");
                letter = Console.ReadKey().KeyChar;
            }
            else
            {
                painter.paint(badLetters.Count);
                Console.WriteLine("You hanged yourself");
                Console.WriteLine("Do you want to restart? y/n");
                letter = Console.ReadKey().KeyChar;
            }

            if (letter == 'y')
            {
                Main(args);
            }


        }
    }

    internal class RandomWordHandler
    {
        private Random rnd = new Random();
        private string word = "";

        public void getTheWord()
        {
            string[] cities =
            {
                "vilnius",
                "klaipeda",
                "tokyo",
                "shanghai",
                "cairo",
                "dhaka",
                "mumbai",
                "berlin",
                "praha",
                "london"
            };

            this.word = cities[this.rnd.Next(0, (cities.Length - 1))];
            Console.WriteLine(this.word);
        }

        public bool checkWord(char letter, List<char> goodLetters, List<char> badLetters)
        {
            int found = 0;
            bool guessed = false;

            foreach (char c in this.word)
            {
                if (letter == c)
                {
                    found++;
                }
            }

            if (found > 0)
            {
                for (int i = 0; i < found; i++)
                {
                    goodLetters.Add(letter);
                }
                bool foundGoodLetter = false;
                foreach (char goodLetter in goodLetters)
                {
                    if (goodLetter == letter)
                    {
                        foundGoodLetter = true;
                    }
                }
                if (!foundGoodLetter)
                    badLetters.Add(letter);
            }
            else
            {
                bool foundBadLetter = false;
                foreach (char badLetter in badLetters)
                {
                    if (badLetter == letter)
                    {
                        foundBadLetter = true;
                    }
                }
                if (!foundBadLetter)
                    badLetters.Add(letter);
            }

            if (goodLetters.Count == this.word.Length)
            {
                guessed = true;
            }

            return guessed;
        }

        public void paintGuessedLetters(List<char> guessedLetters)
        {
            Console.Write("Guessed letters:");
            bool guessed = false;

            foreach (char w in this.word)
            {
                guessed = false;
                foreach (char c in guessedLetters)
                {
                    if (c == w)
                    {
                        guessed = true;
                    }
                }
                if (guessed)
                    Console.Write(w);
                else
                    Console.Write("_");
            }
            Console.WriteLine();
        }
    }

    internal class HangmanPaint
    {
        public void paint(int count)
        {
            switch (count)
            {
                case 0:
                    Console.WriteLine("+---+");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 1:
                    Console.WriteLine("+---+");
                    Console.WriteLine("O   |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 2:
                    Console.WriteLine("+---+");
                    Console.WriteLine("O   |");
                    Console.WriteLine("|   |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 3:
                    Console.WriteLine(" +---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|   |");
                    Console.WriteLine("     |");
                    Console.WriteLine("    ===");
                    break;
                case 4:
                    Console.WriteLine(" +---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine("     |");
                    Console.WriteLine("    ===");
                    break;
                case 5:
                    Console.WriteLine(" +---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine(" |   |");
                    Console.WriteLine("    ===");
                    break;
                case 6:
                    Console.WriteLine(" +---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine(" |   |");
                    Console.WriteLine("/   ===");
                    break;
                case 7:
                    Console.WriteLine(" +---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine(" |   |");
                    Console.WriteLine("/ \\  ===");
                    break;

            }

        }

        public void missedLetters(List<char> badLetters)
        {
            Console.Write("Missed Letters:");
            foreach (char c in badLetters)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}