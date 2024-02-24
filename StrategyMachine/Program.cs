using System;

namespace StrategyMachine
{
    internal interface IMachine
    {
        void Starting();
        void Stopping();
    }
    internal interface IDig
    {
        void Digs();
    }
    internal interface IMoves
    {
        void Move();
    }

    internal interface IAction
    {
        void DoAction(string name);
    }

    internal class Mover : IAction
    {
        public void DoAction(string name)
        {
            Console.WriteLine($"{name} moving");
        }
    }

    internal class Diger : IAction
    {
        public void DoAction(string name)
        {
            Console.WriteLine($"{name} digging");
        }
    }

    internal class Excavator : IMachine, IMoves, IDig
    {
        internal Excavator(IAction mover, IAction diger)
        {
            _mover = mover;
            _diger = diger;
        }

        private readonly IAction _mover;
        private readonly IAction _diger;

        public void Starting()
        {
            Console.WriteLine($"{nameof(Excavator)} starting");
        }
        public void Stopping()
        {
            Console.WriteLine($"{nameof(Excavator)} stopping");
        }

        public void Move()
        {
            _mover.DoAction(nameof(Excavator));
        }
        public void Digs()
        {
            _diger.DoAction(nameof(Excavator));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Excavator excavator = new Excavator(new Mover(), new Diger());
            excavator.Starting();
            excavator.Move();
            excavator.Digs();
            excavator.Stopping();

            Console.ReadLine();
        }
    }
}
