using System;
using System.Collections.Generic;
using Internal;

namespace TVRemoteCommand
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string GetDescription();
    }

    public class Television
    {
        private bool isOn = false;
        private int volume = 10;

        public void PowerOn()
        {
            isOn = true;
            Console.WriteLine("📺 Телевизор включен");
        }

        public void PowerOff()
        {
            isOn = false;
            Console.WriteLine("📺 Телевизор выключен");
        }

        public void IncreaseVolume()
        {
            if (isOn)
            {
                volume = Math.Min(volume + 5, 100);
                Console.WriteLine($"🔊 Громкость увеличена до {volume}");
            }
            else
            {
                Console.WriteLine("Телевизор выключен");
            }
        }

        public void DecreaseVolume()
        {
            if (isOn)
            {
                volume = Math.Max(volume - 5, 0);
                Console.WriteLine($"🔉 Громкость уменьшена до {volume}");
            }
            else
            {
                Console.WriteLine("Телевизор выключен");
            }
        }

        public int GetVolume()
        {
            return volume;
        }

        public bool IsOn()
        {
            return isOn;
        }
    }

    public class TVPowerOnCommand : ICommand
    {
        private Television tv;

        public TVPowerOnCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.PowerOn();
        }

        public void Undo()
        {
            tv.PowerOff();
        }

        public string GetDescription()
        {
            return "Включить телевизор";
        }
    }

    public class TVPowerOffCommand : ICommand
    {
        private Television tv;

        public TVPowerOffCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.PowerOff();
        }

        public void Undo()
        {
            tv.PowerOn();
        }

        public string GetDescription()
        {
            return "Выключить телевизор";
        }
    }

    public class VolumeUpCommand : ICommand
    {
        private Television tv;
        private int previousVolume;

        public VolumeUpCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            previousVolume = tv.GetVolume();
            tv.IncreaseVolume();
        }

        public void Undo()
        {
            for (int i = 0; i < 5; i++)
            {
                tv.DecreaseVolume();
            }
        }

        public string GetDescription()
        {
            return "Увеличить громкость";
        }
    }

    public class VolumeDownCommand : ICommand
    {
        private Television tv;
        private int previousVolume;

        public VolumeDownCommand(Television tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            previousVolume = tv.GetVolume();
            tv.DecreaseVolume();
        }

        public void Undo()
        {
            for (int i = 0; i < 5; i++)
            {
                tv.IncreaseVolume();
            }
        }

        public string GetDescription()
        {
            return "Уменьшить громкость";
        }
    }

    public class TVRemote
    {
        private ICommand currentCommand;
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void SetCommand(ICommand command)
        {
            currentCommand = command;
            Console.WriteLine($"🔘 Выбрана команда: {command.GetDescription()}");
        }

        public void PressButton()
        {
            if (currentCommand != null)
            {
                currentCommand.Execute();
                commandHistory.Push(currentCommand);
            }
            else
            {
                Console.WriteLine("Команда не выбрана");
            }
        }

        public void PressUndo()
        {
            if (commandHistory.Count > 0)
            {
                ICommand lastCommand = commandHistory.Pop();
                lastCommand.Undo();
                Console.WriteLine($"↩️ Отмена: {lastCommand.GetDescription()}");
            }
            else
            {
                Console.WriteLine("Нет действий для отмены");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("\nИстория команд:");
            foreach (var cmd in commandHistory)
            {
                Console.WriteLine($"  - {cmd.GetDescription()}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Television tv = new Television();
            TVRemote remote = new TVRemote();

            ICommand powerOn = new TVPowerOnCommand(tv);
            ICommand powerOff = new TVPowerOffCommand(tv);
            ICommand volumeUp = new VolumeUpCommand(tv);
            ICommand volumeDown = new VolumeDownCommand(tv);

            remote.SetCommand(powerOn);
            remote.PressButton();
            Console.WriteLine();

            remote.SetCommand(volumeUp);
            remote.PressButton();
            remote.PressButton();
            remote.PressButton();
            Console.WriteLine();

            remote.SetCommand(volumeDown);
            remote.PressButton();
            Console.WriteLine();

            remote.SetCommand(powerOff);
            remote.PressButton();
            Console.WriteLine();

            remote.PressUndo();
            Console.WriteLine();

            remote.ShowHistory();
        }
    }
}