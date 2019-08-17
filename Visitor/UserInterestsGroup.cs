using System;
using System.Collections.Generic;

namespace Visitor
{
    /// <summary>
    /// abstract class for element
    /// </summary>
    public abstract class User
    {
        public string Name { get; set; }
        public abstract void Accept(InterestsGroup interestsGroup);
    }

    /// <summary>
    /// concrete element class
    /// </summary>
    public class YouthUser : User
    {
        public override void Accept(InterestsGroup interestsGroup) => interestsGroup.VisitYouthUser(this);
    }

    /// <summary>
    /// concrete element class
    /// </summary>
    public class AdultUser: User
    {
        public override void Accept(InterestsGroup interestsGroup) => interestsGroup.VisitAdultUser(this);
    }

    /// <summary>
    /// visitor
    /// </summary>
    public abstract class InterestsGroup
    {
        protected List<AdultUser> adultUsers = new List<AdultUser>();
        protected List<YouthUser> youthUsers = new List<YouthUser>();

        public abstract void VisitYouthUser(YouthUser youthUser);
        public abstract void VisitAdultUser(AdultUser adultUser);

        public void Display()
        {
            Console.WriteLine("Youth users who are interested in {0} are: ", this.GetType().Name);
            youthUsers.ForEach(u => Console.Write(u.Name + "; "));
            Console.WriteLine("\nAdult users who are interested in {0} are: ", this.GetType().Name);
            adultUsers.ForEach(u => Console.Write(u.Name + "; "));
        }
    }

    public class Book : InterestsGroup
    {
        public override void VisitAdultUser(AdultUser adultUser) => adultUsers.Add(adultUser);

        public override void VisitYouthUser(YouthUser youthUser) => youthUsers.Add(youthUser);
    }

    public class Music : InterestsGroup
    {
        public override void VisitAdultUser(AdultUser adultUser) => adultUsers.Add(adultUser);

        public override void VisitYouthUser(YouthUser youthUser) => youthUsers.Add(youthUser);


    }
}
