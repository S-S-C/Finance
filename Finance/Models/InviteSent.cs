﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public class InviteSent
    {
        public int Id { get; set; }
        public int InviteId { get; set; }
        public ApplicationUser User { get; set; }
        public int IsValid { get; set; }
    }
    
}