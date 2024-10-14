using Serilog.Core;
using Serilog.Events;

namespace CleanArchitecture.Api.SerilogEnrichers;

/// <summary>
/// An implementation of ILogEventEnricher that adds a property to a log event
/// representing the priority of the thread that generated the event.
/// </summary>
public class ThreadPriorityEnricher : ILogEventEnricher
{
    /// <summary>
    /// Enriches a log event with a property representing the priority of the thread
    /// that generated the event.
    /// </summary>
    /// <param name="logEvent">The log event to enrich.</param>
    /// <param name="propertyFactory">The factory to use to create the property.</param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var threadPriorityProperty = propertyFactory.CreateProperty(
            "ThreadPriority",
            Thread.CurrentThread.Priority.ToString()
        );

        logEvent.AddPropertyIfAbsent(threadPriorityProperty);
    }
}