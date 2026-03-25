using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RawImage obrazPlanszy;

    private Texture2D texture;
    private Symulacjagryzycie gra;

    public int szerokosc = 150;
    public int wysokosc = 150;

    private float timer = 0f;
    private float interval = 0.2f;
    private bool isRunning = false;

    void Start()
    {
        gra = new Symulacjagryzycie(szerokosc, wysokosc);
        gra.RandomSeed(5000);

        texture = new Texture2D(szerokosc, wysokosc);
        texture.filterMode = FilterMode.Point;

        obrazPlanszy.texture = texture;

        RysujPlansze();
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            NextStep();
        }
    }

    void RysujPlansze()
    {
        for (int x = 0; x < szerokosc; x++)
        {
            for (int y = 0; y < wysokosc; y++)
            {
                if (gra.GameField[x, y] == 1)
                    texture.SetPixel(x, y, Color.black);
                else
                    texture.SetPixel(x, y, Color.white);
            }
        }

        texture.Apply();
    }

    public void StartGame()
    {
        isRunning = true;
    }

    public void StopGame()
    {
        isRunning = false;
    }

    public void NextStep()
    {
        gra.NextCycle();
        RysujPlansze();
    }

    public void ResetGame()
    {
        isRunning = false;
        gra = new Symulacjagryzycie(szerokosc, wysokosc);
        gra.RandomSeed(5000);
        RysujPlansze();
    }
}