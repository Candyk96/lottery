namespace Lottery
{
    class Program
    {
        /// <summary>
        /// Main program which calls functions in order:
        /// 1. Asks the user to guess the numbers
        /// 2. Draws the numbers
        /// 3. Compares the guessed and drawn numbers
        /// </summary>
        static void Main(string[] args)
        {
            int[] numbers = drawNumbers();
            int[] voucher = guessNumbers();
            
            checkNumbers(voucher, numbers);
        }

        /// <summary>
        /// Asks for user to guess seven numbers between 1 and 40.
        /// Checks that given input is type of int, it is within range and 
        /// it has not been given more than once.
        /// Correct inputs are added into an array which represents a voucher.
        /// </summary>
        public static int[] guessNumbers()
        {
            int[] voucher = new int[7];
            for (int i = 0; i < voucher.Length; ) {
                int number = 0;
                Console.WriteLine("Guess the " + (i + 1) + ". number between 1 and 40: ");
                var numberString = Console.ReadLine();
                if (!int.TryParse(numberString, out number)) {
                    Console.WriteLine("Incorrect value type. Choose a number between 1 and 40: ");
                }
                else 
                {
                    if (number < 1 || number > 40) {
                        Console.WriteLine("Number out of range! Choose a number between 1 and 40: ");
                    }
                    else if (voucher.Contains(number)) {
                        Console.WriteLine("Number " + number + " already exists in the voucher! Choose other number between 1 and 40: ");
                    }
                    else {
                        voucher[i] = number;
                        i++;
                    }
                }
            }
            return voucher;
        }

        /// <summary>
        /// Generates 8 random unique numbers from 1 to 40 and adds them into an array.
        /// Last number in the array is an extra number.
        /// </summary>
        public static int[] drawNumbers() 
        {
            int[] numbers = new int[8];
            for (int i = 0; i < numbers.Length; ) {
                Random random = new Random();
                int rnd = random.Next(1, 41);
                if (!numbers.Contains(rnd)) {
                    numbers[i] = rnd;
                    i++;
                }                
            }
            return numbers;
        }

        /// <summary>
        /// Compares the contents of the two arrays: one with number guessed by user
        /// and other with randomly drawn numbers.
        /// Prints the information on how many numbers the user has guessed correctly.
        /// </summary>
        public static void checkNumbers(int[] voucher, int [] numbers) 
        {
            Console.WriteLine("Guessed numbers: " + string.Join(",", voucher));
            Console.WriteLine("Drawn numbers (last is the extra): " + string.Join(",", numbers));
            int extraNumber = numbers[7];
            bool hasExtra = false;
            int correctNumbers = 0;
            for (int i = 0; i < voucher.Length; i++) {
                if (numbers.Contains(voucher[i])) {
                    correctNumbers++;
                }
            }
            if (voucher.Contains(extraNumber)) {
                hasExtra = true;
                correctNumbers--; // to make sure that extra number is not counted into "main" draw
            }
            if (correctNumbers == 7) {
                Console.WriteLine("You guessed all numbers correctly and won the main prize!");
            }
            else if (correctNumbers == 6 && hasExtra) {
                Console.WriteLine("You guessed " + correctNumbers + " numbers and an extra number correctly and won a very good prize!");
            }
            else if (correctNumbers == 6 && !hasExtra) {
                Console.WriteLine("You guessed " + correctNumbers + " numbers correctly and won a very decent prize!");
            }
            else if (correctNumbers == 5 || correctNumbers == 4) {
                Console.WriteLine("You guessed " + correctNumbers + " numbers correctly and won an ok prize!");
            }
            else if (correctNumbers == 3 && hasExtra) {
                Console.WriteLine("You guessed " + correctNumbers + " numbers and an extra number correctly and won at least something!");
            }
            else if (correctNumbers == 2 || correctNumbers == 1) {
                Console.WriteLine("You guessed " + correctNumbers + " number(s) correctly and did not win anything. Better luck next time!");
            }
            else {
                Console.WriteLine("You did not guess any numbers correctly. Better luck next time!");
            }
        }
    }
}