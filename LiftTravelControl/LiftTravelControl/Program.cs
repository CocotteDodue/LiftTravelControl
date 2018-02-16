using LiftTravelControl.Exceptions;
using LiftTravelControl.Extensions;
using LiftTravelControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiftTravelControl
{
    public class Program
    {
        private const int MINFLOOR = 1;
        private const int MAXFLOOR = 10;

        public static void Main(string[] args)
        {
            if (args == null
                || !args.Any())
            {
                throw new ArgumentException("Missing lift floor parameter");
            }

            int currentParkedFloorValue = GetCurrentFloorValue(args);

            if (!currentParkedFloorValue.IsValidFloor(MINFLOOR, MAXFLOOR))
            {
                throw new UnknowFloorExecption(currentParkedFloorValue);
            }

            ILift lift; 
            InitializeProgram(currentParkedFloorValue, out lift);
            Run(lift);
        }

        private static void Run(ILift lift)
        {
            WriteInstructions();

            string input = "default";
            while (!string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine();
                IList<SummonInformation> requests = input.ExtractRequests();
                
                var executionPlan = lift.ProcessRequests(requests);
                Console.Write($"List of floor visited in order: {executionPlan.ToString()}");
                Console.Write(Environment.NewLine);
            }

        }

        private static void WriteInstructions()
        {
            Console.WriteLine("To exit the program, press space");
            Console.WriteLine("Enter the requested floors as an array of RequestedTravelInformation json objects:");
            Console.WriteLine("\t[ { \"F\": floorRequested, \"D\": \"direction\", \"T\": { \"F\": floorRequested, \"D\": \"direction\"} } ,... ]");
            Console.WriteLine("\tfloorRequested: positive int");
            Console.WriteLine("\tdirection should be \"none\" when summoning the lift from inside.");
            Console.WriteLine("\tTriggeringSummon should only be provided when summoning the lift from inside.");
            Console.WriteLine("\tWhen requesting floor, the direction should be none: "); 
            Console.WriteLine("\tfor instance: [ { \"F\": 1, \"D\": \"Up\" }, { \"F\": 4, \"D\": \"None\", \"T\": { \"F\": 1, \"D\": \"Up\" } } ] ");  
            Console.WriteLine("\t\t0: none");
            Console.WriteLine("\t\t1: up");
            Console.WriteLine("\t\t2: down");
        }

        private static void InitializeProgram(int currentParkedFloorValue, out ILift lift)
        {
            FloorConfiguration floorConfig = new FloorConfiguration(currentParkedFloorValue, MINFLOOR, MAXFLOOR);
            IExecutionPlan plan = new ExecutionPlan();
           lift = new Lift(floorConfig, plan);
        }

        private static int GetCurrentFloorValue(string[] args)
        {
            int currentParkedFloorValue;
            bool isNumberFloorValue = int.TryParse(args.First(), out currentParkedFloorValue);

            if (!isNumberFloorValue)
            {
                throw new ArgumentException($"Invalid floor value: {args.First()}");
            }

            return currentParkedFloorValue;
        }
    }
}
