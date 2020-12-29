using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Robot
{
    interface IRobotActions
    {
        public bool MoveOfRobot( Direction dir, int steps);
        public bool RobotOn();
        public bool RobotOff();
    }


    enum Direction
    {
        non,
        right,
        left,
        up,
        down
    }


    class Actions : IRobotActions
    {
        public readonly Robot robot;
        public Actions(Robot rob)
        {
            this.robot = rob;
        }

        public bool RobotOff()
        {
            this.robot.Status = false;
            return true;
        }

        public bool RobotOn()
        {
            this.robot.Status = true;
            return true;
        }

        public bool MoveOfRobot(Direction dir, int steps)
        {
            if (this.robot.Status == true)
            {
                if (this.robot.RecentDirection != dir)
                {
                    switch (dir)
                    {
                        case Direction.right:
                            if (this.robot.PositionOfRobot["X"] + steps > this.robot.Xmax)
                            {
                                throw new ActionsException("робот не может пройти это расстояние", steps);
                            }
                            else
                            {
                                this.robot.PositionOfRobot["X"] = this.robot.PositionOfRobot["X"] + steps;
                                this.robot.RecentDirection = dir;
                                return true;
                            }
                        case Direction.up:
                            if (this.robot.PositionOfRobot["Y"] + steps > this.robot.Ymax)
                            {
                                throw new ActionsException("робот не может пройти это расстояние", steps);
                            }
                            else
                            {
                                this.robot.PositionOfRobot["Y"] = this.robot.PositionOfRobot["Y"] + steps;
                                this.robot.RecentDirection = dir;
                                return true;
                            }
                        case Direction.left:
                            if (this.robot.PositionOfRobot["X"] - steps < this.robot.Xmin)
                            {
                                throw new ActionsException("робот не может пройти это расстояние", steps);
                            }
                            else
                            {
                                this.robot.PositionOfRobot["X"] = this.robot.PositionOfRobot["X"] - steps;
                                this.robot.RecentDirection = dir;
                                return true;
                            }
                        case Direction.down:
                            if (this.robot.PositionOfRobot["Y"] - steps < this.robot.Ymin)
                            {
                                throw new ActionsException("робот не может пройти это расстояние", steps);
                            }
                            else
                            {
                                this.robot.PositionOfRobot["Y"] = this.robot.PositionOfRobot["Y"] - steps;
                                this.robot.RecentDirection = dir;
                                return true;
                            }
                        default:
                            return false;
                    }
                }
                else
                {
                    throw new DirectionException("робот не может двигаться в одном направлении дважды");
                }
            }
            else
            {
                throw new DirectionException("Робот выключен и не может двигаться");
            }
        }
    }

    class Robot
    {
        public int Xmax{ get; }
        public int Xmin { get; }
        public int Ymax { get; }
        public int Ymin { get; }
        public Direction RecentDirection;
        public bool Status = false;
        public Dictionary<string, int> PositionOfRobot = new Dictionary<string, int>
        {
            {"X", 50 },
            {"Y", 50 }
        };
        public Robot()
        {
            this.Xmax = 100;
            this.Xmin = 0;
            this.Ymax = 100;
            this.Ymin = 0;
            this.Status = false;
            //this.PositionOfRobot["X"] = (this.Xmax - this.Xmin) / 2;
            //this.PositionOfRobot["Y"] = (this.Ymax - this.Ymin) / 2;
        }

    }








    /*interface IMove
    {
        void Move();

        void gg();
    }
    class Person : IMove
    {
        public void Move()
        {
            Console.WriteLine("Человек идет");
        }

        public void gg()
        {
            Console.WriteLine(9);
        }
    }
    struct Car : IMove
    {
        public void Move()
        {
            Console.WriteLine("Машина едет");
        }

        public void gg()
        {
            Console.WriteLine(0);
        }
    }
    class Program
    {
        static void Action(IMove movable)
        {
            movable.Move();


        }
        static void Main(string[] args)
        {
            Person person = new Person();
            Car car = new Car();
            Action(person);
            Action(car);
            Console.Read();
        }
    }*/

}
