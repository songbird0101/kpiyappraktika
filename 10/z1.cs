using System;

class AudioPlayer
{
    private static AudioPlayer instance;
    private bool isPlaying;
    private string currentTrack;

    private AudioPlayer()
    {
        isPlaying = false;
        currentTrack = "";
    }

    public static AudioPlayer GetInstance()
    {
        if (instance == null)
        {
            instance = new AudioPlayer();
        }
        return instance;
    }

    public void Play(string track)
    {
        currentTrack = track;
        isPlaying = true;
        Console.WriteLine("Воспроизведение: " + track);
    }

    public void Stop()
    {
        if (isPlaying)
        {
            Console.WriteLine("Остановлено: " + currentTrack);
            isPlaying = false;
            currentTrack = "";
        }
        else
        {
            Console.WriteLine("Ничего не воспроизводится");
        }
    }
}

class Program
{
    static void Main()
    {
        AudioPlayer player1 = AudioPlayer.GetInstance();
        AudioPlayer player2 = AudioPlayer.GetInstance();

        Console.WriteLine("Один экземпляр: " + (player1 == player2));

        player1.Play("Song.mp3");
        player2.Stop();
    }
}