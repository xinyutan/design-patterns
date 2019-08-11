using System;
namespace State
{
    abstract public class State
    {
        public int NumTask { get; set; }
        public int Score { get; set; }
        protected User _user;

        public User User
        {
            get => _user;
            set => _user = value;
        }

        public abstract void StateChangeCheck();

        public void AddTask()
        {
            Console.WriteLine("Before adding task, score: {0}, number of tasks: {1}", Score, NumTask);
            NumTask += 1;
            Score += 1;
            Console.WriteLine("After adding task, score: {0}, number of tasks: {1}", Score, NumTask);
            StateChangeCheck();
        }

        public void FinishTask()
        {
            Console.WriteLine("Before finishing task, score: {0}, number of tasks: {1}", Score, NumTask);
            NumTask -= 1;
            Score += 3;
            Console.WriteLine("After finishing task, score: {0}, number of tasks: {1}", Score, NumTask);
            StateChangeCheck();
        }
    }

    public class Novice : State
    {
        public Novice(User user, int numTask = 0, int score = 0)
        {
            User = user;
            NumTask = numTask;
            Score = score;
        }

        public Novice(State state)
        {
            User = state.User;
            NumTask = state.NumTask;
            Score = state.Score;
        }

        public override void StateChangeCheck()
        {
            if (Score >=5 & Score < 10)
            {
                User.State = new Professional(this);
                Console.WriteLine("\n==>Level up to Professional from Novice.\n");
            }
            else if (Score >= 10)
            {
                User.State = new Expert(this);
                Console.WriteLine("\n==>Level up to Expert from Novice.\n");
            }
        }
    }

    public class Professional : State
    {
        public Professional(State state)
        {
            User = state.User;
            NumTask = state.NumTask;
            Score = state.Score;
        }

        public override void StateChangeCheck()
        {
            if (Score >= 10)
            {
                User.State = new Expert(this);
                Console.WriteLine("\n==>Level up to Expert from Professional.\n");
            }
        }
    }

    public class Expert : State
    {
        public Expert(State state)
        {
            User = state.User;
            NumTask = state.NumTask;
            Score = state.Score;
        }

        public override void StateChangeCheck()
        {
            Console.WriteLine("\n==>You are reaching the highest level. Please keep your productivity.\n");
        }
    }

    public class User
    {
        private State _state;
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
            _state = new Novice(this, 0, 0);
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void AddTask()
        {
            _state.AddTask();
        }

        public void FinishTask()
        {
            _state.FinishTask();
        }
    }
}
