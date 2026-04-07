using System;

namespace MultimediaPlayer
{
    public interface IMediaFile
    {
        void Play();
        string GetInfo();
    }

    public class AudioFile : IMediaFile
    {
        private string fileName;
        private double duration;

        public AudioFile(string fileName, double duration)
        {
            this.fileName = fileName;
            this.duration = duration;
        }

        public void Play()
        {
            Console.WriteLine($"🎵 Воспроизведение аудиофайла: {fileName} (Длительность: {duration} сек)");
        }

        public string GetInfo()
        {
            return $"Аудиофайл: {fileName}, {duration} сек";
        }
    }

    public class VideoFile : IMediaFile
    {
        private string fileName;
        private string resolution;
        private double duration;

        public VideoFile(string fileName, string resolution, double duration)
        {
            this.fileName = fileName;
            this.resolution = resolution;
            this.duration = duration;
        }

        public void Play()
        {
            Console.WriteLine($"🎬 Воспроизведение видеофайла: {fileName} (Разрешение: {resolution}, Длительность: {duration} сек)");
        }

        public string GetInfo()
        {
            return $"Видеофайл: {fileName}, {resolution}, {duration} сек";
        }
    }

    public class ImageFile : IMediaFile
    {
        private string fileName;
        private string resolution;

        public ImageFile(string fileName, string resolution)
        {
            this.fileName = fileName;
            this.resolution = resolution;
        }

        public void Play()
        {
            Console.WriteLine($"🖼️ Просмотр изображения: {fileName} (Разрешение: {resolution})");
        }

        public string GetInfo()
        {
            return $"Изображение: {fileName}, {resolution}";
        }
    }

    public abstract class MediaFactory
    {
        public abstract IMediaFile CreateMediaFile(string fileName);
        public abstract string MediaType { get; }
    }

    public class AudioFactory : MediaFactory
    {
        private double defaultDuration = 180.0;

        public override string MediaType => "Аудио";

        public override IMediaFile CreateMediaFile(string fileName)
        {
            return new AudioFile(fileName, defaultDuration);
        }

        public IMediaFile CreateMediaFile(string fileName, double duration)
        {
            return new AudioFile(fileName, duration);
        }
    }

    public class VideoFactory : MediaFactory
    {
        private string defaultResolution = "1920x1080";
        private double defaultDuration = 3600.0;

        public override string MediaType => "Видео";

        public override IMediaFile CreateMediaFile(string fileName)
        {
            return new VideoFile(fileName, defaultResolution, defaultDuration);
        }

        public IMediaFile CreateMediaFile(string fileName, string resolution, double duration)
        {
            return new VideoFile(fileName, resolution, duration);
        }
    }

    public class ImageFactory : MediaFactory
    {
        private string defaultResolution = "1920x1080";

        public override string MediaType => "Изображение";

        public override IMediaFile CreateMediaFile(string fileName)
        {
            return new ImageFile(fileName, defaultResolution);
        }

        public IMediaFile CreateMediaFile(string fileName, string resolution)
        {
            return new ImageFile(fileName, resolution);
        }
    }

    public class MediaPlayer
    {
        public void PlayMedia(IMediaFile media)
        {
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine($"Информация: {media.GetInfo()}");
            media.Play();
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            MediaPlayer player = new MediaPlayer();

            MediaFactory audioFactory = new AudioFactory();
            MediaFactory videoFactory = new VideoFactory();
            MediaFactory imageFactory = new ImageFactory();

            IMediaFile audio = audioFactory.CreateMediaFile("song.mp3");
            IMediaFile video = videoFactory.CreateMediaFile("movie.mp4");
            IMediaFile image = imageFactory.CreateMediaFile("photo.jpg");

            player.PlayMedia(audio);
            player.PlayMedia(video);
            player.PlayMedia(image);

            AudioFactory customAudioFactory = new AudioFactory();
            VideoFactory customVideoFactory = new VideoFactory();
            ImageFactory customImageFactory = new ImageFactory();

            IMediaFile customAudio = customAudioFactory.CreateMediaFile("podcast.mp3", 3600);
            IMediaFile customVideo = customVideoFactory.CreateMediaFile("tutorial.mp4", "3840x2160", 5400);
            IMediaFile customImage = customImageFactory.CreateMediaFile("wallpaper.png", "3840x2160");

            player.PlayMedia(customAudio);
            player.PlayMedia(customVideo);
            player.PlayMedia(customImage);
        }
    }
}