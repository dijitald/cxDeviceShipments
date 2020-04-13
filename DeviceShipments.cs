// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class NewFile
    {
        [FunctionName("NewFile")]
        [return: EventGrid(TopicEndpointUri = "device-shipments-TopicURI", TopicKeySetting = "device-shipments-TopicKEY")]
        public static EventGridEvent Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
            string _fileName = eventGridEvent.Subject;
            log.LogInformation(_fileName);

            //Read the File
            //Process the file
            //Create output file
            string _newFilePath = _fileName + ".CSV";
            
            //Post link to new file in Event Grid
            return new EventGridEvent(eventGridEvent.Id, _newFilePath, _newFilePath, "Processed", DateTime.UtcNow, "1.0");

        }
    }
    public static class Approved
    {
        [FunctionName("Approved")]
        [return: EventGrid(TopicEndpointUri = "device-shipments-TopicURI", TopicKeySetting = "device-shipments-TopicKEY")]
        public static EventGridEvent Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
            string _fileName = eventGridEvent.Subject;
            log.LogInformation(_fileName);

            //Read the File
            //Process the file            
            //Post result in Event Grid
            return new EventGridEvent(eventGridEvent.Id, _fileName, _fileName, "Final", DateTime.UtcNow, "1.0");

        }
    }
}
