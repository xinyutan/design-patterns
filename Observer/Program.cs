using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup all the players
            Project project = new Project();

            TeamMember teamMember1 = new TeamMember("Jane");
            TeamMember teamMember2 = new TeamMember("Bob");
            TeamMember teamMember3 = new TeamMember("Cathy");

            project.AddTeamMember(teamMember1);
            project.AddTeamMember(teamMember2);
            project.AddTeamMember(teamMember3);

            Task task1 = new Task
            {
                Name = "Research the consumer market",
                TeamMembers = new HashSet<ITeamMember>() { teamMember1, teamMember2 },
                IsFinished = false
            };
            Console.WriteLine("\nAdding a task");
            project.AddTask(task1);

            Task task2 = new Task
            {
                Name = "Design the software architecture",
                TeamMembers = new HashSet<ITeamMember>() { teamMember3 },
                IsFinished = false
            };
            Console.WriteLine("\nAdding a task");
            project.AddTask(task2);

            Console.WriteLine("\nDeleting a task");
            project.RemoveTask(task1);

            Task task3 = new Task
            {
                Name = "Write the initial scaffold of the software",
                TeamMembers = new HashSet<ITeamMember>() { teamMember3 },
                IsFinished = false
            };
            Console.WriteLine("\nAdding a task");
            project.AddTask(task3);
        }
    }
}
