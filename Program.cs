using System;

class Program
{
    static void Main(string[] args)
    {
        TicTacToeGame game = new TicTacToeGame();
        MinimaxAI ai = new MinimaxAI('O', 'X');

        while (true)
        {
            Console.Clear();
            game.DisplayBoard();
            if (game.CheckWin())
            {
                Console.WriteLine($"Player {game.GetCurrentPlayer()} wins!");
                break;
            }
            if (game.IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                break;
            }

            if (game.GetCurrentPlayer() == 'X')
            {
                Console.WriteLine("Your move! Enter row and column (e.g., 0 1): ");
                var input = Console.ReadLine().Split();
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);
                if (game.MakeMove(row, col))
                {
                    game.SwitchPlayer();
                }
            }
            else
            {
                Console.WriteLine("AI's move:");
                var move = ai.FindBestMove(game.GetBoard());
                game.MakeMove(move.Item1, move.Item2);
                game.SwitchPlayer();
            }
        }

        Console.WriteLine("Game over!");
    }
}
