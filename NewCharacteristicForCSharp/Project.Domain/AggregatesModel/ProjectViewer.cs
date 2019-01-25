using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.SeedWork;

namespace Project.Domain.AggregatesModel
{
    public class ProjectViewer:Entity
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
