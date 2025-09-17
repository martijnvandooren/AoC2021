using AoC2021.Core.Day1;
using AoC2021.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<SimulationStore>();

var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();

app.MapPost("/api/day25/init", (SimulationStore store, InitReq req) =>
{
    var lines = req.Input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    var id = store.Create(lines);
    var ok = store.TryGet(id, out var session);
    var s = session!;
    return Results.Ok(new InitRes
    {
        SessionId = id,
        Height = s.Sim.Height,
        Width = s.Sim.Width,
        Lines = s.Sim.ToLines(),
        Steps = 0
    });
});

app.MapPost("/api/day25/step", (SimulationStore store, StepReq req) =>
{
    if (!store.TryGet(req.SessionId, out var session))
        return Results.NotFound();

    var moved = session!.StepOnce();
    return Results.Ok(new StepRes
    {
        Moved = moved,
        Height = session.Sim.Height,
        Width = session.Sim.Width,
        Lines = session.Sim.ToLines(),
        Steps = session.Steps
    });
});

app.MapPost("/api/day1/run", (RunDay1Req req) =>
{
    var nums = SonarSweep.Parse(req.Input ?? string.Empty);
    return Results.Ok(new { part1 = SonarSweep.CountIncreases(nums), part2 = SonarSweep.CountWindowIncreases(nums) });
});

app.Run();

record InitReq(string Input);
record InitRes
{
    public string SessionId { get; set; } = "";
    public int Height { get; set; }
    public int Width { get; set; }
    public string[] Lines { get; set; } = Array.Empty<string>();
    public int Steps { get; set; }
}

record StepReq(string SessionId);
record StepRes
{
    public bool Moved { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string[] Lines { get; set; } = Array.Empty<string>();
    public int Steps { get; set; }
}

record RunDay1Req(string? Input);
