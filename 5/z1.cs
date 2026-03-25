using System;

abstract class LearningMode
{
    public abstract string GetLearningType();
}

class Online : LearningMode
{
    public override string GetLearningType()
    {
        return "Online: обучение через интернет, гибкий график";
    }
}

class Offline : LearningMode
{
    public override string GetLearningType()
    {
        return "Offline: обучение в аудиториях, личное присутствие";
    }
}

class Hybrid : LearningMode
{
    public override string GetLearningType()
    {
        return "Hybrid: смешанное обучение, сочетание онлайн и офлайн";
    }
}

class Program
{
    static void Main()
    {
        LearningMode[] modes = new LearningMode[]
        {
            new Online(),
            new Offline(),
            new Hybrid()
        };

        foreach (LearningMode mode in modes)
        {
            Console.WriteLine(mode.GetLearningType());
        }
    }
}