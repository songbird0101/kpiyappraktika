using System;

namespace RobotDecorator
{
    public interface IRobot
    {
        string GetStatus();
    }

    public class BasicRobot : IRobot
    {
        public string GetStatus()
        {
            return "Базовый робот: может передвигаться";
        }
    }

    public abstract class RobotDecorator : IRobot
    {
        protected IRobot robot;

        protected RobotDecorator(IRobot robot)
        {
            this.robot = robot;
        }

        public abstract string GetStatus();
    }

    public class VoiceControlDecorator : RobotDecorator
    {
        public VoiceControlDecorator(IRobot robot) : base(robot) { }

        public override string GetStatus()
        {
            return robot.GetStatus() + ", + голосовое управление";
        }
    }

    public class NavigationDecorator : RobotDecorator
    {
        public NavigationDecorator(IRobot robot) : base(robot) { }

        public override string GetStatus()
        {
            return robot.GetStatus() + ", + улучшенная навигация";
        }
    }

    public class SensorDecorator : RobotDecorator
    {
        public SensorDecorator(IRobot robot) : base(robot) { }

        public override string GetStatus()
        {
            return robot.GetStatus() + ", + дополнительные датчики";
        }
    }

    class Program
    {
        static void Main()
        {
            IRobot basicRobot = new BasicRobot();
            Console.WriteLine(basicRobot.GetStatus());
            Console.WriteLine();

            IRobot robotWithVoice = new VoiceControlDecorator(basicRobot);
            Console.WriteLine(robotWithVoice.GetStatus());
            Console.WriteLine();

            IRobot robotWithVoiceAndNav = new NavigationDecorator(robotWithVoice);
            Console.WriteLine(robotWithVoiceAndNav.GetStatus());
            Console.WriteLine();

            IRobot fullRobot = new SensorDecorator(new NavigationDecorator(new VoiceControlDecorator(new BasicRobot())));
            Console.WriteLine(fullRobot.GetStatus());
        }
    }
}