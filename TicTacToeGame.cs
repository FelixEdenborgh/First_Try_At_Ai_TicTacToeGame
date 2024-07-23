using System;

public class TicTacToeGame
{
    private char[,] board;
    private char currentPlayer;

    public TicTacToeGame()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    public void DisplayBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    public bool IsBoardFull()
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

    public bool MakeMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
        {
            return false;
        }

        board[row, col] = currentPlayer;
        return true;
    }

    public bool CheckWin()
    {
        // Kontrollera rader och kolumner
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        // Kontrollera diagonaler
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    public char GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public char[,] GetBoard()
    {
        return board;
    }
}
