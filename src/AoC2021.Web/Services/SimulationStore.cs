using System;
using System.Collections.Concurrent;
using AoC2021.Core.Day25;

namespace AoC2021.Web.Services;

public class SimulationStore
{
    private readonly ConcurrentDictionary<string, SeaCucumberSession> _sessions = new();

    public string Create(string[] lines)
    {
        var id = Guid.NewGuid().ToString("N");
        var sim = new SeaCucumber(lines);
        var session = new SeaCucumberSession(sim);
        _sessions[id] = session;
        return id;
    }

    public bool TryGet(string id, out SeaCucumberSession? session) => _sessions.TryGetValue(id, out session);

    public sealed class SeaCucumberSession
    {
        public SeaCucumber Sim { get; }
        public int Steps { get; private set; }

        public SeaCucumberSession(SeaCucumber sim) => Sim = sim;

        public bool StepOnce()
        {
            var moved = Sim.Step();
            if (moved) Steps++;
            return moved;
        }
    }
}
