using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Domain.SeedWork;
using Project.Domain.Events;

namespace Project.Domain.AggregatesModel
{
    public class Project : Entity ,IAggregateRoot
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string Avatat { get; set; }
        public string Company { get; set; }
        public string OriginBPFile { get; set; }
        public string FormatBPFile { get; set; }
        public bool ShowSecurityInfo { get; set; }
        public int ProvinceId { get; set; }
        public int Province { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int AreaId { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
        public DateTime RegisterTime { get; set; }
        public string Introduction { get; set; }
        public string FinPercentage { get; set; }
        public string FinStage { get; set; }
        public int FinMoney { get; set; }
        public int Income { get; set; }
        public int Revenue { get; set; }

        public int Valuation { get; set; }
        public int BrokerageOptions { get; set; }
        public bool OnPlatform { get; set; }

        public ProjectVisibleRule VisibleRule { get; set; }
        public int SourceId { get; set; }
        public int ReferenceId { get; set; }
        public string Tags { get; set; }
        /// <summary>
        /// 项目属性
        /// </summary>
        public List<ProjectProperty> Properties { get; set; }


        public List<ProjectContributors> Contributors { get; set; }

        public List<ProjectViewer> Viewers { get; set; }
        public DateTime UpDateTime { get; set; }
        public DateTime CreatedTime { get; set; }

        private Project CloneProject(Project source=null)
        {
            if (source==null)
            {
                source = this;
            }

            var newProject = new Project
            {
                AreaId = source.AreaId,
                BrokerageOptions = source.BrokerageOptions,
                AreaName = source.AreaName,
                City = source.City,
                CityId = source.CityId,
                Company = source.Company,
                Contributors = new List<ProjectContributors>(),
                Viewers = new List<ProjectViewer>(),
                CreatedTime = DateTime.Now,
                FinMoney = source.FinMoney,
                FinPercentage = source.FinPercentage,
                FinStage = source.FinStage,
                FormatBPFile = source.FormatBPFile,
                Income = source.Income,
                Introduction = source.Introduction,
                OnPlatform = source.OnPlatform,
                OriginBPFile = source.OriginBPFile,
                Province = source.Province,
                ProvinceId = source.ProvinceId,
                VisibleRule = source.VisibleRule == null
                    ? null
                    : new ProjectVisibleRule()
                    {
                        Visible = source.VisibleRule.Visible,
                        Tags = source.VisibleRule.Tags
                    },
                Tags = source.Tags,
                Valuation = source.Valuation,
                ShowSecurityInfo = source.ShowSecurityInfo,
                RegisterTime = source.RegisterTime,
                Revenue = source.Revenue
            };

            newProject.Properties=new List<ProjectProperty>()
            {
                
            };
            foreach (var item in newProject.Properties)
            {
                newProject.Properties.Add(new ProjectProperty(item.Key,
                    item.Text,
                    item.Value));
            }

            return newProject;
        }

        public Project()
        {
            this.Viewers=new List<ProjectViewer>();
            this.Contributors=new List<ProjectContributors>();

            this.AddDomainEvent(new ProjectCreateEvent{ Project = this});
        }
        public Project ContributorFork(int contributorId, Project source = null)
        {
            if (source == null)
            {
                source = this;
            }

            var newProject = CloneProject(source);
            newProject.UserId = contributorId;
            newProject.SourceId = source.SourceId == 0 ? source.Id : source.SourceId;
            newProject.ReferenceId = source.ReferenceId == 0 ? source.Id : source.ReferenceId;
            newProject.UpDateTime=DateTime.Now;

            return newProject;
        }

        public void AddvViewer(int userid,string username,string vavtar)
        {
            var viewer=new ProjectViewer{UserId = userid,UserName = username,Avatar = vavtar,CreatedTime = DateTime.Now};
          

            if (Viewers.All(v => v.UserId != userid))
            {
                Viewers.Add(viewer);
                AddDomainEvent(new ProjectViewedEvent { Viewer = viewer });
            }
           

        }

        public void AddContributor(ProjectContributors contributors)
        {
            if (Contributors.All(v => v.UserId != UserId))
            {
                Contributors.Add(contributors);

                AddDomainEvent(new ProjectJoinedEvent() { Contributors = contributors });
            }


        }
    }
}
