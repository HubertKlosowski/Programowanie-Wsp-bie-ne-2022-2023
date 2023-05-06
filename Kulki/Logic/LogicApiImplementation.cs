using Data;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private DataApi _dataApi;
    private object _lock = new ();

    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
    }
    
    public override List<Circle> GetCircles()
    {
        return _dataApi.GetCircles();
    }

    public override double GetCanvasWidth()
    {
        return _dataApi.GetCanvasWidth();
    }

    public override double GetCanvasHeight()
    {
        return _dataApi.GetCanvasHeight();
    }

    public override void AddCircles(int count)
    {
        try
        {
            _dataApi.AddCircles(count);
        }
        catch (ArgumentException)
        {
            _dataApi.AddCircles(3);
        }
    }
    
    public override void Update()
    {
        foreach (Circle circle in GetCircles())
        {
            CancellationToken token = Cancellation.Token;
            Task task = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                        lock (_lock)
                        {
                            _dataApi.Canvas.MoveCircleOnCanvas(circle);
                        }
                        await Task.Delay(1, token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                }
            }, token);
            Tasks.Add(task);
        }
    }


    public override void Reset()
    {
        Tasks.Clear();
        GetCircles().Clear();
    }

    public override void AddCircle(Circle circle)
    {
        _dataApi.AddCircle(circle);
    }

    public override void Stop()
    {
        Cancellation.Cancel();
        Task.WaitAll(Tasks.ToArray());
    }


    public override void Start()
    {
        Cancellation = new CancellationTokenSource();
    }
}