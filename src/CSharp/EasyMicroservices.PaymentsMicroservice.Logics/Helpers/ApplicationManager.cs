﻿using EasyMicroservices.PaymentsMicroservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Helpers
{
    public class ApplicationManager
    {
        public static ApplicationManager Instance { get; private set; } = new ApplicationManager();
        public IDependencyManager DependencyManager { get; set; }

    }
}
