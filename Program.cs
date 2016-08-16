using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson10
{
    public delegate void MyDelegate(double first,double second);
    class Program
    {
        public double firstNumber;
        public double secondNumber;
        public string resultMenu;
        public static string textMenu = "\tChose a few operations\n  1: +\n  2: -\n  3: /\n  4: *";
        protected MyDelegate myDelegate;
        public event MyDelegate eventCalculate
        {
            add { myDelegate += value; }
            remove { myDelegate -= value; }
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.InputNumber("Please enter first number: ",ref program.firstNumber);
            program.InputNumber("Please enter second number: ", ref program.secondNumber);
            program.InputOperation();
            program.MakeIvent();
            program.Calculate(program);
            // Delay
            ReadKey();
        }

        public void MakeIvent()
        {
            if (this.resultMenu.Contains('1'))
            {
                eventCalculate += delegate (double a, double b) 
                {
                    WriteLine("{0} + {1} = {2}",a,b,a+b);
                    
                };
            }
            if (this.resultMenu.Contains('2'))
            {
                eventCalculate += delegate (double a, double b)
                {
                    WriteLine("{0} - {1} = {2}", a, b, a - b);

                };
            }
            if (this.resultMenu.Contains('3'))
            {
                eventCalculate += delegate (double a, double b) 
                {
                    WriteLine("{0} / {1} = {2}", a, b, a / b);

                };
            }
            if (this.resultMenu.Contains('4'))
            {
                eventCalculate += delegate (double a, double b) 
                {
                    WriteLine("{0} * {1} = {2}", a, b, a * b);
                };
            }

        }

        public void Calculate(object sender)
        {
            if (myDelegate != null)
            {
                myDelegate.Invoke(this.firstNumber, this.secondNumber);
                return;
            }
            throw new Exception("OOps");
        }

        public void InputOperation()
        {
            WriteLine(Program.textMenu);
            ForegroundColor = ConsoleColor.Cyan;
            Write("  >> ");
            this.resultMenu = ReadLine().Trim();
            ForegroundColor = ConsoleColor.White;
            bool yes = this.CheckItemMenu();
            if (!yes) this.InputOperation();
        }

        private bool CheckItemMenu()
        {
            if (this.resultMenu != null &&(this.resultMenu.Contains('1')
                                                || resultMenu.Contains('2')
                                                || resultMenu.Contains('3')
                                                || resultMenu.Contains('4')))
            {
                return true;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("You didn't select any operations. Choose one at least");
                ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        public void InputNumber(string msg, ref double num)
        {
            while (true)
            {
                Write(msg);
                string strDouble = ReadLine();
                if(!this.ParseToDouble(strDouble,ref num))
                {
                    
                    WriteLine("\t<< it was not a number!");
                    continue;
                }
                break;

            }
        }

        private bool ParseToDouble(string strDouble, ref double number)
        {
            return Double.TryParse(strDouble,out number);
        }
        public Program()
        {
            ForegroundColor = ConsoleColor.White;
        }
    }
}
