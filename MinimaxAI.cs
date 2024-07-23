public class MinimaxAI
{
    private char aiPlayer;
    private char humanPlayer;

    public MinimaxAI(char aiPlayer, char humanPlayer)
    {
        this.aiPlayer = aiPlayer;
        this.humanPlayer = humanPlayer;
    }

    public (int, int) FindBestMove(char[,] board)
    {
        int bestScore = int.MinValue;
        (int, int) bestMove = (-1, -1);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                {
                    board[i, j] = aiPlayer;
                    int score = Minimax(board, 0, false);
                    board[i, j] = ' ';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = (i, j);
                    }
                }
            }
        }

        return bestMove;
    }

    private int Minimax(char[,] board, int depth, bool isMaximizing)
    {
        char winner = CheckWinner(board);
        if (winner == aiPlayer)
        {
            return 10 - depth;
        }
        else if (winner == humanPlayer)
        {
            return depth - 10;
        }
        else if (IsBoardFull(board))
        {
            return 0;
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = aiPlayer;
                        int score = Minimax(board, depth + 1, false);
                        board[i, j] = ' ';
                        bestScore = Math.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = humanPlayer;
                        int score = Minimax(board, depth + 1, true);
                        board[i, j] = ' ';
                        bestScore = Math.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    private bool IsBoardFull(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    private char CheckWinner(char[,] board)
    {
        // Kontrollera rader och kolumner
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }

            if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                return board[0, i];
            }
        }

        // Kontrollera diagonaler
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        return ' ';
    }
}
