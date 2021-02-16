using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC.Example2
{
    class EventCreator 
    {
        private IEventPublisher _eventPublisher;
        private ILogger _logger;

        public EventCreator(IEventPublisher eventPublisher, ILogger logger)
        {
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public void CreateEvent()
        {
            //tworzenie eventu do bazy danych..
            //...

            _eventPublisher.PublishEvent();
            _logger.Log($"Published succesfully at: {DateTime.Now}");
        }
    }
}
