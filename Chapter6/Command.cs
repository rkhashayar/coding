using System;
using System.Collections.Generic;

namespace Chapter6
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }
        public void Undo()
        {
            _light.Off();
        }
    }
    public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }
    public class GarageDoorOpenningCommand : ICommand
    {
        private GarageDoor _garageDoor;
        public GarageDoorOpenningCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void Execute()
        {
            _garageDoor.Open();
        }

        public void Undo()
        {
            _garageDoor.Close();
        }
    }
    public class GarageDoorClosingCommand : ICommand
    {
        private GarageDoor _garageDoor;
        public GarageDoorClosingCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }
        public void Execute()
        {
            _garageDoor.Close();
        }
        public void Undo()
        {
            _garageDoor.Open();
        }
    }
    public abstract class Light
    {
        protected bool IsOn { get; set; }
        public Light()
        {
            IsOn = false;
        }
        public abstract void On();
        public abstract void Off();
    }
    public class LivingRoomLight : Light
    {
        public LivingRoomLight() : base()
        {

        }
        public override void Off()
        {
            if (IsOn)
            {
                Console.WriteLine("living room light is off now");
                IsOn = false;
                return;
            }
            Console.WriteLine("living room light is already off");
        }

        public override void On()
        {
            if (IsOn)
            {
                Console.WriteLine("living room light is already on");
                return;
            }
            IsOn = true;
            Console.WriteLine("living room light is turned on");
        }
    }
    public abstract class GarageDoor
    {
        public bool IsOpen { get; set; }
        public GarageDoor()
        {
            IsOpen = false;
        }
        public void Open()
        {
            if (IsOpen)
            {
                Console.WriteLine("garage door is already open");
                return;
            }
            Console.WriteLine("garage door is openning now");
            IsOpen = true;
        }
        public void Close()
        {
            if (IsOpen)
            {
                Console.WriteLine("garage door is closing now");
                return;
            }
            Console.WriteLine("garage door is already close");
        }
    }
    public class MyHouseGarageDoor : GarageDoor
    {

    }
    public class RemoteControl
    {
        private ICommand[] _commands;
        private List<ICommand> _commandsHistory;
        public RemoteControl(int numberOfSlots)
        {
            _commands = new ICommand[numberOfSlots];
            _commandsHistory = new List<ICommand>();
        }
        public void SetCommand(int slot, ICommand command)
        {
            if (command != null && _commands.Length > slot && slot >= 0)
            {
                _commands[slot] = command;
                return;
            }
            Console.WriteLine("slot out of range");
        }
        public void ButtonPushed(int slotIndex)
        {
            if (slotIndex < _commands.Length)
            {
                _commands[slotIndex].Execute();
                _commandsHistory.Add(_commands[slotIndex]);
                return;
            }
            Console.WriteLine("there is no slot for the number you selected");
        }
        public void UndoButtonPushed()
        {
            var undoCommand = _commandsHistory[_commandsHistory.Count - 1];
            undoCommand?.Undo();
            _commandsHistory.Remove(undoCommand);
        }
    }

    public static class TestRemoteControl
    {
        public static void Test()
        {
            RemoteControl rm = new RemoteControl(2);
            rm.SetCommand(0, new LightOnCommand(new LivingRoomLight()));
            rm.SetCommand(1, new GarageDoorOpenningCommand(new MyHouseGarageDoor()));
            rm.ButtonPushed(1);
            rm.ButtonPushed(0);
            rm.ButtonPushed(1);
            rm.ButtonPushed(0);
            rm.UndoButtonPushed();
        }
    }
}
