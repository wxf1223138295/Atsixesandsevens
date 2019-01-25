using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.SeedWork;

namespace Project.Domain.AggregatesModel
{
    public class ProjectContributors:Entity
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }
        public string UserNmae { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsCloser { get; set; }
        /// <summary>
        /// 1 财务顾问 2 投资机构 
        /// </summary>
        public int ContributorType { get; set; }

    }
}
