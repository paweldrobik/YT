﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC
{
    class Client2
    {
        private IService _service;
        public IService Service 
        {
            set
            {
                _service = value;
            }
        }

        public void ServeMethod()
        {
            _service.Serve();
        }
    }
}
