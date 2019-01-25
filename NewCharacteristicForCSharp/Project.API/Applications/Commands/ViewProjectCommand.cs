﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Project.API.Applications.Commands
{
    public class ViewProjectCommand:IRequest
    {
        public int ProjectId { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }
}