using System;
using System.Collections.Generic;

namespace Observer
{
    public class Task
    {
        public string Name { get; set; }
        public HashSet<ITeamMember> TeamMembers { get; set; }
        public bool IsFinished { get; set; }
    }

    /// <summary>
    /// Interface for subject
    /// </summary>
    public interface IProject
    {
        void Notify(Task task);
    }

    /// <summary>
    /// Concrete class for subject
    /// </summary>
    public class Project : IProject
    {
        private List<ITeamMember> TeamMembers { get; set; }
        private List<Task> Tasks { get; set; }

        public Project()
        {
            TeamMembers = new List<ITeamMember>();
            Tasks = new List<Task>();
        }

        public void AddTeamMember(ITeamMember teamMember) => TeamMembers.Add(teamMember);

        public void AddTask(Task task)
        {
            if (task.IsFinished)
            {
                throw new Exception("Can't add a finished task");
            }
            Tasks.Add(task);
            Notify(task);
        }

        public void RemoveTask(Task task)
        {
            task.IsFinished = true;
            Tasks.Remove(task);
            Notify(task);
        }
        public void Notify(Task task) => TeamMembers.ForEach(tm => tm.Update(task));

    }

    /// <summary>
    /// Interface for observer
    /// </summary>
    public interface ITeamMember
    {
        void Update(Task task);
    }

    /// <summary>
    /// Concrete class for observer
    /// </summary>
    public class TeamMember : ITeamMember
    {
        public string Name { get; set; }
        private List<Task> Tasks { get; set; }
        
        public TeamMember(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }

        public void Update(Task task)
        {
            if (task.TeamMembers.Contains(this))
            {
                Console.WriteLine("Task {0} includes TeamMember {1}", task.Name, Name);
                Console.WriteLine("Pre-update: {0} tasks", Tasks.Count);
                if (task.IsFinished)
                {
                    Console.WriteLine("Removing this task from this team member.");
                    Tasks.Remove(task);
                }
                else
                {
                    Console.WriteLine("Adding this task to this team member.");
                    Tasks.Add(task);
                }
                Console.WriteLine("Post-update: {0} tasks", Tasks.Count);
            }
        }
    }
}
