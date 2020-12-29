using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Robot
{
    class ConsoleView
    {
        private readonly Actions actions;
        private string ConsoleText;
        private int Steps;
        private Direction ChosenDirection;

        public ConsoleView(IRobotActions robactions)
        {
            this.actions = (Actions)robactions;
            this.Start();
        }

        public void Start()
        {
            Console.WriteLine("Желаете ли вы активировать робота?(введите да или нет)");
            this.ConsoleText = Console.ReadLine();
            if (this.ConsoleText == "да")
            {
                if (this.actions.RobotOn())
                {
                    Console.WriteLine("робот включен");
                }
                this.Continue();
            }
            else if (this.ConsoleText == "нет")
            {
                Console.WriteLine("ok");
                this.Start();
            }
            else
            {
                Console.WriteLine("неизвестная команда");
                this.Start();
            }
            Console.ReadKey();
        }

        public void TurnOff()
        {
            if (this.actions.RobotOff())
                {
                    Console.WriteLine("робот выключен");
                }
            this.Start();
        }

        public void GetLocation()
        {
            Console.WriteLine($"X = {this.actions.robot.PositionOfRobot["X"]}");
            Console.WriteLine($"Y = {this.actions.robot.PositionOfRobot["Y"]}");
            this.Continue();
        }

        public void Continue()
        {
            Console.WriteLine("Начать движение(введите слово движение), показать координыты(введите слово координаты) или отключить робота(введите слово отключить)?");

                this.ConsoleText = Console.ReadLine();
                switch (this.ConsoleText)
                {
                    case "движение":
                        this.ConsoleMove();
                        break;
                    case "координаты":
                        this.GetLocation();
                        break;
                    case "отключить":
                        this.TurnOff();
                        break;
                    default:
                        Console.WriteLine("неизвестная команда");
                        this.Continue();
                        break;
                }
        }

        public void ConsoleMove()
        {
            try
            {
                Console.WriteLine("введите направление(right - направо, up - вверх, left - налево, down - вниз)");
                switch (Console.ReadLine())
                {
                    case "right":
                        this.ChosenDirection = Direction.right;
                        break;
                    case "left":
                        this.ChosenDirection = Direction.left;
                        break;
                    case "up":
                        this.ChosenDirection = Direction.up;
                        break;
                    case "down":
                        this.ChosenDirection = Direction.down;
                        break;
                    default:
                        Console.WriteLine("неправильно введено направление");
                        this.Continue();
                        break;
                }
                Console.WriteLine("введите количество шагов");
                this.Steps = Int32.Parse(Console.ReadLine());
                if (this.actions.MoveOfRobot(ChosenDirection, Steps)) 
                {
                    Console.WriteLine("расстояние пройдено");
                }
            }
            catch (ActionsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Steps}");
            }
            catch(DirectionException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (OffRobotException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            this.Continue();
        }
    }
}
