using System;

public class Symulacjagryzycie
{
    public byte[,] GameField { get; private set; }

    public Symulacjagryzycie(int szer = 64, int wys = 64)
    {
        GameField = new byte[szer, wys];
    }

    public void NextCycle()
    {
        int szer = GameField.GetLength(0);
        int wys = GameField.GetLength(1);

        byte[,] nowaPlansza = new byte[szer, wys];

        for (int x = 0; x < szer; x++)
        {
            for (int y = 0; y < wys; y++)
            {
                int sasiedzi = PoliczSasiadow(x, y);

                if (GameField[x, y] == 1)
                {
                    nowaPlansza[x, y] = (sasiedzi == 2 || sasiedzi == 3) ? (byte)1 : (byte)0;
                }
                else
                {
                    if (sasiedzi == 3)
                        nowaPlansza[x, y] = 1;
                }
            }
        }

        GameField = nowaPlansza;
    }

    public void RandomSeed(int ile = 67)
    {
        Random los = new Random();

        while (ile > 0)
        {
            int x = los.Next(GameField.GetLength(0));
            int y = los.Next(GameField.GetLength(1));

            if (GameField[x, y] == 0)
            {
                GameField[x, y] = 1;
                ile--;
            }
        }
    }

    private int PoliczSasiadow(int x, int y)
    {
        int licznik = 0;

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i == x && j == y)
                    continue;

                if (i >= 0 && i < GameField.GetLength(0) &&
                    j >= 0 && j < GameField.GetLength(1))
                {
                    if (GameField[i, j] == 1)
                        licznik++;
                }
            }
        }

        return licznik;
    }
}