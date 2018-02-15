# LiftTravelControl
.NETCore C# desktop application that simulate a basic lift travel traject planner based on a unique set of input.

This is a technical task that is design to assess the programming skills (design, architecture, code, approach) of the candidate. The task specification is as follow:

> You are in charge of writing software for an elevator (lift) company. Your task is to write a program to control the travel of a the lift for a 10 storey building:
>
>  * 1: Ground floor
>  * 10: 10th floor
>
> A passenger can summon the lift to go up or down from any floor, once in the lift they can choose the floor they’d like to travel to. Your program needs to plan the optimal set of instructions for the lift to travel, stop, and open its doors.

In order to help with the development process, a set of scenarii has been provided:

* Passenger summons lift on the ground floor. Once in chooses to go to level 5.
* Passenger summons lift on level 6 to go down. Passenger on level 4 summons the lift to go down. They both choose L1.
* Passenger 1 summons lift to go up from L2. Passenger 2 summons lift to go down from L4. Passenger 1 chooses to go to L6. Passenger 2 chooses to go to Ground Floor
* Passenger 1 summons lift to go up from Ground. They choose L5. Passenger 2 summons lift to go down from L4. Passenger 3 summons lift to go down from L10. Passengers 2 and 3 choose to travel to Ground._

### What is used in this project?

* Simple .NETCore console app & xunit Test project
* Development process: Test Driven Development (TDD)
* Console input / output manipulation: 
  * read/write line
  * Json manipulation: Newtonsoft library
* Algorithm knowledge
