using Abp.Domain.Entities;
using SimpleTaskSystem.Persons;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTaskSystem.Tasks
{
    public class Task : Entity<long>
    {
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }

        public virtual int? AssignedPersonId { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState State { get; set; }

        public Task()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Active;
        }
    }

    public enum TaskState : byte
    {
        Active = 1,
        Completed = 2
    }
}
