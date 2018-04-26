using System;
using System.Collections.Generic;

namespace _08.CreateCustomClassAttribute.Attributes
{
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; }
        public int Revision { get; }
        public string Description { get; }
        public List<string> Reviewers { get; }
    }
}
